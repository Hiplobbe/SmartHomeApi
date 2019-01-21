using SmartHomeApi.Helpers;
using SmartHomeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHomeApi.Controllers
{
    public class HomeController : Controller
    {
        //Keeping this non static will help simulate changes, will also result in houses having lost or gained rooms. (Because of the random generation)
        //To be positive, I can argue that this would simulate users adding or removing sensors, to the different rooms of the house.
        //This also shows the dynamic nature of the frontend, which is very prevelant in my other solutions (frontend just shows the data and rarely care what is given)
        private List<Home> _HomeList = HomeHelper.GetMockupHomes(20); 

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetHomes()
        {
            return Json(_HomeList, JsonRequestBehavior.AllowGet);
        }

        [Route("{id}")]
        [Route("Homes/{id}")]
        [HttpGet]
        public JsonResult GetHome(string id)
        {
            Home home = _HomeList.First(x => x.Name == id);

            return Json(home, JsonRequestBehavior.AllowGet);
        }
    }
}