﻿using System;

namespace CodingEvents.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        static private int nextID = 1;

        public Event() 
        {
            ID = nextID;
            nextID++;
        }


        public Event(string name, string description)
        {
            Name = name;
            Description = description;
            ID = nextID;
            nextID++;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Event @event && ID == @event.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }
    }
}
