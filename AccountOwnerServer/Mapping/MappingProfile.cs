using AutoMapper;
using Entities.Dto;
using Entities.Models;

namespace AccountOwnerServer.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>();
  
            CreateMap<CreateOwnerDto, Owner>();
            CreateMap<Account, AccountDto>();

        }
    }
}
