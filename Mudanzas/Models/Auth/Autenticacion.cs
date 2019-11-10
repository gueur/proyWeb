using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mudanzas.Models
{
    public class Autenticacion {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }

      
    }
}
