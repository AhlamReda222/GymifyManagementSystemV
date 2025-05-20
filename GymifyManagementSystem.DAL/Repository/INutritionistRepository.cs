using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.DAL.Repository
{
    public interface INutritionistRepository
    {
        IQueryable<nutritionist> GetAll();
        nutritionist GetById(int id);
        void Update(nutritionist nutritionist);
        void Delete(nutritionist nutritionist);
        void Add(nutritionist nutritionist);
    }
}
