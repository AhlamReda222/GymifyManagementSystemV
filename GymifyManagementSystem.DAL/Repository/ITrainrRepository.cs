using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.DAL.Repository
{
    public interface ITrainerRepository
    {
        IQueryable<trainer> GetAll();
        trainer GetById(int id);
        void Update(trainer trainer);
        void Delete(trainer trainer);
        void Add(trainer trainer);
    }
}
