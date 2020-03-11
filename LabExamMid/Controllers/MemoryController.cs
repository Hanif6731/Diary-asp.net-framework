using LabExamMid.Models;
using LabExamMid.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabExamMid.Controllers
{
    
    public class MemoryController : Controller
    {
        // GET: Memory 
        IMemoryRepository mRep = new MemoryRepository();
        

        [HttpGet]
        public ActionResult Index()
        {
            
            return View(mRep.GetAll(@Session["username"].ToString())); 
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Memory p, HttpPostedFileBase Photo)
        {

            string fileName = Path.GetFileNameWithoutExtension(Photo.FileName);
            string fileExt = Path.GetExtension(Photo.FileName);
            fileName = DateTime.Now.ToString("yyyyMMdd") + "-" + fileName.Trim() + fileExt;
            string uploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
            p.PhotoPath = uploadPath+"\\" + fileName.ToString();
            p.Date = DateTime.Now;
            p.LastModificationDate = DateTime.Now;
            Photo.SaveAs(p.PhotoPath);
            p.PhotoPath = fileName;
            p.Username = @Session["username"].ToString();
            mRep.Insert(p);

            //uRep.Insert(m);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var memory = mRep.Get(id);
           
            return View(memory);
        }
        [HttpPost]
        public ActionResult Edit(Memory p,HttpPostedFileBase Photo)
        {
            if (Photo != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(Photo.FileName);
                string fileExt = Path.GetExtension(Photo.FileName);
                fileName = DateTime.Now.ToString("yyyyMMdd") + "-" + fileName.Trim() + fileExt;
                string uploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
                p.PhotoPath = uploadPath + "\\" + fileName.ToString();
                // p.Date = DateTime.Now;

                Photo.SaveAs(p.PhotoPath);
                p.PhotoPath = fileName;
            }
            
           // p.Username = @Session["username"].ToString();
           

            p.LastModificationDate = DateTime.Now;
            mRep.Update(p);

            //uRep.Insert(m);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var memory = mRep.Get(id);

            return View(memory);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            mRep.Delete(id);

            //uRep.Insert(m);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var memory = mRep.Get(id);

            return View(memory);
        }

    }
}