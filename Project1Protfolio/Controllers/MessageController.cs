using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Protfolio.Controllers
{
    public class MessageController : Controller
    {
        Models.MyPortfolioDbEntities context = new Models.MyPortfolioDbEntities();
        public ActionResult Inbox()
        {
            var values = context.Message.ToList();
            return View(values);
        }
        public ActionResult MessageDetail(int Id)
        {
            var value = context.Message.Where(x => x.MessageId == Id).FirstOrDefault();
            value.IsRead = true;
            context.SaveChanges();
            return View(value);
        }
        public ActionResult MessageStatusChangeToTrue(int id)
        {
            var value = context.Message.Where(x => x.MessageId == id).FirstOrDefault();
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public ActionResult MessageStatusChangeToFalse(int id)
        {
            var value = context.Message.Where(x => x.MessageId == id).FirstOrDefault();
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
    }
}