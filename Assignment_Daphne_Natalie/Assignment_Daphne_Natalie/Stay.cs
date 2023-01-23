using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Daphne_Natalie
{
    class Stay
    {
        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public List<Room> RoomList { get; set; }
        = new List<Room>();


        public Stay()
        {

        }

        public Stay(DateTime checkInDate, DateTime checkOutDate)
        {
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        public void AddRoom(Room room)
        {
            RoomList.Add(room);
        }

        public double CalculateTotal()                                                                                                
        {
            double total = checkOutDate - checkInDate
            return total;
        }

        public override string ToString()
        {
            return "CheckInDate: " + CheckInDate + "CheckOutDate: " + CheckOutDate;
        }
    }
}
