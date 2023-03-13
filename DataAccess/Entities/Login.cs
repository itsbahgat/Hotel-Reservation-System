using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Login
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
    }
}
