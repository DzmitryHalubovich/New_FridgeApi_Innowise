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
            var fridgeList = await _dbContext.Fridges.ToListAsync();

            return fridgeList;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Fridge>> GetFridgeById(int id)
        {
            var fridge = await _dbContext.Fridges.Where(c => c.FridgeId == id).FirstOrDefaultAsync();

            if (fridge is null)
                return NotFound();

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
    }
}
