using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GymifyManagementSystem.DAL.Models
{
    public class user : ApplicationUser
    {
        public ICollection<order> orders { get; set; }
    }
}
