using RolePlayEntity;
using System.Collections.Generic;

namespace RolePlaySet.Core
{
    public static class EventTaskGenerator
    {
        public static List<EventTask> generateEventTasksList()
        {
            List<EventTask> eventList = new List<EventTask>();
            eventList.Add(new EventTask("Legendás", 8));
            eventList.Add(new EventTask("Epikus", 7));
            eventList.Add(new EventTask("Fantasztikus", 6));
            eventList.Add(new EventTask("Szuper", 5));
            eventList.Add(new EventTask("Nagyszerű", 4));
            eventList.Add(new EventTask("Jó", 3));
            eventList.Add(new EventTask("Fair", 2));
            eventList.Add(new EventTask("Átlagos", 1));
            eventList.Add(new EventTask("Középszerű", 0));
            eventList.Add(new EventTask("Gyenge", -1));
            eventList.Add(new EventTask("Szörnyű", -2));
            return eventList;
        }
    }
}
