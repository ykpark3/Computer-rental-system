using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Gamers: User
    {
        // 생성자
        public Gamers(int userId) : base(userId)
        {
            Type = "Gamers";
            UsedFor = new string[] { "internet", "game" };
        }

        public int GamerId { get; set; }  // gamer 아이디
    }
}
