using GymifyManagementSystem.BLL.Dtos.ProductDto;
using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{
    public interface IProductManager
    {
        IEnumerable<ProductReadDto> GetAll();
        ProductReadDto GetById(int id);
        void Update(ProductUpdateDto products);
        void Delete(int id);
        void Insert(ProductAddDto products);
    }
}
