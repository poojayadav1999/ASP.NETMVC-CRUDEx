using CRUDEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDEx.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        CompanyContext cc=new CompanyContext(); 
        public ActionResult Index()
        {
            return View(this.cc.Categories.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category rec)
        {
            this.cc.Categories.Add(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var rec = this.cc.Categories.Find(id);
            return View(rec);
        }
        [HttpPost]
        public ActionResult Edit(Category rec)
        {
            this.cc.Entry(rec).State = System.Data.Entity.EntityState.Modified;
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var rec = this.cc.Categories.Find(id);
            return View(rec);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deleterec(int id)
        {
            var rec = this.cc.Categories.Find(id);
            this.cc.Categories.Remove(rec);
            this.cc.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}