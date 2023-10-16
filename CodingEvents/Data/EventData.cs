using CodingEvents.Models;
using System.Net.NetworkInformation;

namespace CodingEvents.Data
{
    public class EventData
    {
        static private Dictionary<int, Event> Events = new Dictionary<int, Event>();

        //fetch all events
        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }

        //add new event to dictionary
        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.ID, newEvent);
        }

        //remove an event from dictionary
        public static void Remove(int id)
        {
            Events.Remove(id);
        }

        //fetch event
        public static Event GetById(int id)
        {
            return Events[id];
        }
    }
}
