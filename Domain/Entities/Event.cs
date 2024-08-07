﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EventManagement.Application.Models;

namespace EventManagement.Domain.Entities

{ 
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public int MaxParticipants { get; set; }
        public byte[] ImageData { get; set; }
        
        public List<EventParticipant> EventParticipants { get; set; }
    }
}