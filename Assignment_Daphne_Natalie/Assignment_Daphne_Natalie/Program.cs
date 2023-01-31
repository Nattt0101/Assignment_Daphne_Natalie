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


    // Create New List For Guests
    List<Guest> guestList = new List<Guest>();

// Create New Dict For Rooms
List<Room> roomList = new List<Room>();

List<Stay> stayList = new List<Stay>();

//guest

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



//room
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

//stay
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

    foreach(Room room in roomList)
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
    foreach(Guest guest in guestList)
    {
        if (guest.Name == name && guest.PassportNum==passportnum)
        {
            guest.HotelStay = stay;
        }
    }

    stayList.Add(stay);
}




void DisplayMonthlyAmount()
{
    Console.WriteLine("Enter the Year: ");
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

void CheckOutGuest(List<Guest> guestList)
{
    /*prompt user to select a guest and retrieve the selected guest
 display the total bill amount
 display the membership status & points
 check membership status to determine if the guest can redeem points
 prompt user for the number of points to offset the total bill amount
 redeem points
 display the final total bill amount
 prompt user to press any key to make payment
 earn points (guest.member.earnpoints(total/10))
 while earning points, the member status will be upgraded accordingly.(guest.member.status)
 update check out status of the guest (guest.Ischeckedin=false)
    */

    DisplayGuest(guestList);

    Console.Write("Guest Name: ");
    string name = Console.ReadLine();
    
    foreach (Guest guest in guestList)
    {
        if (guest.Name == name)
        {
            Console.WriteLine("Membership Status \t Membership Points \t Total Fee");
            Console.Write(guest.Member.Status + "\t \t \t ");
            Console.Write(guest.Member.Points + "\t \t \t ");
            Console.WriteLine(guest.HotelStay.CalculateTotal() + "\n");
            double total= guest.HotelStay.CalculateTotal();

            if (guest.Member.Status == "Ordinary")
            {
                Console.WriteLine("You can't reedem points");
            }
            else
            {
                Console.Write("No. of points to offset: ");
                int points = int.Parse(Console.ReadLine()); 
                if (guest.Member.RedeemPoints(points))
                {
                    total -= points;
                }
            }
            Console.WriteLine(total);
            Console.WriteLine("Press any key to make payment...");
            Console.ReadKey();

            guest.Member.EarnPoints(total / 10);
            Console.Write("\n Updated Points: "+ guest.Member.Points);
            if (guest.Member.Points > 100)
            {
                guest.Member = new Membership("Silver", guest.Member.Points);
                Console.Write("Updated Membership: " + guest.Member.Status, guest.Member.Points);
            }
            if(guest.Member.Points >200)
            {
                guest.Member = new Membership("Gold", guest.Member.Points);
                Console.Write("Updated Membership: " + guest.Member.Status, guest.Member.Points);
            }
            else
            {
                Console.Write("Updated Membership: " + guest.Member.Status, guest.Member.Points);
            }
        }

        guest.IsCheckedIn = false;
        break;
    }
    
}

void ExtendStay(List<Guest> guestList)
{
    /*List the guests
  prompt user to select a guest and retrieve the selected guest
  check if the guest is checked in
  prompt user for the number of day to extend
  retrieve the stay object of the guest
  compute and update the check out date of the stay*/

    DisplayGuest(guestList);
    Console.Write("Select a guest: ");
    string selectedg = Console.ReadLine();
    foreach (Guest g in guestList)
    {
        if (g.Name == selectedg)
        {

            if (g.HotelStay != null && g.IsCheckedIn == true)
            {
                Console.WriteLine("How many days do you want to extend?: ");
                int extend = int.Parse(Console.ReadLine());
                g.HotelStay.CheckOutDate += TimeSpan.FromDays(extend);
                Console.WriteLine("Updated");
            }
            else
            {

                Console.WriteLine("Guest is not checked in");
            }
        }

    }
}
    //Menu
    void DisplayMenu()
    {
        Console.WriteLine("\n------------- MENU --------------");
        Console.WriteLine("[1] List all guests\r\n[2] List all available rooms\r\n[3] Register new guest\r\n[4] Check-in guest\r\n[5] Display stay details of a guest\r\n[6] Extend number of days of stay\r\n[7] Display Monthly Checked Amounts\r\n[8] Check out Guest\r\n[0] Exit");
        Console.WriteLine("---------------------------------");
        Console.Write("Enter Your Option: ");

    }

    //Option 1
    void DisplayGuest(List<Guest> guestList)
    {

        Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", "Name", "Passport Number", "Membership Status", "Membership Points");
        foreach (Guest guest in guestList)
        {
            Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", guest.Name, guest.PassportNum, guest.Member.Status, guest.Member.Points);
        }

    }

    //Option 2
    void DisplayRoom(List<Room> roomList)
    {

        Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", "RoomNumber", "BedConfiguration", "DailyRate", "Available");


        foreach (Room r in roomList)
        {
            if (r.IsAvail == true)
            {
                Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-20}", r.RoomNumber, r.BedConfiguration, r.DailyRate, r.IsAvail);

            }
        }
    }


    //Option 5
    void DisplayStayDetails(List<Guest> guestList)
    {
        DisplayGuest(guestList);

        //prompt user to select a guest and retrieve the selected guest
        Console.WriteLine();
        Console.Write("Enter Guest Name: ");
        string guestFind = Console.ReadLine();

        foreach (Guest g in guestList)
        {
            if (g.Name == guestFind)
            {
                Console.WriteLine("\n This is the Stay Details of {0}. ", g.Name);
                Console.WriteLine("===================================");

                if (g.HotelStay != null)
                {

                    Console.WriteLine("{0,-20}{1,-25}{2,-30}{3,-30}", "Name", "Passport Number", "Check In", "Check Out");
                    Console.WriteLine("{0,-20}{1,-25}{2,-30}{3,-30}", g.Name, g.PassportNum, g.HotelStay.CheckInDate, g.HotelStay.CheckOutDate);
                    Console.WriteLine("Rooms");

                    foreach (Room room in g.HotelStay.RoomList)
                    {
                        Console.WriteLine(room);
                    }
                }
                else
                {
                    Console.WriteLine("No Hotel Stay records");
                }
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
                    string name = Console.ReadLine();
                    Console.Write("Enter Your Passport Number: ");
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
                    Console.WriteLine("Guest Registered Successfully");
                    break;
                }
                break;
            }


            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again.");

            }
        }
    }




    void Checkin(List<Guest> guestList)
    {
        Guest guest = new Guest();

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
        string checkin = Console.ReadLine();

        // Prompt User For Check Out Date
        Console.Write("Enter Your Check Out Date: ");
        string checkout = Console.ReadLine();

        // Create Stay Object
        Stay stay = new Stay();
        stay.CheckInDate = DateTime.Parse(checkin);
        stay.CheckOutDate = DateTime.Parse(checkout);

        while (true)
        {

            // List Available Rooms
            DisplayRoom(roomList);
            // Prompt User To Select A Room
            Console.Write("Please Select A Room(Room Number): ");
            int room = Convert.ToInt32(Console.ReadLine());
            bool roomadded = false;

            // Retrieve Selected Room
            foreach (Room r in roomList)
            {
                if (r.RoomNumber == room)
                {

                    if (r is StandardRoom)
                    {
                        Console.Write("Do You Require Wi-Fi [Y/N]: ");
                        string wifi = Console.ReadLine();
                        if (wifi == "Y")
                        {
                            ((StandardRoom)r).RequireWifi = true;
                        }
                        else
                        {
                            ((StandardRoom)r).RequireWifi = false;
                        }
                        Console.Write("Do You Require Breakfast [Y/N]:  ");
                        string brkfast = Console.ReadLine();
                        if (brkfast == "Y")
                        {
                            ((StandardRoom)r).RequireBreakfast = true;
                        }
                        else
                        {
                            ((StandardRoom)r).RequireBreakfast = false;
                        }
                    }
                    if (r is DeluxeRoom)
                    {
                        Console.Write("Do You Require An Additional Bed [Y/N]: ");
                        string additionalbed = Console.ReadLine();
                    if (additionalbed == "Y") 
                        {
                            ((DeluxeRoom)r).additionalBed = true;
                        }
                        else
                        {
                            ((DeluxeRoom)r).additionalBed = false;
                        }
                    }
                    stay.AddRoom(r);
                    roomadded = true;
                    break;
                }


            }
            if (roomadded == true)
            {
                Console.WriteLine("Would you like an additional room [Y/N]:  ");
                string additionalroom = Console.ReadLine();
                if (additionalroom != "Y")
                {
                    break;
                }
            }
            // Validations For Room Input
            else
            {
                Console.Write("Please Enter A Valid Number!");
            }
        }
        guest.HotelStay = stay;
        guest.IsCheckedIn = true;
        Console.WriteLine("Guest Checked In");
    }

    while (true)
    {
        try
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
                RegisterGuest(guestList);
            }

            else if (option == 4)
            {
                Checkin(guestList);
            }

            else if (option == 5)
            {
                DisplayStayDetails(guestList);
            }

            else if (option == 6)
            {
                ExtendStay(guestList);
            }

            else if (option == 7)
            {
                DisplayMonthlyAmount();
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
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Please try again.");
        }

    }







