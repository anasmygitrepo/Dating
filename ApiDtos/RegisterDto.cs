using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Date.ApiDtos
{
    public class RegisterDto
    {
        [Required]
        public string password { get; set; }

        [Required]
        public string username {get;set;}
    }
}