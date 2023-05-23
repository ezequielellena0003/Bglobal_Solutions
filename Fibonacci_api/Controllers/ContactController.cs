using Contact_api.Dtos;
using Contact_api.Interface;
using Fibonacci_api.Models;
using Fibonacci_api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Contact_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var contactDto = await _contactService.GetContactById(id);

            if (contactDto == null)
            {
                return NotFound();
            }

            return Ok(contactDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] ContactDto contactDto)
        {
            var createdContactDto = await _contactService.AddContact(contactDto);

            return CreatedAtAction(nameof(GetContact), new { id = createdContactDto.Id }, createdContactDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactDto contactDto)
        {
            if (id != contactDto.Id)
            {
                return BadRequest();
            }

            var updatedContactDto = await _contactService.UpdateContact(contactDto);

            if (updatedContactDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteContact(id);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetContactsByStateOrCity([FromQuery] string stateOrCity)
        {
            var contactsDto = await _contactService.GetContactsByStateOrCity(stateOrCity);

            return Ok(contactsDto);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetContactByEmailOrPhoneNumber([FromQuery] string emailOrPhoneNumber)
        {
            var contactDto = await _contactService.GetContactByEmailOrPhoneNumber(emailOrPhoneNumber);

            if (contactDto == null)
            {
                return NotFound();
            }

            return Ok(contactDto);
        }
    }
}