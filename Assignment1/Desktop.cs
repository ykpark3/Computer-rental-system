using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Desktop : Computer
    {
        // 생성자
        public Desktop(int computerId) : base(computerId)
        {
            Type = "Desktop";
            UsedFor = new string[] { "internet", "scientific", "game" };
            price = 13000;
        }

        public int DesktopId { get; set; }  // desktop 아이디

    }
}
