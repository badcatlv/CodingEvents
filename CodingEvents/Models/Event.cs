﻿namespace CodingEvents.Models
{
    public class Event
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ContactEmail { get; set; }

        public string Location { get; set; }

        public int? NumberOfAttendees { get; set; }
        public int Id { get; set; }


        public Event()
        {

        }


        public Event(string name, string description, string contactEmail, string location, int numberOfAttendees)
        {
            Name = name;
            Description = description;
            ContactEmail = contactEmail;
            Location = location;
            NumberOfAttendees = numberOfAttendees;

        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Event @event && Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
