using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class User
    {
        // 생성자
        public User(int userId)
        {
            UserId = userId;
        }

        public string Type { get; set; }    // 타입
        public string Name { get; set; }    //이름
        public int UserId { get; set; }  // 사용자 아이디
        public int TypeId { get; set; } // 타입 아이디
        public string[] UsedFor { get; set; }   // 제공 서비스
        public string Rent { get; set; } = "N";  // 대여 여부
        public int RentComputerId { get; set; } = 0;    // 대여한 컴퓨터 아이디
    }
}
