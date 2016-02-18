using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortyTorun.Models;

using System.Data.Entity;

namespace FortyTorun.Models
{
    public class EFDbContext: DbContext
    {

        public DbSet<Poczta> Listy { get; set; }
        // public DbSet<User> Users { get; set; }


        public void SaveListy(Poczta list)
        {

            Listy.Add(list);
            SaveChanges();

        }
        public Poczta DeleteList(int listID)
        {

            Poczta dbEntry = Listy.Find(listID);
            if (dbEntry != null)
            {
                Listy.Remove(dbEntry);
                SaveChanges();
            }
            return dbEntry;

        }

        /// <summary>
        /// /////////////////////
        /// </summary>

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Product> Products { get; set; }
       // public DbSet<User> Users { get; set; }

        public int Ile()
        {
            int wyn = Products.Count();
            return wyn;
        }

        public int IleKategoria(string category)
        {
            int wyn;  
            wyn = Products.Where(p => p.Category == category).Count();
            return wyn;
        }

        public void SaveProduct(Product product)
        {
            if(product.ProductID == 0)
            {
                Products.Add(product);
            }
            else
            {
                Product dbEntry = Products.Find(product.ProductID);
                if(dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                   // dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    //dbEntry.ImageData = product.ImageData;
                    //dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
            SaveChanges();
        }

        public void SavePicture(Picture picture)
        {
            Pictures.Add(picture);
            SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {

            Product dbEntry = Products.Find(productID);
            if(dbEntry != null)
            {
                Products.Remove(dbEntry);
                SaveChanges();
            }
            return dbEntry;
           
        }
    }
}
