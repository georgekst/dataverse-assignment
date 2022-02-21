using AutoMapper;
using API.Dtos.Client;
using API.Dtos.ContactInfo;
using API.Models;

namespace API
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Client, GetClientDto>();
            CreateMap<GetClientDto, Client>();
            CreateMap<AddClientDto, Client>();
            CreateMap<UpdateClientDto, GetClientDto>();
            
            
            CreateMap<ContactInfo, GetContactInfoDto>();
            CreateMap<GetContactInfoDto, ContactInfo>();
            CreateMap<AddContactInfoDto, ContactInfo>();
            CreateMap<UpdateContactInfoDto, ContactInfo>();
            CreateMap<UpdateContactInfoDto, GetContactInfoDto>();
        }
    }
}