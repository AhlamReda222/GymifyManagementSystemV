using GymifyManagementSystem.BLL.Dtos.TrainerDto;
using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public interface ITrainerManager
    {
        IEnumerable<trainerReadDto> GetAll();
        trainerReadDto GetById(int id);
        void Update(trainerUpdateDto trainer);
        void Delete(int id);
        void Insert(trainerAddDto trainer);
    }
}
