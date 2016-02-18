using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FortyTorun.Models
{
    [Table("Pictures")]
    public class Picture
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int ProductID { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
