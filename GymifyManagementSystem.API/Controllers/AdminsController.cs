using GymifyManagementSystem.BLL.Dtos.AdminDto;
using GymifyManagementSystem.BLL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymifyManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminManager _adminManager;

        public AdminsController(IAdminManager adminManager) 
        {
            _adminManager = adminManager;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_adminManager.GetAll());

        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            return Ok(_adminManager.GetById(Id));

        }

        [HttpPost]
        public ActionResult Add(AdminAddDto adminAddDto)
        {
            _adminManager.Insert(adminAddDto);
            return NoContent();

        }

        [HttpPut("{Id}")]
        public ActionResult Edit(int Id, AdminUpdateDto adminUpdateDto)
        {
            if (Id != adminUpdateDto.Id)
                return BadRequest();
            _adminManager.Update(adminUpdateDto);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        { 
            _adminManager.Delete(Id);
            return NoContent();
        }
    }
}
