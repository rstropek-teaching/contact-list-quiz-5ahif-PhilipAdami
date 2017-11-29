using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ContactList.Services
{
    public class ContactRepository : IContactRepository
    {

        private readonly List<Person> persons = new List<Person>
        {
            new Person{id=1,firstName="Michael",lastName="Schoeller",email="michael.schoeller98@gmx.at"},
            new Person{id=1,firstName="Fabian",lastName="Maurhart",email="flyingawp@gmail.com"},
            new Person{id=1,firstName="Philipp",lastName="Adami",email="adami97@gmx.at"},
            new Person{id=1,firstName="Patrick",lastName="Mayr",email="steyr@gmx.com"},
            new Person{id=1,firstName="Jan",lastName="Karl",email="KoalaBaer69@gmx.at"}
        };
       
        public void AddPerson(Person p)
        {
            persons.Add(p);
        }

        public bool DeleteById(int id)
        {
            try
            {
                persons.RemoveAt(id - 1);       //-1 becuase of the adaption from "real" numbers to indizes
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Person not found");
            }
            return false;
        }

        public Person GetById(int id)
        {
            return persons.FirstOrDefault(p => p.id == id);
        }

        public IEnumerable<Person> FindByName(string name)
        {
            List<Person> list = new List<Person>();

            foreach (Person p in this.persons)
            {
                if (p.firstName.Contains(name) || p.lastName.Contains(name))
                {
                    list.Add(p);
                }
            }
            return list;    
        }

        public IEnumerable<Person> GetAll()
        {
            return persons.ToArray();
        }

        public Person GetLast()
        {
            return persons.Last();
        }
        public List<Person> GetList()
        {
            return this.persons;
        }
    }
}




