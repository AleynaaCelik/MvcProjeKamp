﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DraftController : Controller
    {
        DraftManager draftManager = new DraftManager(new EfDraftDal());
       
        public ActionResult Index ()
        {
            var draftValues = draftManager.GetList();
            return View(draftValues);
        }

        public ActionResult GetDraftDetails(int id)
        {
            var draftValue = draftManager.GetByID(id);
            return View(draftValue);
        }

        [HttpGet]
        public ActionResult AddDraft()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDraft(Draft draft)
        {
            draft.DraftDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            draftManager.Add(draft);
            return RedirectToAction("Draft");
        }
    }
}