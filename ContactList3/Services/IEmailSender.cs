using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList3.Services
{
    public interface IEmailSender
    {
        void AddPerson(Person p);
        IEnumerable<Person> GetAll();
        bool DeleteById(int id);
        IEnumerable<Person> FindByName(string name);
        Person GetLast();
    }
}

