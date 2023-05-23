using Fibonacci_api.Models;
using Fibonacci_api.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace Fibonacci_api.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context.MyDbContext _context;

        public ContactRepository(Context.MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetContactsByStateOrCity(string stateOrCity)
        {
            return await _context.Contact
                .Where(c => c.State == stateOrCity || c.City == stateOrCity)
                .ToListAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _context.Contact.FindAsync(id);
        }

        public async Task<Contact> GetContactByEmailOrPhoneNumber(string emailOrPhoneNumber)
        {
            return await _context.Contact
                .Where(c => c.Email == emailOrPhoneNumber || c.WorkPhoneNumber == emailOrPhoneNumber || c.PersonalPhoneNumber == emailOrPhoneNumber)
                .FirstOrDefaultAsync();
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            _context.Contact.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task DeleteContact(int id)
        {
            var contact = await _context.Contact.FindAsync(id);
            if (contact != null)
            {
                _context.Contact.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}
