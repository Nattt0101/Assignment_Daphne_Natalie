using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Daphne_Natalie
{
    abstract class Room
    {
        public int RoomNumber { get; set; }

        public string BedConfiguration { get; set; }

        public double DailyRate { get; set; }

        public bool IsAvail { get; set; }

        public Room()
        {

        }

        public Room(int r, string b, double d, bool a)
        {
            RoomNumber = r;
            BedConfiguration = b;
            DailyRate = d;
            IsAvail = a;
        }

        protected Room(Room r, Room b, Room d, Room a)
        {
        }

        public abstract double CalculateCharges();

        public override string ToString()
        {
            return "RoomNumber: " + RoomNumber + "BedConfiguration: " + BedConfiguration + "DailyRate: " + DailyRate + "IsAvail: " + IsAvail;
        }
    }
}
