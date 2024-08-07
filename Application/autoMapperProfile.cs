﻿using AutoMapper;
using EventManagement.Application.Models;
using EventManagement.Domain.Entities;

namespace EventManagement.Domain;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EventDTO, Event>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ImageData, opt => opt.Ignore())
            .ForMember(dest => dest.EventParticipants, opt => opt.Ignore());
        
        CreateMap<ParticipantRegisterDTO, Participant>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.EventParticipants, opt => opt.Ignore());
        CreateMap<Event,EventRequest>()
            .ForMember(dest => dest.ImageSrc, opt => opt.MapFrom(src => src.ImageData != null ? $"data:image/png;base64,{Convert.ToBase64String(src.ImageData)}" : null));
    }
}