using Bai1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            listBlogs strList = new listBlogs();
            List<Blog> obj = strList.getBlog(string.Empty);
            return View(obj);
        }
        public PartialViewResult Header()
        {
            return PartialView();
        }
        public PartialViewResult Menu()
        {
            return PartialView();
        }

        //public ActionResult New(Blog blog)
        //{

        //    return View();
        //}

        public ActionResult newBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newBlog(Blog blog)
        {

           
                listBlogs list = new listBlogs();
                list.AddBlog(blog);
                return RedirectToAction("Index");
         
        }


        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }


      
       
      

    }
}