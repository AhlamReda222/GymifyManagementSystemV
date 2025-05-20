using GymifyManagementSystem.BLL.Dtos.AdminDto;
using GymifyManagementSystem.BLL.Dtos.ProductDto;
using GymifyManagementSystem.BLL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymifyManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_productManager.GetAll());

        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            return Ok(_productManager.GetById(Id));

        }

        [HttpPost]
        public ActionResult Add(ProductAddDto productAddDto)
        {
            _productManager.Insert(productAddDto);
            return NoContent();

        }

        [HttpPut("{Id}")]
        public ActionResult Edit(int Id, ProductUpdateDto productUpdateDto)
        {
            if (Id != productUpdateDto.Id)
                return BadRequest();
            _productManager.Update(productUpdateDto);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            _productManager.Delete(Id);
            return NoContent();
        }
    }
}
