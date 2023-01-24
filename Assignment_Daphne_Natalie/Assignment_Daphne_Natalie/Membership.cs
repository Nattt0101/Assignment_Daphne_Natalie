using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }

        public bool RedeemPoints(int p)
        {
            if (p>=100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "Status: " + Status + "Points: " + Points;
        }
    }