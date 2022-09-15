using AutoMapper;
using Sat.Recruitment.Api.Models.Request;
using Sat.Recruitment.Domain.Entities;
using System;

namespace Sat.Recruitment.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequest, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(src => this.NormalizeEmail(src.Email)))
                .ForMember(x => x.Type, opt => opt.MapFrom(src => Enum.Parse<UserType>(src.UserType)));
        }

        private string NormalizeEmail(string email)
        {
            var splitted = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = splitted[0].IndexOf("+", StringComparison.Ordinal);
            splitted[0] = atIndex < 0 ? splitted[0].Replace(".", "") : splitted[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { splitted[0], splitted[1] });
        }
    }
}
