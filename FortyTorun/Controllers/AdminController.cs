using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FortyTorun.Models;
using System.Data.Entity;
using System.Web.Security;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        // GET: Admin
        public ViewResult Index()
        {
            EFDbContext tak = new EFDbContext();
            return View(tak.Products);
        }

        //  public int ShowLogins()
        //{
        //  EFDbContext tak = new EFDbContext();
        //int a;
        //a = tak.Users.Count();
        //return a;
        //}
        public ViewResult Poczta()
        {
            EFDbContext tak = new EFDbContext();
            return View(tak.Listy);
        }

        public ViewResult Edit(int productId)
        {
            EFDbContext tak = new EFDbContext();
            return View(tak.Products.FirstOrDefault(p => p.ProductID == productId));
        }

        [HttpPost]
        //public ActionResult Edit(Product product, HttpPostedFileBase image = null)
        //HttpPostedFileBase[] file1
        public ActionResult Edit(Product product, HttpPostedFileBase[] Images ) 
        {
            Picture picture = new Picture();
            if (ModelState.IsValid)
            {
                EFDbContext tak = new EFDbContext();
                foreach (var file in Images)
                {
                    if (file != null)
                    {
                        //product.ImageMimeType = file.ContentType;
                        picture.ImageMimeType = file.ContentType;
                        //product.ImageData = new byte[file.ContentLength];
                        picture.ImageData = new byte[file.ContentLength];
                        //file.InputStream.Read(product.ImageData, 0, file.ContentLength);
                        file.InputStream.Read(picture.ImageData, 0, file.ContentLength);
                        picture.ProductID = product.ProductID;
                        tak.SavePicture(picture);
                    }
                    
                  
                }

                tak.SaveProduct(product);
                TempData["message"] = string.Format("Zapisano {0}", product.Name);
                return RedirectToAction("Index");

            }
            else
            {
                //błąd w wartościach danych
                return View(product);
            }
            return View(product);
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            EFDbContext tak = new EFDbContext();
            Product deletedProduct = tak.DeleteProduct(productId);
            if(deletedProduct != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete2(int listId)
        {
            EFDbContext tak = new EFDbContext();
            Poczta post = tak.DeleteList(listId);
            if (post != null)
            {
                TempData["message"] = string.Format("Usunięto {0}", post.Name);
            }
            return RedirectToAction("Index");
        }


        public void Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

    }
}