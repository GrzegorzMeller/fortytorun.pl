using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortyTorun.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FortyTorun.Models
{
    [Table("Products")]
    public class Product
    {
        [HiddenInput(DisplayValue=false)]
        public int ProductID { get; set; }

        [Required(ErrorMessage ="Proszę podać nazwę produktu.")]
        [Display(Name="Nazwa")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText),Display(Name="Opis")]
        [Required(ErrorMessage ="Proszę podać opis.")]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name="Kategoria")]
        [Required(ErrorMessage ="Proszę okreslić kategorię.")]
        public string Category { get; set; }


    }
}
