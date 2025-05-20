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
    public class ProductsRepository : IProductsRepository
    {
        private readonly GymifyContext _context;

        public ProductsRepository(GymifyContext context)
        {
           _context = context;
        }
        public void Add(products products)
        {
            _context.Add(products);
            _context.SaveChanges();
        }

        public void Delete(products products)
        {
            _context.Remove(products);
            _context.SaveChanges();
        }

        public IQueryable<products> GetAll()
        {
            return _context.products.AsNoTracking();
        }

        public products GetById(int id)
        {
            return _context.products.Find(id);
        }

        public void Update(products products)
        {
            _context.SaveChanges();
        }
    }
}
