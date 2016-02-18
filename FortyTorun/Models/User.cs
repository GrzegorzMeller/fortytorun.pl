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
    [Table("Logins")]
   public class User
    {
        public string login { get; set; }
        public string password { get; set; }
    }
}
