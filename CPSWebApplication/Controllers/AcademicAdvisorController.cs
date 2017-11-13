﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CPSWebApplication.Models.ViewModel;
using CPSWebApplication.Models.EntityManager;

namespace CPSWebApplication.Controllers
{
    public class AcademicAdvisorController : Controller
    {
        // GET: AcademicAdvisor
        public ActionResult DesignCPS()
        {
            string id;
            if (Session["UserID"] != null)
            {
                id = Session["UserName"].ToString();
            }




            return View();
        }

        [HttpPost]
        public ActionResult DesignCPS(DesignCPSViewModel mdl) {

           // string userID = TempData["UserID"].ToString(); 
            CPSDesignManager mg = new CPSDesignManager();
            
            string studentId = mdl.searchId;
       
            return RedirectToAction("StudentCPSDesign", "DesignCPS", new { id = Convert.ToInt32(studentId) });
        }

        public ActionResult GenerateCPS()
        {
            string id;
            if (Session["UserID"] != null)
            {
                id = Session["UserName"].ToString();
            }

            return View();
        }

        [HttpPost]
        public ActionResult GenerateCPS(DesignCPSViewModel mdl)
        {
            string studentId = mdl.searchId;

            return RedirectToAction("GenerateCPSView", "AcademicAdvisor", new { id = Convert.ToInt32(studentId) });
        }

        public ActionResult GenerateCPSView()
        {
            return View();
        }
       [HttpGet]
        public ActionResult GenerateCPSView(int id)
        {
            bool flag = false;
            string studentId = id.ToString();

            GenerateCPSManager gm = new GenerateCPSManager();
            DesignCPSViewModel vm = gm.getModelForGenerateCPS(studentId);
            
            if (Session["UserID"] != null)
            {
                flag = true;
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult ViewDraftCPS(DesignCPSViewModel mdl)
        {

            string studentId = mdl.searchId;

            return RedirectToAction("GenerateViewDraftCPS", "AcademicAdvisor", new { id = Convert.ToInt32(studentId) });
        }

        [HttpGet]
        public ActionResult ViewDraftCPS()
        {
            string id;
            if (Session["UserID"] != null)
            {
                id = Session["UserName"].ToString();
            }

            return View();
        }
        [HttpGet]
        public ActionResult GenerateViewDraftCPS(int id)
        {
            bool flag = false;
            string studentId = id.ToString();

            CPSDraftToFinalManager mgr = new CPSDraftToFinalManager();
            DesignCPSViewModel vm = mgr.getModelForGenerateDraftCPS(studentId);

            if (Session["UserID"] != null)
            {
                flag = true;
            }

            return View(vm);
        }
        [HttpPost]
        public ActionResult GenerateViewDraftCPS()
        {
            return View();
        }


        public ActionResult ModifyCPS()
        {
            return View();
        }
        
        public ActionResult FinalizeCPS()
        {
            return View();
        }

        public ActionResult AduitCPS()
        {
            return View();
        }

    }
}