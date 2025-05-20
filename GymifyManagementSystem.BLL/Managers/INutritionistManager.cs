using GymifyManagementSystem.BLL.Dtos.NutritionistDto;
using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public interface INutritionistManager
    {
        IEnumerable<NutritionistReadDto> GetAll();
        NutritionistReadDto GetById(int id);
        void Update(NutritionistUpdateDto  nutritionist);
        void Delete( int id);
        void Insert( NutritionistAddDto nutritionist);
    }
}
