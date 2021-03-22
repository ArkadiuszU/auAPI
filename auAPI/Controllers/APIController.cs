using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auAPI.Models;

namespace auAPI.Controllers
{
    public class APIController : Controller
    {
        // GET: API
        public JsonResult GetAllPersons()
        {
            List<Person> personsList = new List<Person>();
            auDataDataContext dc = new auDataDataContext();
            var data = from p in dc.Persons
                       select p;
            foreach (var item in data)
            {
                personsList.Add(new Person(item.id, item.FirstName, item.LastName, 12));
            }
            return Json(personsList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllName()
        {
            List<string> personsList = new List<string>();
            auDataDataContext dc = new auDataDataContext();
            var data = from p in dc.Persons
                       select p;
            foreach (var item in data)
            {
                personsList.Add(item.FirstName);
            }
            return Json(personsList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetByName()
        {
            List<Person> personsList = new List<Person>();
            auDataDataContext dc = new auDataDataContext();
            var data = from p in dc.Persons
                       where p.FirstName == RouteData.Values["Id"].ToString()
                       select p;
            foreach (var item in data)
            {
               personsList.Add(new Person(item.id, item.FirstName, item.LastName, 12));
            }
            return Json(personsList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetById()
        {
            List<Person> personsList = new List<Person>();
            auDataDataContext dc = new auDataDataContext();
            var data = from p in dc.Persons
                       where p.id == Convert.ToInt32(RouteData.Values["Id"])
                       select p;
            foreach (var item in data)
            {
                personsList.Add(new Person(item.id, item.FirstName, item.LastName, 12));
            }
            return Json(personsList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteByName()
        {
           auDataDataContext dc = new auDataDataContext();
           var data = from p in dc.Persons
                   where p.FirstName == RouteData.Values["Id"].ToString()
                   select p;
            dc.Persons.DeleteAllOnSubmit(data);
            dc.SubmitChanges();


            data = from p in dc.Persons
                   select p;

            var d = dc.Persons.OrderByDescending(u => u.id).FirstOrDefault();

            dc.ExecuteCommand($"DBCC CHECKIDENT('Persons', RESEED, {d.id});");
            return Json(RouteData.Values["Id"], JsonRequestBehavior.AllowGet);
        }


        //Post: API
        [HttpPost]
        public JsonResult AddPerson(Person person)
        {
            auDataDataContext dc = new auDataDataContext();
            Persons p = new Persons();
            p.FirstName = person.FirstName;
            p.LastName = person.LastName;
            p.Age = person.Age;
            dc.Persons.InsertOnSubmit(p);
            dc.SubmitChanges();

            return Json(p, JsonRequestBehavior.AllowGet);
        }
    }
}