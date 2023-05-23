using Fibonacci_api.Models;

namespace Fibonacci_api.Repository.Interface
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContactsByStateOrCity(string stateOrCity);
        Task<Contact> GetContactById(int id);
        Task<Contact> GetContactByEmailOrPhoneNumber(string emailOrPhoneNumber);
        Task<Contact> AddContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact);
        Task DeleteContact(int id);
    }
}
