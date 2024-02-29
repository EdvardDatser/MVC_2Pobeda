using kutse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace kutse.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            if(hour < 10)
            {
                ViewBag.Greeting = "Tere hommikust";
            }
            else if(hour > 10)
            {
                ViewBag.Greeting = "Tere päevast";
            }
            else if(hour > 17)
            {
                ViewBag.Greeting = "Tere õhtust";
            }
            else if(hour > 21 && hour < 4)
            {
                ViewBag.Greeting = "Head ööd";
            }
            return View();
        }


        [HttpGet]
        public ActionResult ankeet()
        {
            return View();
        }

        [HttpPost]
        public ViewResult ankeet(Guest guest)
        {
            E_mail(guest);
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return View("Thanks",guest);
            }
            else
            {
                return View();
            }
        }

        public void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "edaktex@gmail.com";
                WebMail.Password = "woki qsun gbmt qrfa ";
                WebMail.From = "edaktex@gmail.com";
                WebMail.Send("edaktex@gmail.com", "Vastus kutsele", guest.Name + " vastus " + ((guest.WillAttend ?? false) ? "tuleb peole " : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud!";
            }
            catch
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja saada!!!";
            }


        }

        GuestContext db = new GuestContext();
        [Authorize]

        public ActionResult Guests()
        {
            IEnumerable<Guest> guests = db.Guests;
            return View(guests);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Guest guest)
        {
            db.Guests.Add(guest);
            db.SaveChanges();
            return RedirectToAction("Guests");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Guest g = db.Guests.Find(id);
            if(g == null)
            {
                return HttpNotFound();
            }
            return View(g);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Guest g = db.Guests.Find(id);
            if(g==null)
            {
                return HttpNotFound();
            }
            db.Guests.Remove(g);
            db.SaveChanges();
            return RedirectToAction("Guests");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Guest g = db.Guests.Find(id);
            if (g == null)
            {
                return HttpNotFound();
            }
            return View(g);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditConfirmed(Guest guest)
        {
            db.Entry(guest).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Guests");
        }

        [HttpGet]
        public ActionResult Accept()
        {
            IEnumerable<Guest> attendingGuests = db.Guests.Where(g => g.WillAttend == true);
            return View("Guests", attendingGuests);
        }
        public ActionResult Reject()
        {
            IEnumerable<Guest> rejectedGuests = db.Guests.Where(g => g.WillAttend == false);
            return View("Guests", rejectedGuests);
        }


        HolidayContext HDdb = new HolidayContext();
        [Authorize]

        public ActionResult Holidays()
        {
            IEnumerable<Holiday> holidays = HDdb.Holidays;
            return View(holidays);

        }

        [HttpGet]
        public ActionResult HDCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HDCreate(Holiday holiday)
        {
            HDdb.Holidays.Add(holiday);
            HDdb.SaveChanges();
            return RedirectToAction("Holidays");
        }

        [HttpGet]
        public ActionResult HDDelete(int id)
        {
            Holiday h = HDdb.Holidays.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            return View(h);
        }

        [HttpPost, ActionName("HDDelete")]
        public ActionResult HDDeleteConfirmed(int id)
        {
            Holiday h = HDdb.Holidays.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            HDdb.Holidays.Remove(h);
            HDdb.SaveChanges();
            return RedirectToAction("Holidays");
        }

        [HttpGet]
        public ActionResult HDEdit(int? id)
        {
            Holiday h = HDdb.Holidays.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            return View(h);
        }

        [HttpPost, ActionName("HDEdit")]
        public ActionResult HDEditConfirmed(Holiday holiday)
        {
            HDdb.Entry(holiday).State = EntityState.Modified;
            HDdb.SaveChanges();
            return RedirectToAction("Holidays");
        }
    }
}