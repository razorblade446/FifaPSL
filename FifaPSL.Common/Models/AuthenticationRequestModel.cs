using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.ComponentModel.DataAnnotations;

namespace FifaPSL.Common.Models
{
    public class AuthenticationRequestModel
    {
        [MinLength(6)]
        [MaxLength(15)]
        [Required]
        public string Username { get; set; }

        [MinLength(6)]
        [Required]
        public string Password { get; set; }
    }
}
