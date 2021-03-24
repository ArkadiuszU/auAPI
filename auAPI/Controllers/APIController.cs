using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auAPI.Helpers;
using auAPI.Models;

namespace auAPI.Controllers
{
    public class APIController : Controller
    {
        // GET: API
        public JsonResult AllPersons()
        {
            return Json(LinqHelper.GetAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult AllNames()
        {
            return Json(LinqHelper.GetAllName(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult PersonByName()
        {
            try
            {
                return Json(LinqHelper.GetPersonByName(RouteData.Values["Id"].ToString()), JsonRequestBehavior.AllowGet);
            }
            catch 
            {
                return Json(new Fault("type", "Fault", "fault"), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult PersonById()
        {
            try
            {
                return Json(LinqHelper.GetPersonById(RouteData.Values["Id"].ToString()), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new Fault("type", "Fault", "fault"), JsonRequestBehavior.AllowGet);
            }
        }

        //Post: API
        [HttpPost]
        public JsonResult AddPerson(Person person)
        {
            try
            {
                return Json(LinqHelper.PostNewPerson(person), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new Fault("type", "Fault", "fault"), JsonRequestBehavior.AllowGet);
            }
           
        }

        //DELETE: API
        [HttpDelete]
        public JsonResult DeletePersonByName()
        {
            try
            {
                return Json(LinqHelper.DeletePersonByName(RouteData.Values["Id"].ToString()), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new Fault("type", "Fault", "fault"), JsonRequestBehavior.AllowGet);
            }
        }
    }
}