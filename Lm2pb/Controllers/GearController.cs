using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lm2pb.Models;

namespace Lm2pb.Controllers
{
    public class GearController : Controller
    {
        private AdventureWorks2012Entities db = new AdventureWorks2012Entities();

        // GET: Gear
        public ActionResult Index()
        {
            var productCategories = from x in db.ProductCategories where x.ParentProductCategoryID == null && x.ProductCategoryID != 1 select x;
            return View(productCategories.ToList());
        }

        // GET: Gear/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = from x in db.Products where x.ProductCategoryID == id  where x.SellEndDate != null select x;
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        public ActionResult Accessories()
        {
            var accessories = from x in db.ProductCategories where x.ParentProductCategoryID == 4 select x;
            return View(accessories);
        }
        public ActionResult Clothing()
        {
            var clothing = from x in db.ProductCategories where x.ParentProductCategoryID == 3 select x;
            return View(clothing);
        }
        public ActionResult Components()
        {
            var components = from x in db.ProductCategories where x.ParentProductCategoryID == 2 select x;
            return View(components);
        }

    }
}
