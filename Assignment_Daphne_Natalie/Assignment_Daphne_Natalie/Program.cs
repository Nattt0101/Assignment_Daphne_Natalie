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

string[] slines = File.ReadAllLines("Stays.csv"); // Read File

List<Guest> guestList = new List<Guest>(); // Create New List For Guests
List<Room> roomList = new List<Room>(); // Create New List For Rooms

/*
void DisplayGuests()
{
    string[] glines = File.ReadAllLines("Guests.csv");

    for (int i = 0; i < glines.Length; i++)
    {
        string[] gline = glines[i].Split(',');//get each line
        Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", gline[0], gline[1], gline[2], gline[3]);
        Guest guest = new Guest(gline[0], gline[1], gline[3], gline[4]);
        }
    }
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
*/

// Method To Display Guests
void DisplayGuests()
{
    string[] glines = File.ReadAllLines("Guests.csv"); // Read File

    for (int i = 0; i < glines.Length; i++)
    {
        string[] gline = glines[i].Split(','); // To Get Each Line

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
    string[] rlines = File.ReadAllLines("Rooms.csv"); // Read File

    for (int i = 0; i < rlines.Length; i++)
    {
        string[] rline = rlines[i].Split(','); // To Get Each Line

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
    }

    // Validation For Option Input
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Please Enter A Numeric Value!");
    }
}