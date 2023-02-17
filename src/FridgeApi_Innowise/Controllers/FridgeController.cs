using FridgeApi.DataLayer.DTO;
using FridgeApi.DataLayer.Models;
using FridgeApi.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FridgeApi_Innowise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FridgeController : Controller
    {
        private readonly EFCoreDbContext _dbContext;

        public FridgeController(EFCoreDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        [HttpGet("GetAllFridges")]
        public async Task<ActionResult<List<Fridge>>> Get()
        {
            var fridgeList = await _dbContext.Fridges
                .Include(c=>c.FridgeModel)
                .Include(c=>c.Products)
                .ToListAsync();

            return fridgeList;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Fridge>> GetFridgeById(int id)
        {
            var fridge = await _dbContext.Fridges
                .Where(c => c.FridgeId == id)
                .Include(c=>c.FridgeModel)
                .FirstOrDefaultAsync();

            if (fridge is null)
                return BadRequest($"Fridge with id = {id} does't exist");

            return fridge;
        }

        [HttpPost("CreateNewFridge")]
        public async Task<ActionResult<Fridge>> AddNewFridge(FridgeDto fridge)
        {
            var checkInFridges = _dbContext.Fridges.Where(c=>c.Name == fridge.Name).FirstOrDefault();

            if (checkInFridges is not null)
                return BadRequest("This fridge already exists!");

            var newFridge = new Fridge()
            {
                Name = fridge.Name,
                OwnerName= fridge.OwnerName,
                FridgeModelId = fridge.FridgeModelId,
            };

            _dbContext.Fridges.Add(newFridge).Property("CreateOn").CurrentValue = DateTime.Now;
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("DeleteByID")]
        public async Task<ActionResult> DeleteFridge(int id)
        {
            var checkInFridges = _dbContext.Fridges.Where(c=>c.FridgeId==id).FirstOrDefault();

            if (checkInFridges is null)
                return BadRequest($"Fridge with id = {id} does't exist");

            _dbContext.Fridges.Remove(checkInFridges);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFridge(int id, FridgeDto fridge)
        {
            var existingFridge = await _dbContext.Fridges.Where(c => c.FridgeId == id).FirstOrDefaultAsync();

            if (existingFridge is null)
                return BadRequest("Fridge with this id doesn't exist");

            existingFridge.Name = fridge.Name;
            existingFridge.OwnerName = fridge.OwnerName;
            existingFridge.FridgeModelId = fridge.FridgeModelId;

            _dbContext.Update(existingFridge);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
