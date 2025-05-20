using GymifyManagementSystem.BLL.Dtos.AdminDto;
using GymifyManagementSystem.DAL.Models;
using GymifyManagementSystem.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public class AdminManager : IAdminManager
    {
        private readonly IAdminsRepository _adminsRepository;

        public AdminManager(IAdminsRepository adminsRepository)
        {
            _adminsRepository = adminsRepository;
        }

        public IEnumerable<AdminReadDto> GetAll()
        {
            var AdminModels = _adminsRepository.GetAll();

            var AdminDtos = AdminModels
                .Select(a => new AdminReadDto
                {
                    Id = int.Parse(a.Id),   

                    FullName = a.FullName,
                    Email = a.Email,
                })
                .ToList();

            return AdminDtos;
        }

        public AdminReadDto GetById(int id)
        {
            var AdminModel = _adminsRepository.GetById(id);

            var AdminDto = new AdminReadDto
            {
                Id = int.Parse(AdminModel.Id),     

                FullName = AdminModel.FullName,
                Email = AdminModel.Email,
            };
            return AdminDto;
        }

        public void Insert(AdminAddDto admins)
        {
            var AdminModel = new admins
            { 
                FullName = admins.FullName,
                Email = admins.Email,
            };

            _adminsRepository.Add(AdminModel);
        }

        public void Update(AdminUpdateDto admins)
        {
            var AdminModel = new admins
            {
                Id = admins.Id.ToString(),

                FullName = admins.FullName,
                Email = admins.Email,
            };
            _adminsRepository.Update(AdminModel);
        }

        public void Delete(int id)
        {
            var AdminModel = _adminsRepository.GetById(id);
            _adminsRepository.Delete(AdminModel);
        }
    }
}
