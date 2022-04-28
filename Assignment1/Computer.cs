using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Computer
    {
        // 생성자
        public Computer(int computerId)
        {
            ComId = computerId;            
        }

        public string Type { get; set; }    // 타입
        public int ComId { get; set; }  // 컴퓨터 아이디
        public int TypeId { get; set; } // 타입 아이디
        public string[] UsedFor { get; set; }   // 제공 서비스
        public int price { get; set; }  // 요금
        public string Available { get; set; } = "Y";  // 대여 가능 여부
        public int DaysRequested { get; set; } = 0;  // 사용자가 컴퓨터를 대여할 때 요구한 일 수
        public int DaysLeft { get; set; } = 0;  // 남은 대여일 수
        public int DaysUsed { get; set; } = 0;  // 사용한 일 수

    }
}
