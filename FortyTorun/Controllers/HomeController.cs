using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FortyTorun.Models;
using System.Data.Entity;


namespace FortyTorun.Controllers
{
    public class HomeController : Controller
    {
        public int PageSize = 4;

        public PartialViewResult Menu(string category=null)
        {
            EFDbContext tak = new EFDbContext();
            ViewBag.SelectedCategory = category;
            IEnumerable <string> categories = tak.Products.Select(x=>x.Category).Distinct();
            return PartialView(categories);
        }

        public ViewResult Index()
        {
            EFDbContext tak = new EFDbContext();
            return View(tak.Products
                .Where(p=>p.Category =="Aktualności")
                .OrderByDescending(p => p.ProductID)
                .Take(2));
        }


        public ViewResult Kontakt()
        {
            return View();
        }

        public ViewResult gsharp()
        {
            return View();
        }


        public ViewResult Index2(string category, int page = 1)
        {
            @ViewBag.category = category;
            EFDbContext tak = new EFDbContext();

           if(category!= null)
          {
                ViewBag.Info = tak.IleKategoria(category);
                
          }
            else ViewBag.Info = tak.Ile();
        

            return View(tak.Products
                .Where(p => p.Category == category)
                .OrderByDescending(p => p.ProductID )
                .Skip((page - 1) * PageSize)
                .Take(PageSize));
         
        }

        public FileContentResult GetImage(int productId)
        {
            EFDbContext tak = new EFDbContext();
           Picture prod = tak.Pictures.First(p => p.ProductID == productId);
            if(prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public FileContentResult GetImageById(int ImageId)
        {
            EFDbContext tak = new EFDbContext();
            Picture pic = tak.Pictures.FirstOrDefault(q => q.Id == ImageId);
            if (pic.Id != 0)
            {
                return File(pic.ImageData, pic.ImageMimeType);
            }
            else {  return null; }
        }

    //    public FileContentResult[] GetAllImages(int productId)
      //  {
        //    EFDbContext tak = new EFDbContext();
          //  FileContentResult[] send = new FileContentResult[100];
            //int pom = 0;/

           // foreach (var p in tak.Pictures.Where(q => q.ProductID == productId)) 
            //{
              //  send[pom] = File(p.ImageData, p.ImageMimeType);
                //pom++;
          //  }

        //}

        //   [HttpPost]
        public ViewResult Read(int productId)
        {
            EFDbContext tak = new EFDbContext();
            Product a = new Product();
            a= tak.Products.First(p => p.ProductID == productId);

            //int[] Identity=new int[10];
            List<int> Idd=new List<int>();
           // int pom = 0;
            foreach (var p in tak.Pictures.Where(q => q.ProductID == productId))
            {
             //  Identity[pom] = p.Id;
                Idd.Add(p.Id);
              //  pom++;
            }
            Idd.RemoveAt(0);
            ViewBag.Send =Idd;


            return View(a);

        }

        [HttpPost]
        public ActionResult Kontakt(Poczta a)
        {
              //if (ModelState.IsValid)
          //  {

           
            EFDbContext tak = new EFDbContext();
            tak.SaveListy(a);
                TempData["message"] = string.Format("Zapisano {0}", a.Name);
                return RedirectToAction("Index");
          //  }
          //  else
          //  {
                //błąd w wartościach danych
          //      return View(a);
         //   }
        }

    }
}