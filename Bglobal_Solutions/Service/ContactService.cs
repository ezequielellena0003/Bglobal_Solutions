using AutoMapper;
using Contact_api.Dtos;
using Contact_api.Interface;
using Fibonacci_api.Models;
using Fibonacci_api.Repository.Interface;

namespace Contact_api.Service
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDto>> GetContactsByStateOrCity(string stateOrCity)
        {
            var contacts = await _contactRepository.GetContactsByStateOrCity(stateOrCity);
            return _mapper.Map<IEnumerable<ContactDto>>(contacts);
        }

        public async Task<ContactDto> GetContactById(int id)
        {
            var contact = await _contactRepository.GetContactById(id);
            return contact == null ? null : _mapper.Map<ContactDto>(contact);
        }

        public async Task<ContactDto> GetContactByEmailOrPhoneNumber(string emailOrPhoneNumber)
        {
            var contact = await _contactRepository.GetContactByEmailOrPhoneNumber(emailOrPhoneNumber);
            return contact == null ? null : _mapper.Map<ContactDto>(contact);
        }

        public async Task<ContactDto> AddContact(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            var createdContact = await _contactRepository.AddContact(contact);
            return _mapper.Map<ContactDto>(createdContact);
        }

        public async Task<ContactDto> UpdateContact(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            var updatedContact = await _contactRepository.UpdateContact(contact);
            return _mapper.Map<ContactDto>(updatedContact);
        }

        public async Task DeleteContact(int id)
        {
            await _contactRepository.DeleteContact(id);
        }
    }
}
