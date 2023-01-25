using System;
using System.Collections.Generic;
using System.Linq;
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
    class Guest
    {
        private string name;
        private string passportnum;
        private string hotelstay;
        private string member;
        private string ischeckedin;

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
