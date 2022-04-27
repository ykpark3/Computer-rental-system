using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Netbook : Computer
    {

        public Netbook(int computerId) : base(computerId)
        {
            Type = "Netbook";

            UsedFor = new string[] { "Internet" };
            price = 7000;
        }


        public int NetbookId { get; set; }  // netbook 아이디

    }
}
