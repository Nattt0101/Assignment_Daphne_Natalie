using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

using Assignment_Daphne_Natalie;

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


// Create New List For Guests
List<Guest> guestList = new List<Guest>();

// Create New Dict For Rooms
Dictionary<int, Room> rooms = new Dictionary<int, Room>();

for (int i = 0; i < glines.Length; i++)
{
    string[] gline = glines[i].Split(',');//get each line
    Guest guest = new Guest();
    guest.Name = gline[0];
    guest.PassportNum = gline[1];
    Membership membership = new Membership(gline[2], int.Parse(gline[3]));
    guest.Member = membership;
    guestList.Add(guest);
}

for(int i=0; i < rlines.Length; i++)
{
    string[] rline = rlines[i].Split(',');
    string roomtype=rline[0];
    int roomnumber = int.Parse(rline[1]);
    string bedconfig = rline[2];
    int dailyRate = int.Parse(rline[3]);
    Room room;
    if (roomtype == "Standard")
    {
        room = new StandardRoom(roomnumber,bedconfig,dailyRate,true);
    }
    else
    {
        room = new DeluxeRoom(roomnumber,bedconfig,dailyRate,true);
    }
    rooms.Add(roomnumber, room);
}

for (int i = 0; i < slines.Length; i++)
{
    string[] sline = slines[i].Split(',');
    string name=sline[0];
    string passportnum=sline[1];
    bool ischeckedin=bool.Parse(sline[2]);
    DateTime checkindate = DateTime.Parse(sline[3]);
    DateTime checkoutdate = DateTime.Parse(sline[4]);
    string roomnum=sline[5];
    bool wifi = bool.Parse(sline[6]);
    bool brkfast = bool.Parse(sline[7]);
    bool extrabed = bool.Parse(sline[8]);
    string roomnum2 = sline[9];
    bool wifi2 = bool.Parse(sline[10]);
    bool brkfast2 = bool.Parse(sline[11]);
    bool extrabed2 = bool.Parse(sline[12]);
    Stay stay = new Stay(checkindate, checkoutdate);
    Room room = rooms[int.Parse(roomnum)];
    room.IsAvail = false;
    stay.AddRoom(room);
    if (roomnum2.Length > 0)
    {
        Room room2 = rooms[int.Parse(roomnum2)];
        room2.IsAvail = false;
        stay.AddRoom(room2);
    }
    foreach(Guest guest in guestList)
    {
        if (guest.Name==name && guest.PassportNum == passportnum)
        {
            guest.HotelStay = stay;
        }
    }
}

void DisplayGuests()
{
    
}

DisplayGuests();

foreach (Guest guest in guestList)
{
    Console.WriteLine(guest);
}

void DisplayRooms()
{
    string[] rlines = File.ReadAllLines("Rooms.csv");

    for (int i = 0; i < rlines.Length; i++)
    {
        string[] rline = rlines[i].Split(',');//get each line

        if (i == 0)//first line
        {

        }


        else
        {

            Room room = new StandardRoom(rline[0], rline[1], rline[2], rline[3]);
            roomList.Add(room);
            Console.WriteLine(room);
        }
    }
}

DisplayRooms();
foreach (Room room in roomList)
{
    Console.WriteLine(room);
}

/*
// Method To Display Guests
void DisplayGuests()
{
    // Read File
    string[] glines = File.ReadAllLines("Guests.csv");

    for (int i = 0; i < glines.Length; i++)
    {
        // To Get Each Line
        string[] gline = glines[i].Split(',');

        if (i == 0)
        {
            Console.WriteLine(gline[0] + "\t" + gline[1] + "\t" + gline[2] + "\t" + gline[3]);
        }

        else
        {
            Console.WriteLine(gline[0] + "\t" + gline[1] + "\t" + gline[2] + "\t \t \t" + gline[3]);
        }

    }
}

// Console.WriteLine("\n");

// Method To Display Rooms
void DisplayRooms()
{
    // Read File
    string[] rlines = File.ReadAllLines("Rooms.csv");

    for (int i = 0; i < rlines.Length; i++)
    {
        // To Get Each Line
        string[] rline = rlines[i].Split(',');

        if (i == 0)
        {
            Console.WriteLine(rline[0] + "\t" + rline[1] + "\t" + rline[2] + "\t" + rline[3]);
        }

        else if (i != 0 && i < 8)
        {
            Console.WriteLine(rline[0] + "\t" + rline[1] + "\t \t" + rline[2] + "\t \t \t" + rline[3]);
        }

        else
        {
            Console.WriteLine(rline[0] + "\t \t" + rline[1] + "\t \t" + rline[2] + "\t \t \t" + rline[3]);
        }
    }
}
*/
while (true)
{
    // Display Menu
    try
    {
        Console.WriteLine("\n------------- MENU --------------");
        Console.WriteLine("[1] List all guests\r\n[2] List all available rooms\r\n[3] Register new guest\r\n[4] Check-in guest\r\n[5] Display stay details of a guest\r\n[6] Extend number of days of stay\r\n[0] Exit");
        Console.WriteLine("---------------------------------");
        Console.Write("Enter Your Option: ");

        // Read The Option As An Integer
        int option = int.Parse(Console.ReadLine());

        // Option 1
        if (option == 1)
        {
            // Call The Display Guests Method
            DisplayGuests();
        }

        // Option 2
        if (option == 2)
        {
            // Call The Display Rooms Method
            DisplayRooms();
        }

        // Option 3
        if (option == 3)
        {
            // Prompt User For Information
            Console.Write("Enter Your Name: ");
            Console.Write("Enter Your Passport Number: ");
        }

        if (option == 4)
        {
            // Read File
            string[] glines = File.ReadAllLines("Guests.csv");

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

            // not sure how to do after this
        }
    }

    // Validation For Option Input
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Please Enter A Numeric Value!");
    }
}