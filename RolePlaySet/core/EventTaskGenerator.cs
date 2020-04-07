using RolePlayEntity;
using System.Collections.Generic;

namespace RolePlaySet.Core
{
    public static class EventTaskGenerator
    {
        public static List<TaskEvent> generateEventTasksList()
        {
            List<TaskEvent> eventList = new List<TaskEvent>();
            eventList.Add(new TaskEvent("Legendás", 8));
            eventList.Add(new TaskEvent("Epikus", 7));
            eventList.Add(new TaskEvent("Fantasztikus", 6));
            eventList.Add(new TaskEvent("Szuper", 5));
            eventList.Add(new TaskEvent("Nagyszerű", 4));
            eventList.Add(new TaskEvent("Jó", 3));
            eventList.Add(new TaskEvent("Fair", 2));
            eventList.Add(new TaskEvent("Átlagos", 1));
            eventList.Add(new TaskEvent("Középszerű", 0));
            eventList.Add(new TaskEvent("Gyenge", -1));
            eventList.Add(new TaskEvent("Szörnyű", -2));
            return eventList;
        }
    }
}
