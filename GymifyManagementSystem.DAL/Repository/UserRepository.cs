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
    public class UserRepository : IUserRepository
    {
        private readonly GymifyContext _context;

        public UserRepository(GymifyContext context)
        {
            _context = context;
        }
        public void Add(user user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(user user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public IQueryable<user> GetAll()
        {
            return _context.users.AsNoTracking ();
        }

        public user GetById(int id)
        {
            return _context.users.Find(id);
        }

        public void Update(user user)
        {
            _context.SaveChanges();
        }
    }
}
