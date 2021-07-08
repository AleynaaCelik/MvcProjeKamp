using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        
        MessageManager mn = new MessageManager(new EfMessageDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        WriterManager vm = new WriterManager(new EfWriterDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {
            var messagelist = mn.GetListInbox();
            return View(messagelist);
        }
        public ActionResult SendBox()
        {
            var messagelist = mn.GetListSendbox();
            return View(messagelist);
        }
        public ActionResult Read() 
        {
            var deger = mn.GetReadList();
            return View(deger);
        }
        public ActionResult UnRead() 
        {
            var deger = mn.GetUnReadList();
            return View(deger);
        }
        public ActionResult Draft() 
        {
            var deger = mn.GetListDraft();
            return View(deger);
        }
        public ActionResult Trash() 
        {
            var deger = mn.GetListTrash();
            return View(deger);
        }
        public PartialViewResult GelenKutuSolMenu() 
        {
            var contactvalues = cm.GetList();
            ViewBag.sayi = contactvalues.Count();

            var deger1 = mn.GetListInbox();
            ViewBag.sayi1 = deger1.Count();

            var deger2 = mn.GetListSendbox();
            ViewBag.sayi2 = deger2.Count();

            var deger3 = mn.GetListDraft();
            ViewBag.sayi3 = deger3.Count();

            var deger4 = mn.GetListTrash();
            ViewBag.sayi4 = deger4.Count();

            var deger5 = mn.GetReadList();
            ViewBag.sayi5 = deger5.Count();

            var deger6 = mn.GetUnReadList();
            ViewBag.sayi6 = deger6.Count();
            return PartialView();

        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var Values = mn.GetByID(id);
            return View(Values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var Values = mn.GetByID(id);
            return View(Values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message x)
        {
            ValidationResult results = messagevalidator.Validate(x);
            if (results.IsValid)
            {
                x.SenderMail = "gizem@hotmail.com";
                x.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mn.MessageAdd(x);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}