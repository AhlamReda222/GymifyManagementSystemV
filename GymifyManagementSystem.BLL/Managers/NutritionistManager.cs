using GymifyManagementSystem.BLL.Dtos.NutritionistDto;
using GymifyManagementSystem.DAL.Models;
using GymifyManagementSystem.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public class NutritionistManager : INutritionistManager
    {
        private readonly INutritionistRepository _nutritionistRepository;

        public NutritionistManager(INutritionistRepository nutritionistRepository) 
        {
            _nutritionistRepository = nutritionistRepository;
        }
        public IEnumerable<NutritionistReadDto> GetAll()
        {
            var NutritionistModels = _nutritionistRepository.GetAll();

            var NutritionistDtos = NutritionistModels
                .Select(a => new NutritionistReadDto
                {
                    Id = a.Id,
                    FullName = a.FullName,
                    Email = a.Email,
                   
                })
                .ToList();

            return NutritionistDtos;
        }

        public NutritionistReadDto GetById(int id)
        {
            var NutritionistModel = _nutritionistRepository.GetById(id);
            var NutritionistDto = new NutritionistReadDto
            {
                Email = NutritionistModel.Email,
                Id = NutritionistModel.Id,
                FullName = NutritionistModel.FullName,
            };
            return NutritionistDto;
        }

        public void Insert(NutritionistAddDto nutritionist)
        {
            var NutritionistModel = new nutritionist
            {
                FullName = nutritionist.FullName,
                Email = nutritionist.Email,

            };
            _nutritionistRepository.Add(NutritionistModel);

        }

        public void Update(NutritionistUpdateDto nutritionist)
        {
           var NutritionistModel = _nutritionistRepository.GetById(nutritionist.Id);    
            NutritionistModel .FullName = nutritionist.FullName; 
            NutritionistModel .Email = nutritionist.Email; 
            
            _nutritionistRepository .Update(NutritionistModel);
         
        }

        public void Delete(int id)
        {
           var NutritionistModel = _nutritionistRepository.GetById(id);
            _nutritionistRepository .Delete(NutritionistModel);
        }
    }
}
