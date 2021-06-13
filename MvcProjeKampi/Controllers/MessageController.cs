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
    public class MessageController : Controller
    {
        // GET: Message
       MessageManager mn = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        [Authorize]
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