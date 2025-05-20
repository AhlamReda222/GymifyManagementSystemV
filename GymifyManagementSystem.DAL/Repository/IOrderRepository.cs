using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.DAL.Repository
{
    public interface IOrderRepository
    {
        IQueryable<order> GetAll();
        order GetById(int id);
        void Update(order order);
        void Delete(order order);
        void Add(order order);
    }
}
