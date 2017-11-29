using ContactList.Models;
using ContactList.Services;
using Microsoft.AspNetCore.Mvc;
namespace ContactList.Controllers
{
    [Route("/contacts")]
    public class ContactController : Controller
    {
        private IContactRepository contactRepository;


        public ContactController(IContactRepository contactRepository)
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
    }
}