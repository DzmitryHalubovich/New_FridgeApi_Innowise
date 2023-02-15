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

        [HttpPut("CreateNewFridge")]
        public async Task<ActionResult<Fridge>> AddNewFridge(FridgeDto fridge)
        {
            var checkInFridges = _dbContext.Fridges.Where(c=>c.Name == fridge.Name).FirstOrDefault();

            if (checkInFridges is not null)
                return BadRequest("This fridge already exists!");

            var newFridge = new Fridge()
            {
                Name = fridge.Name,
                OwnerName= fridge.OwnerName,
            };

            _dbContext.Fridges.Add(newFridge);
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
    }
}
