using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.DAL.Repository
{
    public interface IProductsRepository
    {
        IQueryable<products> GetAll();
        products GetById(int id);
        void Update(products products);
        void Delete(products products);
        void Add(products products);
    }
}
