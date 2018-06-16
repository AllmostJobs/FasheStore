using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Contacts()
        {
            return View();
        }
    }
}