using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortyTorun.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Proszę podać nazwę użytkownika.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Proszę podać hasło.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
