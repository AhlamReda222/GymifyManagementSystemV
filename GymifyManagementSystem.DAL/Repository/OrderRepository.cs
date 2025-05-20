using GymifyManagementSystem.DAL.Database;
using GymifyManagementSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GymifyContext _context;

        public OrderRepository(GymifyContext context)
        {
            _context = context;
        }
        public void Add(order order)
        {
            _context.Add(order);
            _context.SaveChanges();
        }

        public void Delete(order order)
        {
            _context.Remove(order);
            _context.SaveChanges();
        }

        public IQueryable<order> GetAll()
        {
            return _context.orders.AsNoTracking();
        }

        public order GetById(int id)
        {
            return _context.orders.Find(id);
        }

        public void Update(order order)
        {
            _context.SaveChanges();
        }
    }
}
