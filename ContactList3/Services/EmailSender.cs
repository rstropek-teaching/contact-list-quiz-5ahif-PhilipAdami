using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList3.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private readonly List<Person> persons = new List<Person>()
        {
            new Person {id = 1, firstName = "Philip", lastName = "Adami", email = "if120034@htblaperg.onmicrosoft.com" },
        };

        public void AddPerson(Person p)
        {
            persons.Add(p);
        }

        public IEnumerable<Person> GetAll()
        {
            return persons.ToArray();
        }

        public bool DeleteById(int id)
        {
            try
            {
                persons.RemoveAt(id - 1);
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
        public Person GetLast()
        {
            return this.persons.Last();
        }
    }
}

