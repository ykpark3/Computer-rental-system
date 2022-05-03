using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Workers : User
    {
        // 생성자
        public Workers(int userId) : base(userId)
        {
            Type = "OfficeWorkers";
            UsedFor = new string[] { "internet" };
        }

        public int WorkderId { get; set; }  // worker 아이디
    }
}
