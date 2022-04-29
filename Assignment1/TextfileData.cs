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
        
        string readLine; // 입력 파일 한 줄씩 읽기
        string[] tmpWriteLine;
        string writeLine = "";

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
                Console.WriteLine("file Line count = {0}", fileLineCount);
                readLine = sr.ReadLine(); // 입력파일에 한 줄의 문자열을 읽어와 string 변수에 tmpreadline 할당

                // 총 컴퓨터의 수
                if(fileLineCount == 1)
                {
                    numberOfComputers = Convert.ToInt32(readLine);
                }

                // 노트북, 데스크톱, 넷북 수
                else if (fileLineCount == 2)
                {
                    userInput = readLine.Split(' '); // 공백을 기준으로 개수 자르기

                    numberOfNotebooks = Convert.ToInt32(userInput[0]);
                    numberOfDesktops = Convert.ToInt32(userInput[1]);
                    numberOfNetbooks = Convert.ToInt32(userInput[2]);

                    // 컴퓨터 수에 따라 컴퓨터 초기화
                    computerManager.SetComputerArray(numberOfComputers,numberOfNetbooks, numberOfNotebooks, numberOfDesktops);

                }

                // 사용자의 수
                else if (fileLineCount == 3)
                {
                    numberOfUsers = Convert.ToInt32(readLine);
                    computerManager.InitializeUserArray(numberOfUsers);
                }

                // 사용자 추가
                else if(fileLineCount >= 4 && fileLineCount < 4 + numberOfUsers)
                {
                    userInput = readLine.Split(' '); // 공백을 기준으로 개수 자르기

                    computerManager.SetUserArray(userInput[0], userInput[1]);

                    if(fileLineCount == 4 + numberOfUsers - 1)
                    {
                       // computerManager.TestPrint();
                    }
                }

                else
                {
                    if (readLine.StartsWith("A"))   // 사용자에게 요구한 일 수 만큼 대여
                    {
                        userInput = readLine.Split(' '); // 공백을 기준으로 개수 자르기
                        tmpWriteLine = computerManager.AssignComputerToUser(Convert.ToInt32(userInput[1]), Convert.ToInt32(userInput[2]));

                        writeLine = tmpWriteLine[0];
                        sw.WriteLine(writeLine);
                    }
                    else if (readLine.StartsWith("R")) // 사용자의 컴퓨터 반납
                    {
                        userInput = readLine.Split(' '); // 공백을 기준으로 개수 자르기
                        computerManager.ReturnComputer(Convert.ToInt32(userInput[1]));
                    }
                    else if (readLine.Equals("T")) // 하루의 시간이 경과
                    {
                        tmpWriteLine = computerManager.PassOneDay();

                        writeLine = tmpWriteLine[0];
                        sw.WriteLine(writeLine);
                    }
                    else if (readLine.Equals("S")) // 총 지불금액, 컴퓨터 리스트, 사용자 리스트 상태 표시
                    {
                        tmpWriteLine = computerManager.PrintComputerAndUser();

                        writeLine = tmpWriteLine[0] + tmpWriteLine[1] + tmpWriteLine[2];
                        sw.WriteLine (writeLine);
                    }

                    // Q: 프로그램 종료
                    else
                    {

                    }
                }

                //sw.Write(writeLine);   // 출력파일에 쓰기
            }
            sr.Close();
            sw.Close();
        }
        
    }
}
