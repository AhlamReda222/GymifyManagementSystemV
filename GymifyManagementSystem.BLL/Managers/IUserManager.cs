using GymifyManagementSystem.BLL.Dtos.UserDto;
using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public interface IUserManager
    {
        IEnumerable<UserReadDto> GetAll();
        UserReadDto GetById(int id);
        void Update(UserUpdateDto user);
        void Delete(int id);
        void Insert(UserAddDto user);
    }
}
