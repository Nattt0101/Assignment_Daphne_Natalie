using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

//========================================================== 
// Student Number : S10242410
// Student Name :  Natalie Peh
//==========================================================

//========================================================== 
// Student Number : S10243748
// Student Name : Daphne Yap
//==========================================================

namespace Assignment_Daphne_Natalie
{
    class Stay
    {
        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public List<Room> RoomList { get; set; }
     


        public Stay()
        {
            RoomList = new List<Room>(); 
        }

        public Stay(DateTime checkInDate, DateTime checkOutDate)
        {
            //create room list
            RoomList = new List<Room>();
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        public void AddRoom(Room room)
        {
            RoomList.Add(room);
        }

        public double CalculateTotal()                                                                                            
        {
            double total = 0;
            TimeSpan duration =CheckOutDate - CheckInDate;
            foreach (Room room in RoomList)
            {
                total += (room.DailyRate * duration.Days) + room.CalculateCharges();
            }
            return total;
        }

        public override string ToString()
        {
            return "CheckInDate: " + CheckInDate + "CheckOutDate: " + CheckOutDate;
        }
    }
}
