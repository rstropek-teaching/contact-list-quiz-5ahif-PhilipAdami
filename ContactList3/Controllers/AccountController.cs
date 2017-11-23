using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ContactList3.Data;

namespace ContactList3.Controllers
{
    [Route("/contacts")]
    public class ContactController : Controller
    {

        private IEmailSender contactRepository;

        
        public ContactController(IEmailSender contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Person p)
        {

            if (p == null)
            {
                return BadRequest();
            }
            p.id = this.contactRepository.GetLast().id+1;
            this.contactRepository.AddPerson(p);
            return CreatedAtRoute("contacts", p);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(contactRepository.GetAll());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pers = this.contactRepository.GetAll().FirstOrDefault(p => p.id == id);
            if (pers == null)
            {
                return NotFound();
            }

            this.contactRepository.DeleteById(pers.id);
            return Ok("Deleted Successfully!");
        }
        [HttpGet("findByName/{name}")]
        public IActionResult Findbyname(string name)
        {
            if (name.Equals(""))
            {
                return BadRequest();
            }
            List<Person> per = new List<Person>();
            foreach (Person pers in this.contactRepository.GetAll())
            {
                if (pers.firstName.ToLower().Contains(name.ToLower()) || pers.lastName.ToLower().Contains(name.ToLower()))
                {
                    per.Add(pers);
                }
            }
            if (!per.Any())
            {
                return Ok("Nothing found!");
            }
            return Ok(per);
        }

    }

namespace ContactList1.Controllers
{
    [Route("[controller]/[action]")]
    [Route("/contacts")]
    public class ContactController : Controller
    {

        private IEmailSender contactRepository;


        public ContactController(IEmailSender contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Person p)
        {

            if (p == null)
            {
                return BadRequest();
            }
            p.id = this.contactRepository.GetLast().id + 1;
            this.contactRepository.AddPerson(p);
            return CreatedAtRoute("contacts", p);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(contactRepository.GetAll());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pers = this.contactRepository.GetAll().FirstOrDefault(p => p.id == id);
            if (pers == null)
            {
                return NotFound();
            }

            this.contactRepository.DeleteById(pers.id);
            return Ok("Deleted Successfully!");
        }

        [HttpGet("findByName/{name}")]
        public IActionResult FindByname(string name)
        {
            if (name.Equals(""))
            {
                return BadRequest();
            }
            List<Person> per = new List<Person>();
            foreach (Person pers in this.contactRepository.GetAll())
            {
                if (pers.firstName.ToLower().Contains(name.ToLower()) || pers.lastName.ToLower().Contains(name.ToLower()))
                {
                    per.Add(pers);
                }
            }
            if (!per.Any())
            {
                return Ok("Nothing found!");
            }
            return Ok(per);
        }

    }
}
}
