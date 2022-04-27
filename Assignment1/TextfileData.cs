using System;
using System.IO;

namespace Assignment1
{
    class TextfileData
    {
        public void SetTextfile()
        {
            StreamReader sr = new StreamReader(@"..\..\input.txt");
            StreamWriter sw = new StreamWriter(@"..\..\output2.txt");

            string tmpreadline;


            //while (sr.Peek() >= 0){ // 입력 파일에 더 이상 읽을 문자가 없을 때 까지 실행 
            for (int i = 1; sr.Peek() >= 0; i++)
            {
                tmpreadline = sr.ReadLine(); // 입력파일에 한 줄의 문자열을 읽어와 string 변수에 tmpreadline 할당

                if(i == 1)
                {
                    // 컴퓨터 수에 따라 컴퓨터 초기화
                }




                sw.WriteLine(tmpreadline);   // tmpreadline를 출력파일에 쓰기
            }
            sr.Close();
            sw.Close();
        }
        
    }
}
