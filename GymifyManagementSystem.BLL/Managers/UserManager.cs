using GymifyManagementSystem.BLL.Dtos.TrainerDto;
using GymifyManagementSystem.BLL.Dtos.UserDto;
using GymifyManagementSystem.DAL.Models;
using GymifyManagementSystem.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Delete(int id)
        {
            var UserModel = _userRepository.GetById(id);    
            _userRepository.Delete(UserModel);
        }

        public IEnumerable<UserReadDto> GetAll()
        {

            var UsersModels = _userRepository.GetAll();

            var UsersDtos = UsersModels
                .Select(a => new  UserReadDto
                {   
                    Id = int.Parse(a.Id), // في حالة التحويل من string إلى int
                    FullName = a.FullName,
                    Email = a.Email,

                })
                .ToList();

            return UsersDtos ; 
        }

        public UserReadDto GetById(int id)
        {
          var UserModel = _userRepository.GetById(id);
            var UserDto = new UserReadDto
            {
                Email = UserModel.Email,
                FullName = UserModel.FullName,
            };
            return UserDto;
        }

        public void Insert(UserAddDto user)
        {
            var UserModel = new user
            {
                FullName = user.FullName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
            };
            _userRepository.Add(UserModel);
        }

        public void Update(UserUpdateDto user)
        {
            var UserModel =_userRepository.GetById(user.Id);

            UserModel.Email = user.Email;
            UserModel.PasswordHash = user.PasswordHash;
            UserModel.FullName = user.FullName;

            _userRepository.Update(UserModel);
        }
    }

}
