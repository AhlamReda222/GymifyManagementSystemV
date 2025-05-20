using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.DAL.Models
{

    public class admins : ApplicationUser
    {
        public ICollection<articles> articles { get; set; }
    }
}
