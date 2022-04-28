using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Desktop : Computer
    {
        public Desktop(int computerId) : base(computerId)
        {
            Type = "Desktop";

            UsedFor = new string[] { "Internet", "Scientific", "Game" };
            price = 13000;
        }

        public int DesktopId { get; set; }  // desktop 아이디

    }
}
