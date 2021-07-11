using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
        // GET: WriterPanelMessage
        MessageManager messagemanager = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        DraftManager draftManager = new DraftManager(new EfDraftDal());
        DraftController draftController = new DraftController();
        Context _context = new Context();

        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = messagemanager.GetListInbox();
            return View(messagelist);
        }
        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = messagemanager.GetListSendbox();
            return View(messagelist);
        }
        public PartialViewResult MessageListMenu()
        {

            string p = (string)Session["WriterMail"];
            var writeridinfo = _context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();


            var receiverMail = _context.Messages.Count(m => m.ReceiverMail == p).ToString();
            ViewBag.receiverMail = receiverMail;

            var senderMail = _context.Messages.Count(m => m.SenderMail == p).ToString();
            ViewBag.senderMail = senderMail;

            var draft = _context.Drafts.Count().ToString();
            ViewBag.draft = draft;

            return PartialView();
        }
        public ActionResult Draft()
        {
            var draftValues = draftManager.GetList();
            return View(draftValues);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var messagevalues = messagemanager.GetByID(id);
            return View(messagevalues);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var inboxvalues = messagemanager.GetByID(id);
            return View(inboxvalues);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = messagevalidator.Validate(p);
            results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messagemanager.MessageAdd(p);
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
  
