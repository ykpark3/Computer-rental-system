using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Students : User
    {
        public Students(int userId) : base(userId)
        {
            Type = "Students";
            UsedFor = new string[] { "internet", "scientific" };
        }

        public int StudentId { get; set; }  // student 아이디
    }
}
