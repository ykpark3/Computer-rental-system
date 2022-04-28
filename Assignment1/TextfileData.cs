using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment1
{
    class TextfileData
    {
        ComputerManager computerManager;

        public static List<Students> Students = new List<Students>();
        public static List<Gamers> Gamers = new List<Gamers>();
        public static List<Workers> Workers = new List<Workers>();
        
        string tmpreadline; // 입력 파일 한 줄씩 읽기

        // 컴퓨터 수
        private int numberOfComputers;
        private int numberOfNotebooks, numberOfDesktops, numberOfNetbooks;

        // 사용자 수
        private int numberOfUsers;

        private string[] userInput;

        // 현재 가리키는 순서
        private int fileLineCount = 0;

        // 생성자
        public TextfileData()
        {
            computerManager = new ComputerManager();
        }

        public void SetTextfile()
        {
            StreamReader sr = new StreamReader(@"..\..\input.txt");
            StreamWriter sw = new StreamWriter(@"..\..\output2.txt");


            //while (sr.Peek() >= 0){ // 입력 파일에 더 이상 읽을 문자가 없을 때 까지 실행 
            for (fileLineCount = 1; sr.Peek() >= 0; fileLineCount++)
            {
                tmpreadline = sr.ReadLine(); // 입력파일에 한 줄의 문자열을 읽어와 string 변수에 tmpreadline 할당

                // 총 컴퓨터의 수
                if(fileLineCount == 1)
                {
                    numberOfComputers = Convert.ToInt32(tmpreadline);
                }

                // 노트북, 데스크톱, 넷북 수
                else if (fileLineCount == 2)
                {
                    userInput = tmpreadline.Split(' '); // 공백을 기준으로 개수 자르기

                    numberOfNotebooks = Convert.ToInt32(userInput[0]);
                    numberOfDesktops = Convert.ToInt32(userInput[1]);
                    numberOfNetbooks = Convert.ToInt32(userInput[2]);

                    // 컴퓨터 수에 따라 컴퓨터 초기화
                    computerManager.SetComputerArray(numberOfComputers,numberOfNetbooks, numberOfNotebooks, numberOfDesktops);

                }

                // 사용자의 수
                else if (fileLineCount == 3)
                {
                    numberOfUsers = Convert.ToInt32(tmpreadline);
                    computerManager.InitializeUserArray(numberOfUsers);
                }

                // 사용자 추가
                else if(fileLineCount >= 4 && fileLineCount < 4 + numberOfUsers)
                {
                    userInput = tmpreadline.Split(' '); // 공백을 기준으로 개수 자르기

                    computerManager.SetUserArray(userInput[0], userInput[1]);

                    if(fileLineCount == 4 + numberOfUsers - 1)
                    {
                        computerManager.TestPrint();
                    }
                }

                else
                {
                    if (tmpreadline.StartsWith("A"))   // 사용자에게 요구한 일 수 만큼 대여
                    {
                        computerManager.AssignComputerToUser();
                    }
                    else if (tmpreadline.StartsWith("R")) // 사용자의 컴퓨터 반납
                    {
                        computerManager.ReturnComputer();
                    }
                    else if (tmpreadline.Equals("T")) // 하루의 시간이 경과
                    {
                        computerManager.PassOneDay();
                    }
                    else if (tmpreadline.Equals("S")) // 총 지불금액, 컴퓨터 리스트, 사용자 리스트 상태 표시
                    {
                        computerManager.PrintComputerAndUser();
                    }

                    // Q: 프로그램 종료
                    else
                    {

                    }
                }

                sw.WriteLine(tmpreadline);   // tmpreadline를 출력파일에 쓰기
            }
            sr.Close();
            sw.Close();
        }
        
    }
}
