using GymifyManagementSystem.BLL.Dtos.AdminDto;
using GymifyManagementSystem.BLL.Dtos.NutritionistDto;
using GymifyManagementSystem.BLL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymifyManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionistsController : ControllerBase
    {
        private readonly INutritionistManager _NutritionistManager;

        public NutritionistsController (INutritionistManager nutritionistManager)
        {
            _NutritionistManager = nutritionistManager;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_NutritionistManager.GetAll());

        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            return Ok(_NutritionistManager.GetById(Id));

        }

        [HttpPost]
        public ActionResult Add(NutritionistAddDto nutritionistAddDto)
        {
            _NutritionistManager.Insert(nutritionistAddDto);
            return NoContent();

        }

        [HttpPut("{Id}")]
        public ActionResult Edit(int Id, NutritionistUpdateDto nutritionistUpdateDto)
        {
            if (Id != nutritionistUpdateDto.Id)
                return BadRequest();
            _NutritionistManager.Update(nutritionistUpdateDto);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            _NutritionistManager.Delete(Id);
            return NoContent();
        }
    }
}
