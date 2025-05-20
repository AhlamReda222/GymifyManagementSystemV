using GymifyManagementSystem.BLL.Dtos.NutritionistDto;
using GymifyManagementSystem.BLL.Dtos.TrainerDto;
using GymifyManagementSystem.DAL.Models;
using GymifyManagementSystem.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public class TrainerManager : ITrainerManager
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerManager(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }
        public void Delete(int id)
        {
            var trainerModel =_trainerRepository.GetById(id);
            _trainerRepository.Delete(trainerModel);
        }

        public IEnumerable<trainerReadDto> GetAll()
        {
            var TrainerModels = _trainerRepository.GetAll();

            var TrainerDtos = TrainerModels
                .Select(a => new trainerReadDto
                {
                    Id = int.Parse(a.Id), 
                    FullName = a.FullName,
                    Email = a.Email,

                })
                .ToList();

            return TrainerDtos;
        }

        public trainerReadDto GetById(int id)
        {
            var trainerModel = _trainerRepository.GetById(id);
            var trainerDto = new trainerReadDto
            {
                FullName = trainerModel.FullName,
                Email = trainerModel.Email,
            };
            return trainerDto;
        }

        public void Insert(trainerAddDto trainer)
        {
            var trainerModel = new trainer
            {
                FullName = trainer.FullName,
                Email = trainer.Email,
            };
             _trainerRepository.Add(trainerModel);
    }

        public void Update(trainerUpdateDto trainer)
        {
          var trainerModel = _trainerRepository.GetById(trainer.Id);

            trainerModel.FullName = trainer.FullName;
            trainerModel.Email = trainer.Email;
            trainerModel.PasswordHash = trainer.PasswordHash;

            _trainerRepository.Update(trainerModel);
        }
    }

}
