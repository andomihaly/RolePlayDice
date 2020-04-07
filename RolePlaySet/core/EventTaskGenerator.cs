using RolePlayEntity;
using System.Collections.Generic;

namespace RolePlaySet.Core
{
    public static class EventTaskGenerator
    {
        public static List<TaskType> generateEventTasksList()
        {
            List<TaskType> eventList = new List<TaskType>();
            eventList.Add(new TaskType("Legendás", 8));
            eventList.Add(new TaskType("Epikus", 7));
            eventList.Add(new TaskType("Fantasztikus", 6));
            eventList.Add(new TaskType("Szuper", 5));
            eventList.Add(new TaskType("Nagyszerű", 4));
            eventList.Add(new TaskType("Jó", 3));
            eventList.Add(new TaskType("Fair", 2));
            eventList.Add(new TaskType("Átlagos", 1));
            eventList.Add(new TaskType("Középszerű", 0));
            eventList.Add(new TaskType("Gyenge", -1));
            eventList.Add(new TaskType("Szörnyű", -2));
            return eventList;
        }
    }
}
