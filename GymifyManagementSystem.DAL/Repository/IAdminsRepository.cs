using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.DAL.Repository
{
    public interface IAdminsRepository
    {
        IQueryable <admins> GetAll();
        admins GetById(int id);
        void Update(admins admins);
        void Delete (admins admins);
        void Add (admins admins);




    }
}
