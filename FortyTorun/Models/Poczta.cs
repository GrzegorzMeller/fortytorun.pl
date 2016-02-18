using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FortyTorun.Models
{
    [Table("Poczta")]
    public class Poczta
    {

        
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int MessageID { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę produktu.")]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać e-mail.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText), Display(Name = "Treść")]
        [Required(ErrorMessage = "Proszę podać treść.")]
        public string MessageText { get; set; }

    }
}
