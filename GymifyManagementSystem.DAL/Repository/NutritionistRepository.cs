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
    public class NutritionistRepository : INutritionistRepository
    {
        private readonly GymifyContext _context;

        public NutritionistRepository(GymifyContext context)
        {
            _context  = context;
        }
        public  IQueryable <nutritionist> GetAll()
        {

            return _context.nutritionists.AsNoTracking();
        }
        public nutritionist GetById(int id)
        {
            return _context.nutritionists.Find(id);
        }
        public void Add(nutritionist nutritionist)
        {
            _context.Add(nutritionist);
            _context.SaveChanges();
        }

        public void Delete(nutritionist nutritionist)
        {
            _context.Remove(nutritionist); 
            _context.SaveChanges();
        }

        public void Update(nutritionist nutritionist)
        {
             //_context.nutritionists.Update(nutritionist);
            _context.SaveChanges();


        }
    }
}
