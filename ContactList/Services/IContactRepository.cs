using ContactList.Models;
using System.Collections.Generic;

namespace ContactList.Services
{
    public interface IContactRepository
    {
        void AddPerson(Person p);
        IEnumerable<Person> GetAll();
        bool DeleteById(int id);
        IEnumerable<Person> FindByName(string name);
        Person GetLast();


    }
}
