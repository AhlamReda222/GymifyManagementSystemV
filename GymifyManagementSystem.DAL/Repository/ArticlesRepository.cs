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
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly GymifyContext _context;

        public ArticlesRepository(GymifyContext context)
        {
            _context = context;
        }
        public void Add(articles articles)
        {
            _context.Add(articles);
            _context.SaveChanges();
        }

        public void Delete(articles articles)
        {
            _context.Remove(articles);
            _context.SaveChanges();
        }

        public IQueryable<articles> GetAll()
        {
            return _context.articles.AsNoTracking(); 
        }

        public articles GetById(int id)
        {
            return _context.articles.Find(id);
        }

        public void Update(articles articles)
        {
            _context.SaveChanges();
        }
    }
}
