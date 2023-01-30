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
    class StandardRoom : Room
    {
        public bool RequireWifi { get; set; }
        public bool RequireBreakfast { get; set; }

        public StandardRoom() : base()
        {

        }

        public StandardRoom(int r, string b, double d, bool a):base(r, b, d, a)
        {

        }

        public override double CalculateCharges()
        {
            return 0.0;
        }

        public override string ToString()
        {
            return base.ToString()
                + " RequireWifi: " + RequireWifi + " Require BreakFast: " + RequireBreakfast;
        }
    }
}
