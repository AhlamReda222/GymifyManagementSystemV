using GymifyManagementSystem.BLL.Dtos.AdminDto;
using GymifyManagementSystem.BLL.Dtos.ProductDto;
using GymifyManagementSystem.DAL.Models;
using GymifyManagementSystem.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Managers
{

    public class Productmanager : IProductManager
    {
        private readonly IProductsRepository _productsRepository;

        public Productmanager(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IEnumerable<ProductReadDto> GetAll()
        {
           var productsModels = _productsRepository.GetAll();

            var productsDtos = productsModels 
                .Select(a=> new ProductReadDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Price = a.Price,
                    Description = a.Description,

                })
                .ToList();
            return productsDtos;
                
        }

        public ProductReadDto GetById(int id)
        {
            var ProductModel =_productsRepository.GetById(id);
            var ProductDto = new ProductReadDto
            {
                Id = ProductModel.Id,
                Name = ProductModel.Name ,
                Price = ProductModel.Price ,
                Description = ProductModel.Description ,
            };
            return ProductDto ;
        }

        public void Insert(ProductAddDto products)
        {
            var ProductModel = new products 
            { 
                Name = products.Name ,
                Price = products.Price ,
                Description = products.Description ,
            };
            _productsRepository.Add(ProductModel);
        }

        public void Update(ProductUpdateDto products)
        {
            var ProductModel = _productsRepository.GetById(products.Id);

            ProductModel.Name = products.Name;
            ProductModel.Price = products.Price;
            ProductModel.Description = products.Description;

            _productsRepository.Update(ProductModel);
        }
        public void Delete(int id)
        {
            var ProductModel = _productsRepository.GetById(id) ;
            _productsRepository.Delete(ProductModel);
        }
    }
}
