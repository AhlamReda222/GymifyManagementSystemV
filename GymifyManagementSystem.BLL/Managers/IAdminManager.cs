using GymifyManagementSystem.BLL.Dtos.AdminDto;
using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public interface IAdminManager
    {
        IEnumerable<AdminReadDto> GetAll();
        AdminReadDto GetById(int id);
        void Update(AdminUpdateDto admins);
        void Delete(int id);
        void Insert (AdminAddDto admins);
    }
}
