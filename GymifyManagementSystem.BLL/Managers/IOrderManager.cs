using GymifyManagementSystem.BLL.Dtos.OrderDto;
using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public interface IOrderManager
    {
        IEnumerable<OrderReadDto> GetAll();
        OrderReadDto GetById(int id);
        void Update(OrderUpdateDto order);
        void Delete(int id);
        void Insert(OrderAddDto order);
    }
}
