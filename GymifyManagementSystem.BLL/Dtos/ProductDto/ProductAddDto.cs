using GymifyManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.BLL.Dtos.ProductDto
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

    }
}
