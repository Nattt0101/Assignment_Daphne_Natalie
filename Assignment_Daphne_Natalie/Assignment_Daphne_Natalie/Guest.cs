using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Daphne_Natalie
{
    class Guest
    {
        public string Name { get; set; }

        public string PassportNum { get; set; }

        public Stay HotelStay { get;set; }

        public Membership Member { get; set; }  

        public bool IsCheckedIn { get; set; }

        public Guest()
        {

        }

        public Guest(string n, string p, Stay h, Membership m)
        {
            Name = n;
            PassportNum = p;
            HotelStay = h;
            Member = m;
        }

        public override string ToString()
        {
            return "Name: " + Name + "PassportNum: " + PassportNum + "HotelStay: " + HotelStay + "Membership: " + Member;
        }
    }
}
