using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;
using System.Text.Json.Serialization;

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

// Create New List For Rooms
List<Room> roomList = new List<Room>();

// Create New List For Stay
List<Stay> stayList = new List<Stay>();

// Guest
for (int i = 1; i < glines.Length; i++)
{
    // To Get Each Line
    string[] gline = glines[i].Split(',');

    Guest guest = new Guest();
    guest.Name = gline[0];
    guest.PassportNum = gline[1];
    Membership membership = new Membership(gline[2], int.Parse(gline[3]));
    guest.Member = membership;

    guestList.Add(guest);
}

// Room
for (int i = 1; i < rlines.Length; i++)
{
    // To Get Each Line
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

// Stay
for (int i = 1; i < slines.Length; i++)
{
    // To Get Each Line
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

    // WiFi 2
    if (sline[10] == "")
    {
        bool wifi2 = bool.Parse("False");
    }

    else
    {
        bool wifi2 = bool.Parse(sline[10]);
    }

    // Breakfast 2
    if (sline[11] == "")
    {
        bool brkfast2 = bool.Parse("False");
    }

    else
    {
        bool brkfast2 = bool.Parse(sline[11]);
    }

    // Extra Bed 2
    if (sline[12] == "")
    {
        bool extrabed2 = bool.Parse("False");
    }

    else
    {
        bool extrabed2 = bool.Parse(sline[12]);
    }

    Stay stay = new Stay(checkindate, checkoutdate);

    foreach (Room room in roomList)
    {
        if (room.RoomNumber == int.Parse(roomnum))
        {
            room.IsAvail = false;
            stay.AddRoom(room);
        }
    }

    if (roomnum2.Length > 0)
    {
        foreach (Room room in roomList)
        {
            if (room.RoomNumber == int.Parse(roomnum2))
            {
                room.IsAvail = false;
                stay.AddRoom(room);
            }
        }
    }

    foreach (Guest guest in guestList)
    {
        if (guest.Name == name && guest.PassportNum == passportnum)
        {
            guest.HotelStay = stay;
        }
    }

    stayList.Add(stay);
}

// Menu
void DisplayMenu()
{
    Console.WriteLine("\n------------- MENU --------------");
    Console.WriteLine("[1] List All Guests\r\n[2] List All Available Rooms\r\n[3] Register New Guest\r\n[4] Check-In Guest\r\n[5] Display Stay Details Of A Guest\r\n[6] Extend Number Of Days Of Stay\r\n[7] Display Monthly Checked Amounts\r\n[8] Check Out Guest\r\n[0] Exit");
    Console.WriteLine("---------------------------------");
    Console.Write("Enter Your Option: ");
}

// Option 1
void DisplayGuest(List<Guest> guestList)
{
    Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", "Name", "Passport Number", "Membership Status", "Membership Points");

    foreach (Guest guest in guestList)
    {
        Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", guest.Name, guest.PassportNum, guest.Member.Status, guest.Member.Points);
    }
}

// Option 2
void DisplayRoom(List<Room> roomList)
{
    Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", "RoomNumber", "BedConfiguration", "DailyRate", "Available");

    foreach (Room r in roomList)
    {
        // Display Available Rooms 
        if (r.IsAvail == true)
        {
            Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", r.RoomNumber, r.BedConfiguration, r.DailyRate, r.IsAvail);
        }
    }
}

// Option 3
void RegisterGuest(List<Guest> guestList)
{
    while (true)
    {
        try
        {
            foreach (Guest guest in guestList)
            {
                // Prompt User For Information
                Console.Write("Enter Your Name: ");

                // Read The Input As String
                string name = Console.ReadLine();

                Console.Write("Enter Your Passport Number: ");

                // Read Input As String
                string passportnum = Console.ReadLine();

                Guest newguest = new Guest();
                newguest.Name = name;

                newguest.PassportNum = passportnum;

                newguest.Member = new Membership("Ordinary", 0);

                guestList.Add(newguest);

                using (StreamWriter sw = new StreamWriter("Guests.csv", true))
                {
                    sw.WriteLine(newguest.Name + "," + newguest.PassportNum + "," + newguest.Member.Status + "," + newguest.Member.Points);
                }

                Console.WriteLine("Guest Registered Successfully!");

                break;
            }

            break;
        }

        // Validation 
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Please Try Again!");
        }
    }
}

// Option 4
void Checkin(List<Guest> guestList)
{
    // Create Guest Object
    Guest guest = new Guest();

    // Call The Display Guest Method
    DisplayGuest(guestList);

    // Prompt User To Select A Guest
    Console.Write("Select A Guest: ");

    // Read The Input As String
    string name = Console.ReadLine();

    // Retrieve Selected Guest
    foreach (Guest g in guestList)
    {
        if (g.Name == name)
        {
            guest = g;
        }
    }

    // Prompt User For Check In Date
    Console.Write("Enter Your Check In Date: ");

    // Read The Input As String
    string checkin = Console.ReadLine();

    // Prompt User For Check Out Date
    Console.Write("Enter Your Check Out Date: ");

    // Read The Input As String
    string checkout = Console.ReadLine();

    // Create Stay Object
    Stay stay = new Stay();

    stay.CheckInDate = DateTime.Parse(checkin);
    stay.CheckOutDate = DateTime.Parse(checkout);

    while (true)
    {
        // Call The Display Guest Method
        DisplayRoom(roomList);

        // Prompt User To Select A Room
        Console.Write("Please Select A Room(Room Number): ");

        // Read The Input As Integer
        int room = Convert.ToInt32(Console.ReadLine());

        bool roomadded = false;

        // Retrieve Selected Room
        foreach (Room r in roomList)
        {
            if (r.RoomNumber == room)
            {
                r.IsAvail = false;

                // Standard Room Is Selected
                if (r is StandardRoom)
                {
                    // Prompt User For WiFi Requirement
                    Console.Write("Do You Require Wi-Fi [Y/N]: ");

                    // Read The Input As String
                    string wifi = Console.ReadLine();

                    // WiFi Is Needed
                    if (wifi == "Y")
                    {
                        ((StandardRoom)r).RequireWifi = true;
                    }

                    // WiFi Is Not Needed
                    else if (wifi == "N")
                    {
                        ((StandardRoom)r).RequireWifi = false;
                    }

                    // Validations For WiFi Requirement
                    else
                    {
                        Console.WriteLine("Invalid Option! Please Try Again!");
                        break;
                    }


                    // Prompt User For Breakfast Requirement
                    Console.Write("Do You Require Breakfast [Y/N]: ");

                    // Read The Input As String
                    string brkfast = Console.ReadLine();

                    // Breakfast Is Needed
                    if (brkfast == "Y")
                    {
                        ((StandardRoom)r).RequireBreakfast = true;
                    }

                    // Breakfast Is Not Needed
                    else if (brkfast == "N")
                    {
                        ((StandardRoom)r).RequireBreakfast = false;
                    }

                    // Validations For Breakfast Requirement
                    else
                    {
                        Console.WriteLine("Invalid Option! Please Try Again!)");
                        break;
                    }
                }

                // Deluxe Room IS Selected
                if (r is DeluxeRoom)
                {
                    // Prompt User For Additional Bed Requirement
                    Console.Write("Do You Require An Additional Bed [Y/N]: ");

                    // Read The Input As String
                    string additionalbed = Console.ReadLine();

                    // Additional Bed Is Needed
                    if (additionalbed == "Y")
                    {
                        ((DeluxeRoom)r).additionalBed = true;
                    }

                    // Additional Bed Is Not Needed
                    else if (additionalbed == "N")
                    {
                        ((DeluxeRoom)r).additionalBed = false;
                    }

                    // Validations For Additional Bed Requirement
                    else
                    {
                        Console.WriteLine("Invalid Option! Please Try Again!)");
                        break;
                    }
                }

                // Add Room Object To Stay
                stay.AddRoom(r);

                roomadded = true;

                break;
            }
        }

        if (roomadded == true)
        {
            // Prompt User For Additional Room Requirement
            Console.Write("Would You Like An Additional Room [Y/N]: ");

            // Read The Input As String
            string additionalroom = Console.ReadLine();

            // Additional Room Is Not Needed
            if (additionalroom != "Y")
            {
                break;
            }
        }

        /*
        // Validations For Input
        else
        {
            Console.Write("Please Enter A Valid Number!");
        }
        */
    }

    // Assign Stay Object To Guest
    guest.HotelStay = stay;

    // Update Check In Status
    guest.IsCheckedIn = true;

    Console.WriteLine("Guest Is Checked In!");


}

// Option 5
void DisplayStayDetails(List<Guest> guestList)
{
    // Call The Display Guest Method
    DisplayGuest(guestList);

    Console.WriteLine();

    // Prompt User To Select Guest
    Console.Write("Enter Guest Name: ");

    // Read The Input As String
    string guestFind = Console.ReadLine();

    foreach (Guest g in guestList)
    {
        if (g.Name == guestFind)
        {
            Console.WriteLine("These Are The Details Of {0}.", g.Name);
            Console.WriteLine("===================================");

            // ChecK If There Are Details In Stay
            if (g.HotelStay != null)
            {
                Console.WriteLine("{0,-20}{1,-25}{2,-30}{3,-30}", "Name", "Passport Number", "Check In", "Check Out");
                Console.WriteLine("{0,-20}{1,-25}{2,-30}{3,-30}", g.Name, g.PassportNum, g.HotelStay.CheckInDate, g.HotelStay.CheckOutDate);
                Console.WriteLine("Rooms");

                foreach (Room room in g.HotelStay.RoomList)
                {
                    Console.WriteLine(room);
                }
                break;
            }

            // Validations For No Details In Stay
            else
            {
                Console.WriteLine("No Hotel Stay Records!");
                break;
            }
        }
    }
}

// Option 6
void ExtendStay(List<Guest> guestList)
{
    // Call The Display Guest Method
    DisplayGuest(guestList);

    // Prompt User To Select Guest
    Console.Write("Select A Guest: ");

    // Read The Input As String
    string selectedg = Console.ReadLine();

    // Checking If Guest Is Checked In
    foreach (Guest g in guestList)
    {
        if (g.Name == selectedg)
        {
            // Guest Is Checked In
            if (g.HotelStay != null && g.IsCheckedIn == true)
            {
                // Prompt User For Days To Extend
                Console.WriteLine("How Many Days Do You Want To Extend?: ");

                // Read The Input As Integer
                int extend = int.Parse(Console.ReadLine());

                g.HotelStay.CheckOutDate += TimeSpan.FromDays(extend);
                Console.WriteLine("Updated!");
                break;
            }

            // Guest Is Not Checked In
            else
            {
                Console.WriteLine("Guest Is Not Checked In!");
                break;
            }
        }
    }
}

// Option 7 (Advanced)
void DisplayMonthlyAmount()
{
    // Prompt User For Year
    Console.WriteLine("Enter the Year: ");

    // Read The Input As Integer
    int year = int.Parse(Console.ReadLine());

    double jan = 0.0;
    double feb = 0.0;
    double mar = 0.0;
    double apr = 0.0;
    double jun = 0.0;
    double jul = 0.0;
    double may = 0.0;
    double sep = 0.0;
    double oct = 0.0;
    double aug = 0.0;
    double nov = 0.0;
    double dec = 0.0;

    double total = 0.0;

    foreach (Stay stay in stayList)
    {
        if (stay.CheckOutDate.Year == year)
        {
            if (stay.CheckOutDate.Month == 1)
            {
                jan += stay.CalculateTotal();
                total += stay.CalculateTotal();
            }

            if (stay.CheckOutDate.Month == 2)
            {
                feb += stay.CalculateTotal();
                total += stay.CalculateTotal();
            }

            if (stay.CheckOutDate.Month == 3)
            {
                mar += stay.CalculateTotal();
                total += stay.CalculateTotal();
            }

            if (stay.CheckOutDate.Month == 4)
            {
                apr += stay.CalculateTotal();
                total += stay.CalculateTotal();
            }

            if (stay.CheckOutDate.Month == 5)
            {
                may += stay.CalculateTotal();
                total += stay.CalculateTotal();
            }

            if (stay.CheckOutDate.Month == 6)
            {
                jun += stay.CalculateTotal();
                total += stay.CalculateTotal();
            }

            if (stay.CheckOutDate.Month == 7)
            {
                jul += stay.CalculateTotal();
                total += stay.CalculateTotal();
            }

            if (stay.CheckOutDate.Month == 8)
            {
                aug += stay.CalculateTotal();
                total += stay.CalculateTotal();
            }

            if (stay.CheckOutDate.Month == 9)
            {
                sep += stay.CalculateTotal();
                total += stay.CalculateTotal();
            }

            if (stay.CheckOutDate.Month == 10)
            {
                oct += stay.CalculateTotal();
                total += stay.CalculateTotal();
            }

            if (stay.CheckOutDate.Month == 11)
            {
                nov += stay.CalculateTotal();
                total += stay.CalculateTotal();
            }

            if (stay.CheckOutDate.Month == 12)
            {
                dec += stay.CalculateTotal();
                total += stay.CalculateTotal();
            }
        }
    }

    Console.WriteLine("Jan 2022: $" + jan + "\r\nFeb 2022: $" + feb + "\r\nMar 2022: $" + mar + "\r\nApr 2022: $" + apr + "\r\nMay 2022: $" + may + "\r\nJun 2022: $" + jun + "\r\nJul 2022: $" + jul + "\r\nAug 2022: $" + aug + "\r\nSep 2022: $" + sep + "\r\nOct 2022: $" + oct + "\r\nNov 2022: $" + nov + "\r\nDec 2022: $" + dec);
    Console.WriteLine("\nTotal: $" + total);
}

// Option 8 (Advanced)
void CheckOutGuest(List<Guest> guestList)
{
    // Call The Display Guest Method
    DisplayGuest(guestList);

    //Prompt User To Select Guest
    Console.Write("Guest Name: ");

    //Read The Input As String
    string name = Console.ReadLine();



    foreach (Guest guest in guestList)
    {
        if (guest.Name == name)
        {
            Console.WriteLine("Membership Status \t Membership Points");
            Console.Write(guest.Member.Status + "\t \t \t ");
            Console.Write(guest.Member.Points + "\t \t \t ");

            double total = guest.HotelStay.CalculateTotal();

            // Check Membership Status
            if (guest.Member.Status == "Ordinary")
            {
                Console.WriteLine("\nYou Can't Reedem Points!");
            }

            else
            {
                // Prompt User For Number Of Points To Offset
                Console.Write("No. Of Points To Offset: ");

                // Read The Input As Integer
                int points = int.Parse(Console.ReadLine());

                if (guest.Member.RedeemPoints(points))
                {
                    total -= points;

                }
            }

            foreach (Room room in roomList)
            {


                TimeSpan duration = guest.HotelStay.CheckOutDate - guest.HotelStay.CheckInDate;

                if (guest.HotelStay.RoomList.Count > 1)
                {
                    double total2 = 0;


                    for (int i = 1; i < guest.HotelStay.RoomList.Count; i++)
                    {
                        foreach (Room r in roomList)
                        {
                            total2 += (r.DailyRate * duration.Days) + r.CalculateCharges();
                            total = guest.HotelStay.CalculateTotal() + total2;
                            Console.WriteLine("Total payable: " + total);
                            break;
                        }
                    }

                }

                else
                {
                    Console.WriteLine("Total payable: " + total);
                    break;
                }
                break;
            }
            // Prompt User To Make Payment
            Console.WriteLine("Press Any Key To Make Payment...");
            Console.ReadKey();

            // Earn Points
            guest.Member.EarnPoints(total / 10);
            Console.Write("\nUpdated Points: " + guest.Member.Points + "\t");

            // Update Membership Status According To Points Earned
            if (guest.Member.Points > 100)
            {
                guest.Member = new Membership("Silver", guest.Member.Points);
                Console.Write("Updated Membership: " + guest.Member.Status, guest.Member.Points);
            }

            if (guest.Member.Points > 200)
            {
                guest.Member = new Membership("Gold", guest.Member.Points);
                Console.Write("Updated Membership: " + guest.Member.Status, guest.Member.Points);
            }

            else
            {
                Console.Write("Updated Membership: " + guest.Member.Status, guest.Member.Points);
            }

            // Update Check Out Status
            guest.IsCheckedIn = false;

            foreach (Room room in roomList)
            {
                guest.HotelStay.RoomList.Remove(room);
            }


            break;
        }
    }
}

// Main Program Loop
while (true)
{
    try
    {
        // Call The Display Menu Method
        DisplayMenu();

        // Read The Input As Integer
        int option = int.Parse(Console.ReadLine());
        Console.WriteLine();

        // Option 1: Natalie
        if (option == 1)
        {
            // Call The Display Guest Method
            DisplayGuest(guestList);
        }

        // Option 2: Daphne
        else if (option == 2)
        {
            // Call The Display Room Method
            DisplayRoom(roomList);
        }

        // Option 3: Natalie
        else if (option == 3)
        {
            // call The Register Guest Method
            RegisterGuest(guestList);
        }

        // Option 4: Daphne
        else if (option == 4)
        {
            // Call The Check In Method
            Checkin(guestList);
        }

        // Option 5:Natalie
        else if (option == 5)
        {
            // Call The Display Stay Details Method
            DisplayStayDetails(guestList);
        }

        // Option 6:Daphne
        else if (option == 6)
        {
            // Call The Extend Stay Method
            ExtendStay(guestList);
        }

        // Option 7 (Advanced):Natalie
        else if (option == 7)
        {
            // Call The Display Monthly Amount Method
            DisplayMonthlyAmount();
        }

        // Option 8 (Advanced):Natalie
        else if (option == 8)
        {
            // Call The Check Out Method
            CheckOutGuest(guestList);
        }

        // Exit
        else if (option == 0)
        {
            Console.WriteLine("---------");
            Console.WriteLine("Goodbye!");
            Console.WriteLine("---------");

            // Exit The Program
            break;
        }

        // Validations For Input
        else
        {
            Console.WriteLine("Invalid Option! Please Try Again!");
        }
    }

    // Validations For Menu Input
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Please Try Again!");
    }
}