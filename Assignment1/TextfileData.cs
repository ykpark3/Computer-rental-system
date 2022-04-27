using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment1
{
    class TextfileData
    {

        public static List<Netbook> Netbooks = new List<Netbook>();
        public static List<Notebook> Notebooks = new List<Notebook>();
        public static List<Desktop> Desktops = new List<Desktop>();

        private int numberOfComputers, numberOfNotebooks, numberOfDesktops, numberOfNetbooks;

        // 생성자
        public TextfileData()
        {
        }

        public void SetTextfile()
        {
            StreamReader sr = new StreamReader(@"..\..\input.txt");
            StreamWriter sw = new StreamWriter(@"..\..\output2.txt");

            string tmpreadline;
            bool isSucceededConvertingNumber;
            string[] computerNumber;

            int fileLineCount = 0, computerNumberCount = 0;

            //while (sr.Peek() >= 0){ // 입력 파일에 더 이상 읽을 문자가 없을 때 까지 실행 
            for (fileLineCount = 1; sr.Peek() >= 0; fileLineCount++)
            {
                tmpreadline = sr.ReadLine(); // 입력파일에 한 줄의 문자열을 읽어와 string 변수에 tmpreadline 할당

                // 총 컴퓨터의 수
                if(fileLineCount == 1)
                {
                    isSucceededConvertingNumber = int.TryParse(tmpreadline, out numberOfComputers);

                    // 입력값 숫자 아님 -> 숫자 아니면 계속 입력받도록 해야 하는데 파일로 입력 받으니까 사실 필요 X
                    if(!isSucceededConvertingNumber)
                    {
                        Console.WriteLine("총 컴퓨터 수를 숫자로 입력해주세요.");
                    }
                }

                // 노트북, 데스크톱, 넷북 수
                else if (fileLineCount == 2)
                {
                    computerNumber = tmpreadline.Split(' '); // 공백을 기준으로 개수 자르기

                    numberOfNotebooks = Convert.ToInt32(computerNumber[0]);
                    numberOfDesktops = Convert.ToInt32(computerNumber[1]);
                    numberOfNetbooks = Convert.ToInt32(computerNumber[2]);

                    // 컴퓨터 수에 따라 컴퓨터 초기화


                    // netbook 초기화
                    for (computerNumberCount = 0; computerNumberCount < numberOfNetbooks; computerNumberCount++)
                    {
                        Netbook newNetbook = new Netbook(computerNumberCount + 1);
                        newNetbook.NetbookId = computerNumberCount + 1;

                        Netbooks.Add(newNetbook);
                    }

                    // notebook 초기화
                    for (computerNumberCount = 0; computerNumberCount < numberOfNotebooks; computerNumberCount++)
                    {
                        Notebook newNotebook = new Notebook(numberOfComputers - numberOfNetbooks - 1 + computerNumberCount);
                        newNotebook.NotebookId = computerNumberCount + 1;

                        Notebooks.Add(newNotebook);                    
                    }

                    // desktop 초기화
                    for (computerNumberCount = 0; computerNumberCount < numberOfDesktops; computerNumberCount++)
                    {
                        Desktop newDesktop = new Desktop(numberOfComputers - numberOfNetbooks - numberOfNotebooks - 1 + computerNumberCount);
                        newDesktop.DesktopId = computerNumberCount + 1;

                        Desktops.Add(newDesktop);
                    }

                }

                // 사용자의 수
                else if (fileLineCount == 3)
                {

                }


                sw.WriteLine(tmpreadline);   // tmpreadline를 출력파일에 쓰기
            }
            sr.Close();
            sw.Close();
        }
        
    }
}
