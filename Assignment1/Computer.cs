using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Computer
    {

        public string Type { get; set; }    // 타입
        public int ComId { get; set; }  // 컴퓨터 아이디
        public string[] UsedFor { get; set; }   // 제공 서비스
        public int price { get; set; }  // 요금
        public int Available { get; set; }  // 대여 가능 여부
    }
}
