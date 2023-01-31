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
    class Membership : Guest
    {
        public string Status { get; set; }

        public int Points { get; set; }

        public Membership()
        {

        }

        public Membership(string s, int p)
        {
            Status = s;
            Points = p;
        }

        public void EarnPoints(double points)
        {
            Points = Points + (int)(points);
        }

        public bool RedeemPoints(int p)
        {
            if (Points < p || p < 0)
            {
                return false;
            }
            else
            {
                Points -= p;
                return true;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "Status: " + Status + "Points: " + Points;
        }
    }
}