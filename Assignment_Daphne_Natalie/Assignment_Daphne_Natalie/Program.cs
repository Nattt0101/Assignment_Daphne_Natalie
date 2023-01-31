using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

using Assignment_Daphne_Natalie;
using System.Diagnostics;
using System.Text.Json.Serialization;

//========================================================== 
// Student Number : S10242410
// Student Name :  Natalie Peh
//==========================================================

//========================================================== 
// Student Number : S10243748
// Student Name : Daphne Yap
//==========================================================

// Read Files
string[] slines = File.ReadAllLines("Stays.csv");
string[] glines = File.ReadAllLines("Guests.csv");
string[] rlines = File.ReadAllLines("Rooms.csv");

using (StreamWriter sw = new StreamWriter("Guest.csv", true)) ;


    // Create New List For Guests
    List<Guest> guestList = new List<Guest>();

// Create New Dict For Rooms
List<Room> roomList = new List<Room>();

List<Stay> stayList = new List<Stay>();

while (true)
{
    
    DisplayMenu();
    int option = int.Parse(Console.ReadLine());
    Console.WriteLine();

    if (option == 1)
    {
        DisplayGuest(guestList);
    }

    else if (option == 2)
    {
        DisplayRoom(roomList);
    }

    else if (option == 3)
    {
       // RegisterGuest(guestList);
    }

    else if (option == 4)
    {
      //  Checkin(guestList);
    }

    else if (option == 5)
    {
        DisplayStay(guestList);
    }

    else if (option == 6)
    {
        ExtendStay(guestList);
    }

    else if (option == 7)
    {
        DisplayMonthlyAmount(guestList, stayList);
    }

    else if (option == 8)
    {
        CheckOutGuest(guestList);
    }

    else if (option == 0)
    {
        Console.WriteLine("---------");
        Console.WriteLine("Goodbye!");
        Console.WriteLine("---------");

        break;
    }

    else
    {
        Console.WriteLine("Invalid option. Please try again.");
    }
}

void DisplayMonthlyAmount(List<Guest> guestList, object stayList)
{
    
}

void CheckOutGuest(List<Guest> guestList)
{
    
}

void ExtendStay(List<Guest> guestList)
{
   
}


void DisplayMenu()
    {
        Console.WriteLine("\n------------- MENU --------------");
        Console.WriteLine("[1] List all guests\r\n[2] List all available rooms\r\n[3] Register new guest\r\n[4] Check-in guest\r\n[5] Display stay details of a guest\r\n[6] Extend number of days of stay\r\n[0] Exit");
        Console.WriteLine("---------------------------------");
        Console.Write("Enter Your Option: ");
    
    }


void DisplayGuest(List<Guest> guestList)
{

    //guest variables
    for (int i = 1; i < glines.Length; i++)
    {
        string[] gline = glines[i].Split(',');//get each line
        Guest guest = new Guest();
        guest.Name = gline[0];
        guest.PassportNum = gline[1];
        Membership membership = new Membership(gline[2], int.Parse(gline[3]));
        guest.Member = membership;
        guestList.Add(guest);
    }

    Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", "Name", "Passport Number", "Membership Status", "Membership Points");
    foreach (Guest guest in guestList)
    {
        Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", guest.Name, guest.PassportNum, guest.Member.Status, guest.Member.Points);
    }

}

void DisplayRoom(List<Room>roomList)
{
    for (int i = 1; i < rlines.Length; i++)
    {
        string[] rline = rlines[i].Split(',');
        string roomtype = rline[0];
        int roomnumber = int.Parse(rline[1]);
        string bedconfig = rline[2];
        int dailyRate = int.Parse(rline[3]);
        Room room;
        if (roomtype == "Standard")
        {
            room = new StandardRoom(roomnumber, bedconfig, dailyRate, true);
        }
        else
        {
            room = new DeluxeRoom(roomnumber, bedconfig, dailyRate, true);
        }
        roomList.Add(room);

    }
    Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", "RoomNumber", "BedConfiguration", "DailyRate", "Available");

    
    foreach (Room r in roomList)
    {
        if (r.IsAvail == true)
        {
            Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", r.RoomNumber, r.BedConfiguration, r.DailyRate, r.IsAvail);

            if (r.IsAvail == null)
            {
                Console.WriteLine("No rooms available! ");
            }
        }
    }
}
void DisplayStay(List<Guest>guestList)
{

    for (int i = 1; i < slines.Length; i++)
    {
        string[] sline = slines[i].Split(',');
        string name = sline[0];
        string passportnum = sline[1];
        bool ischeckedin = bool.Parse(sline[2]);
        DateTime checkindate = DateTime.Parse(sline[3]);
        DateTime checkoutdate = DateTime.Parse(sline[4]);
        string roomnum = sline[5];
        bool wifi = bool.Parse(sline[6]);
        bool brkfast = bool.Parse(sline[7]);
        bool extrabed = bool.Parse(sline[8]);
        string roomnum2 = sline[9];

        //wifi2
        if (sline[10] == "")
        {

            bool wifi2 = bool.Parse("False");
        }
        else
        {

            bool wifi2 = bool.Parse(sline[10]);
        }

        //brkfast2
        if (sline[11] == "")
        {

            bool brkfast2 = bool.Parse("False");
        }
        else
        {

            bool brkfast2 = bool.Parse(sline[11]);
        }

        //extrabed2
        if (sline[12] == "")
        {

            bool extrabed2 = bool.Parse("False");
        }
        else
        {

            bool extrabed2 = bool.Parse(sline[12]);
        }

        Stay stay = new Stay(checkindate, checkoutdate);
        Room room = roomList[int.Parse(roomnum)];
        room.IsAvail = false;
        stay.AddRoom(room);
        if (roomnum2.Length > 0)
        {
            Room room2 = roomList[int.Parse(roomnum2)];
            room2.IsAvail = false;
            stay.AddRoom(room2);
        }
    }
}

// Option 3
void RegisterGuest(List<Guest> guestList)
{
    foreach (Guest guest in guestList)
    {
        // Prompt User For Information
        Console.Write("Enter Your Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Your Passport Number: ");
        string passportnum = Console.ReadLine();
        guest.HotelStay = null;
        guest.Member.Status = "Ordinary";
        guest.Member.Points = 0;
        Guest newguest = new Guest(name, passportnum, guest.HotelStay, guest.Member);
        guestList.Add(newguest);
        using (StreamWriter sw = new StreamWriter("Guests.csv", true))
        {
            sw.WriteLine(guest.Name + "," + guest.PassportNum + "," + guest.Member.Status + "," + guest.Member.Points);
        }
    }

}

            

void Checkin(List<Guest> guestList)
    {
        for (int i = 0; i < glines.Length; i++)
        {
            // To Get Each Line
            string[] gline = glines[i].Split(',');

            // To Get The Lines After The Header
            if (i != 0 && i < 8)
            {
                // Display The Names Of The Guests
                Console.WriteLine(gline[0]);
            }
        }

        // Prompt User To Select A Guest
        Console.Write("Select A Guest: ");
        string guest = Console.ReadLine();

        // Retrieve Selected Guest

        // Prompt User For Check In Date
        Console.Write("Enter Your Check In Date: ");
        string checkin = Console.ReadLine();

        // Prompt User For Check Out Date
        Console.Write("Enter Your Check Out Date: ");
        string checkout = Console.ReadLine();

        // Create Stay Object

        // List Available Rooms

        // Prompt User To Select A Room
        Console.Write("Please Select A Room(Room Number): ");
        int room = Convert.ToInt32(Console.ReadLine());

        // Retrieve Selected Room

        // Response For Standard Room
        if (room == 101 && room == 102 && room == 201 && room == 202 && room == 301 && room == 302)
        {
            Console.Write("Do You Require Wi-Fi And BreakFast? ");
        }

        // Response For Deluxe Room
        if (room == 204 && room == 205 && room == 303 && room == 304)
        {
            Console.Write("Do You Require An Additional Bed? ");
        }

        // Validations For Room Input
        else
        {
            Console.Write("Please Enter A Valid Number!");
        }
    }

        // not sure how to do after this
    
    

           

    