using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.DAL.Repository
{
    public interface IArticlesRepository
    {
        IQueryable<articles> GetAll();
        articles GetById(int id);
        void Update(articles articles);
        void Delete(articles articles);
        void Add(articles articles);
    }
}
