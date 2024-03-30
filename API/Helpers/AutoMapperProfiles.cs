﻿using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDTO>()
            .ForMember(dest => dest.PhotoUrl, 
                opt => opt.MapFrom(
                    src => src.Photos.FirstOrDefault(
                        x => x.IsMain).Url))
            .ForMember(dest => dest.age, 
                opt => opt.MapFrom(
                    src => src.DateOfBirth.CalculateAge()));

        CreateMap<Photo, PhotoDTO>();
        CreateMap<MemberUpdateDTO, AppUser>();
    }
}