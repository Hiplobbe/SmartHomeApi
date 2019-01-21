using SmartHomeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHomeApi.Helpers
{
    /// <summary>
    /// A helper class to help simulate a database with changing values.
    /// </summary>
    public static class HomeHelper
    {
        /// <summary>
        /// Returns a list filled with mockup homes, used for testing.
        /// </summary>
        /// <param name="quantity">How many homes you want the method to return</param>
        public static List<Home> GetMockupHomes(int quantity)
        {
            List<Home> returnList = new List<Home>();

            for (int i = 1; i <= quantity; i++)
            {
                Home newHome = new Home
                {
                    Name = i + "",
                    Rooms = GenerateRooms()
                };

                returnList.Add(newHome);
            }

            return returnList;
        }

        private static List<Home.Room> GenerateRooms()
        {
            List<Home.Room> returnList = new List<Home.Room>();
            Random rand = new Random();

            int NumberOfRooms = rand.Next(1, 10);

            for (int i = 1; i <= NumberOfRooms; i++)
            {
                Home.Room newRoom = new Home.Room
                {
                    Name = "Rum "+i,
                    Temperature = RandomDouble(rand, 50, -40),
                    Humidity = RandomDouble(rand, 100 , 0)
                };

                returnList.Add(newRoom);
            }

            return returnList;
        }

        static double RandomDouble(Random rand, double max, double min)
        {            
            double value = rand.NextDouble() * (max - min) + min;

            return Math.Round(value, 2);
        }
    }
}