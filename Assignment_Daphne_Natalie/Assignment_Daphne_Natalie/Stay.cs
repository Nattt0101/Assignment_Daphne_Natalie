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

        public Stay()
        {

        }

        public Stay(DateTime checkInDate, DateTime checkOutDate)
        {
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        public AddRoom(Room)
        {
            int TotalRoom = // 0 + no. of rooms they want
            return TotalRoom;
        }

        public double CalculateTotal()
        {
            double Total = // idk
            return Total;
        }

        public override string ToString()
        {
            return "CheckInDate: " + CheckInDate + "CheckOutDate: " + CheckOutDate;
        }
    }
}
