using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.DAL.Repository
{
    public interface IUserRepository
    {
        IQueryable<user> GetAll();
        user GetById(int id);
        void Update(user user);
        void Delete(user user);
        void Add(user user);
    }
}
