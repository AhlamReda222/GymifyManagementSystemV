using GymifyManagementSystem.BLL.Dtos.AdminDto;
using GymifyManagementSystem.BLL.Dtos.ArticleDto;
using GymifyManagementSystem.BLL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymifyManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleManager _articleManager;

        public ArticlesController(IArticleManager articleManager)
        {
            _articleManager = articleManager;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_articleManager.GetAll());

        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            return Ok(_articleManager.GetById(Id));

        }

        [HttpPost]
        public ActionResult Add( ArticleAddDto articleAddDto)
        {
            _articleManager.Insert(articleAddDto);
            return NoContent();

        }

        [HttpPut("{Id}")]
        public ActionResult Edit(int Id, ArticleUpdateDto articleUpdateDto)
        {
            if (Id != articleUpdateDto.Id)
                return BadRequest();
            _articleManager.Update(articleUpdateDto);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            _articleManager.Delete(Id);
            return NoContent();
        }
    }
}
