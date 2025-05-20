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
    public class TrainerRepository : ITrainerRepository
    {
        private readonly GymifyContext _context;

        public TrainerRepository(GymifyContext context)
        {
            _context = context;
        }
        public void Add(trainer trainer)
        {
            _context.Add(trainer);
            _context.SaveChanges();
        }

        public void Delete(trainer trainer)
        {
            _context.Remove(trainer);
            _context.SaveChanges();
        }

        public IQueryable<trainer> GetAll()
        {
            return _context.trainers.AsNoTracking();
        }

        public trainer GetById(int id)
        {
            return _context.trainers.Find(id);
        }

        public void Update(trainer trainer)
        {
            _context.SaveChanges();
        }
    }
}
