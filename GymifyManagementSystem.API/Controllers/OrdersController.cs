using GymifyManagementSystem.BLL.Dtos.AdminDto;
using GymifyManagementSystem.BLL.Dtos.OrderDto;
using GymifyManagementSystem.BLL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymifyManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_orderManager.GetAll());

        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            return Ok(_orderManager.GetById(Id));

        }

        [HttpPost]
        public ActionResult Add(OrderAddDto orderAddDto)
        {
            _orderManager.Insert(orderAddDto);
            return NoContent();

        }

        [HttpPut("{Id}")]
        public ActionResult Edit(int Id, OrderUpdateDto orderUpdateDto)
        {
            if (Id != orderUpdateDto.Id)
                return BadRequest();
            _orderManager.Update(orderUpdateDto);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            _orderManager.Delete(Id);
            return NoContent();
        }
    }
}
