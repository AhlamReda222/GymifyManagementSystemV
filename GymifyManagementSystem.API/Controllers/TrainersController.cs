using GymifyManagementSystem.BLL.Dtos.AdminDto;
using GymifyManagementSystem.BLL.Dtos.TrainerDto;
using GymifyManagementSystem.BLL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymifyManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainerManager _trainerManager;

        public TrainersController(ITrainerManager trainerManager)
        {
            _trainerManager = trainerManager;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_trainerManager.GetAll());

        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            return Ok(_trainerManager.GetById(Id));

        }

        [HttpPost]
        public ActionResult Add(trainerAddDto trainerAddDto)
        {
            _trainerManager.Insert(trainerAddDto);
            return NoContent();

        }

        [HttpPut("{Id}")]
        public ActionResult Edit(int Id, trainerUpdateDto trainerUpdateDto)
        {
            if (Id != trainerUpdateDto.Id)
                return BadRequest();
            _trainerManager.Update(trainerUpdateDto);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            _trainerManager.Delete(Id);
            return NoContent();
        }
    }
}
