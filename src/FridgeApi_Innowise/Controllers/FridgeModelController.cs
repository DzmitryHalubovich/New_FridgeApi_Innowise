using FridgeApi.DataLayer.DTO;
using FridgeApi.DataLayer.Models;
using FridgeApi.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FridgeApi_Innowise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeModelController : Controller
    {
        private readonly EFCoreDbContext _dbContext;

        public FridgeModelController(EFCoreDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        [HttpGet("GetAllModels")]
        public async Task<ActionResult<List<FridgeModel>>> Get()
        {
            var fridgeList = await _dbContext.FridgeModels
                .ToListAsync();

            return fridgeList;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<FridgeModel>> GetFridgeModelById(int id)
        {
            var fridge = await _dbContext.FridgeModels
                .Where(c => c.FridgeModelId == id)
                .FirstOrDefaultAsync();

            if (fridge is null)
                return BadRequest($"Fridge with id = {id} does't exist");

            return fridge;
        }

        [HttpPut("CreateNewFridgeModel")]
        public async Task<ActionResult<FridgeModel>> AddNewFridgeModel(FridgeModelDto fridgeModel)
        {
            var checkModel = _dbContext.FridgeModels.Where(c => c.Name == fridgeModel.Name).FirstOrDefault();

            if (checkModel is not null)
                return BadRequest("This fridge model already exists!");

            var newFridgeModel = new FridgeModel()
            {
                Name= fridgeModel.Name,
                Year = int.Parse(fridgeModel.Year)
            };

            _dbContext.FridgeModels.Add(newFridgeModel).Property("CreateOn").CurrentValue = DateTime.Now;
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
