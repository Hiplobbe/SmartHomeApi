using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeApi.Models
{
    public class Home
    {
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

        public class Room
        {
            public string Name { get; set; }
            public double Temperature { get; set; }
            public double Humidity { get; set; }
        }
    } 
}