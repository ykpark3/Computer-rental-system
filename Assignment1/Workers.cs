using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Workers : User
    {
        public Workers(int userId) : base(userId)
        {
            Type = "Workers";
            UsedFor = new string[] { "Internet" };
        }

        public int WorkderId { get; set; }  // worker 아이디
    }
}
