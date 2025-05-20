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
    public class AdminsRepository : IAdminsRepository
    {
        private readonly GymifyContext _context;

        public AdminsRepository(GymifyContext context) 
        { 
            
          _context = context;
        }
        public void Add(admins admins)
        {
            _context.Add(admins);
            _context.SaveChanges();
        }

        public void Delete(admins admins)
        {
            _context.Remove(admins);
            _context.SaveChanges();
        }

        public IQueryable <admins> GetAll()
        {
            return _context.admins.AsNoTracking() ;
        }

        public admins GetById(int id)
        {
            return _context.admins.Find(id);
        }

        public void Update(admins admins)
        {
            _context.SaveChanges() ;
        }
    }
}
