using GymifyManagementSystem.BLL.Dtos.AdminDto;
using GymifyManagementSystem.BLL.Dtos.UserDto;
using GymifyManagementSystem.BLL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymifyManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_userManager.GetAll());

        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            return Ok(_userManager.GetById(Id));

        }

        [HttpPost]
        public ActionResult Add(UserAddDto userAddDto)
        {
            _userManager.Insert(userAddDto);
            return NoContent();

        }

        [HttpPut("{Id}")]
        public ActionResult Edit(int Id, UserUpdateDto userUpdateDto)
        {
            if (Id != userUpdateDto.Id)
                return BadRequest();
            _userManager.Update(userUpdateDto);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            _userManager.Delete(Id);
            return NoContent();
        }
    }
}
