﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagement.Application.Models;
using EventManagement.Domain.Entities;

namespace EventManagement.Infrastructure.Repositories;

public interface IParticipantRepository
{
    Task RegisterParticipantToEventAsync(int eventId, int participantId);
    Task<IEnumerable<Participant>> GetParticipantsByEventIdAsync(int eventId);
    Task<Participant> GetParticipantByIdAsync(int id);
    Task CancelRegistrationAsync(int eventId, int participantId);
    Task SendEmailToParticipantAsync(int eventId, int participantId, string message);


    Task RegisterParticipantAsync(ParticipantRegisterDTO user);
    
    Task<LoginModel> GetParticipantByEmailAsync(string email);
    Task<int> GetParticipantIdByEmailAsync(string email);
    
    Task<bool> CheckPasswordAsync(LoginModel user,string password);
    
    Task<ExtendedIdentityUser> getExtendedIdentityUserByEmailAsync(string email);
    Task UpdateRefreshTokenAsync(ExtendedIdentityUser user);
    Task AddRefreshTokenField(ParticipantRegisterDTO user);

    Task CanselRefreshToken(int userId);
}