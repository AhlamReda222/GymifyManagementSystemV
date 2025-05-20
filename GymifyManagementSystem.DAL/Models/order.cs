using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.DAL.Models
{
    public class order
    {
        public int Id { get; set; }
       // public int UserId { get; set; }
   //     public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int userId { get; set; }
        public user user { get; set; }
        public int productID { get; set; }
        public products Products { get; set; }


    }
}
