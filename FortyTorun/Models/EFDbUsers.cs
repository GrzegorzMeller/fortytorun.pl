using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortyTorun.Models;

using System.Data.Entity;


namespace FortyTorun.Models
{
    class EFDbUsers: DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
