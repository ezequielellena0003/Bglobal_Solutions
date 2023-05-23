using Contact_api.Dtos;
using Fibonacci_api.Models;

namespace Contact_api.Interface
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetContactsByStateOrCity(string stateOrCity);
        Task<ContactDto> GetContactById(int id);
        Task<ContactDto> GetContactByEmailOrPhoneNumber(string emailOrPhoneNumber);
        Task<ContactDto> AddContact(ContactDto contact);
        Task<ContactDto> UpdateContact(ContactDto contact);
        Task DeleteContact(int id);
    }
}
