using auAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace auAPI.Helpers
{
    public class LinqHelper
    {
        static private auDataDataContext dataContext = new auDataDataContext();
        static private List<Person> personsList = new List<Person>();
        static private List<string> namesList = new List<string>();


        //GET
        static public List<Person> GetAll()
        {
            personsList.Clear();
            var data = from p in dataContext.Persons
                       select p;
            foreach (var item in data)
            {
                personsList.Add(new Person(item.id, item.FirstName, item.LastName, Convert.ToInt32(item.Age)));
            }
            
            return personsList;
        }
        static public List<string> GetAllName()
        {
            namesList.Clear();
            var data = from p in dataContext.Persons
                       select p;

            foreach (var item in data)
            {
                namesList.Add(item.FirstName);
            }
            return namesList;
        }
        static public List<Person> GetPersonByName(string id)
        {
            personsList.Clear();
            var data = from p in dataContext.Persons
                       where p.FirstName == id
                       select p;

            foreach (var item in data)
            {
                personsList.Add(new Person(item.id, item.FirstName, item.LastName, Convert.ToInt32(item.Age)));
            }

            return personsList;
        }
        static public List<Person> GetPersonById(string id)
        {
            personsList.Clear();
            var data = from p in dataContext.Persons
                       where p.id == Convert.ToInt32(id)
                       select p;

            foreach (var item in data)
            {
                personsList.Add(new Person(item.id, item.FirstName, item.LastName, Convert.ToInt32(item.Age)));
            }

            return personsList;
        }

        //POST
        static public List<Person> PostNewPerson(Person person)
        {
            personsList.Clear();
            Persons p = new Persons();
            p.FirstName = person.FirstName;
            p.LastName = person.LastName;
            p.Age = person.Age;
            dataContext.Persons.InsertOnSubmit(p);
            dataContext.SubmitChanges();

            return GetAll();
        }
        //DELETE
        static public List<Person> DeletePersonByName(string name)
        {
            var data = from p in dataContext.Persons
                       where p.FirstName == name
                       select p;
            dataContext.Persons.DeleteAllOnSubmit(data);
            dataContext.SubmitChanges();
            return GetAll();
        }
    }
       
}