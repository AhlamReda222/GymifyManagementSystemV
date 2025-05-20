using GymifyManagementSystem.BLL.Dtos.OrderDto;
using GymifyManagementSystem.DAL.Models;
using GymifyManagementSystem.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IEnumerable<OrderReadDto> GetAll()
        {
            var OrdersModels = _orderRepository.GetAll();

            var OrderDto = OrdersModels
                .Select(a => new OrderReadDto
                { 
                    Id = a.Id,
                    Quantity = a.Quantity,
                    TotalPrice = a.TotalPrice,
                    OrderDate = a.OrderDate,

            })
            .ToList();
            
            return OrderDto;
        }

        public OrderReadDto GetById(int id)
        {
            var OrderModel = _orderRepository.GetById(id);
            var OrderDto = new OrderReadDto
            {
                Quantity = OrderModel.Quantity,
                TotalPrice = OrderModel.TotalPrice,
                OrderDate = OrderModel.OrderDate,
                Id = OrderModel.Id
            };
            return OrderDto;
        }

        public void Insert(OrderAddDto order)
        {
            var OrderModel = new order
            {
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice,
                OrderDate = order.OrderDate,
            };
            _orderRepository.Add(OrderModel);
        }

        public void Update(OrderUpdateDto order)
        {
            var OrderModel = _orderRepository.GetById(order.Id);
            order.TotalPrice = OrderModel.TotalPrice;
            order.OrderDate = OrderModel.OrderDate;
            order.Id = order.Id;

            _orderRepository.Update(OrderModel);    
        }
        public void Delete(int id)
        {
            var OrderModel = _orderRepository.GetById(id);
            _orderRepository.Delete(OrderModel);
        }
    }
}
