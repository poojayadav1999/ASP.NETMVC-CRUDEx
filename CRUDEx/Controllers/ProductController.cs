using CRUDEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDEx.Controllers
{
    public class ProductController : Controller
    {
        CompanyContext cc = new CompanyContext();
        public ActionResult Index(int page=1,int pagesize=10)
        {
            var products = cc.Products.OrderBy(p => p.ProductId).Skip((page - 1) * pagesize).Take(pagesize).Select(p => new ProductVM
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.CategoryName
            }).ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(this.cc.Categories.ToList(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product rec)
        {
            ViewBag.CategoryId = new SelectList(this.cc.Categories.ToList(), "CategoryId", "CategoryName");
            this.cc.Products.Add(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(this.cc.Categories.ToList(), "CategoryId", "CategoryName");
            var rec = this.cc.Products.Find(id);
            return View(rec);
        }
        [HttpPost]
        public ActionResult Edit(Product rec)
        {
            ViewBag.CategoryId = new SelectList(this.cc.Categories.ToList(), "CategoryId", "CategoryName");
            this.cc.Entry(rec).State = System.Data.Entity.EntityState.Modified;
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var rec = this.cc.Products.Find(id);
            return View(rec);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deleterec(int id)
        {
            var rec = this.cc.Products.Find(id);
            this.cc.Products.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}