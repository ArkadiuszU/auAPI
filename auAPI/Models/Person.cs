using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace auAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }


        //FOR GET
        public Person(int id, string firstname, string lastname, int age)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Age = age;

        }
        
        //FOR POST
        public Person()
        {

        }


    }
}