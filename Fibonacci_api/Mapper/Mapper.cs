using AutoMapper;
using Contact_api.Dtos;
using Fibonacci_api.Models;

namespace Bglobal_Solutions.Mapper
{
    public class Mapper
    {
        public class ContactProfile : Profile
        {
            public ContactProfile()
            {
                CreateMap<Contact, ContactDto>();
                CreateMap<ContactDto, Contact>();
            }
        }
    }
}
