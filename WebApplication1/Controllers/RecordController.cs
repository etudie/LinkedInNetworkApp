using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class RecordController : Controller
    {
        // GET: Record
        public ActionResult Index()
        {
            var record = new Record() { name = "Amy2" };
            var clients = new List<Client>
            {
                new Client { clientName = "Amy" },
                new Client { clientName = "Paul" }
            };

            var viewModel = new RandomClientViewModel
            {
                Record = record,
                Client = clients
            }; 

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("name = " + id);
        }

        public ActionResult ByMessagedDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}