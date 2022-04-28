using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class ComputerManager
    {
        private Computer[] arrComp;
        private User[] arrUser;

        private int count = 0;
        private int computerArrayIndex = 0, numberOfNetbooks, numberOfNotebooks, numberOfDesktops;
        private int userArrayIndex = 0, numberOfStudents = 0, numberOfGamers = 0, numberOfWorkers = 0;

        private int totalCost = 0;


        public void SetComputerArray(int numberOfComputers, int tmpNetbooks, int tmpNotebooks, int tmpDesktops)
        {
            numberOfNetbooks = tmpNetbooks;
            numberOfNotebooks = tmpNotebooks;
            numberOfDesktops = tmpDesktops;

            arrComp = new Computer[numberOfComputers];

            /*
            for (computerArrayIndex = 0; computerArrayIndex < numberOfComputers; computerArrayIndex++)
            {
                arrComp[computerArrayIndex] = new Computer(computerArrayIndex + 1);
            }
            */

            // netbook 초기화
            for (count = 1; count <= numberOfNetbooks; count++)
            {
                computerArrayIndex = count - 1;

                arrComp[computerArrayIndex] = new Netbook(count);
                Netbook newNetbook = arrComp[computerArrayIndex] as Netbook;

                newNetbook.NetbookId = count;

                /*
                Netbook newNetbook = new Netbook(count);
                newNetbook.NetbookId = count;

                arrComp[computerArrayIndex] = newNetbook;
                */

            }

            // notebook 초기화
            for (count = 1; count <= numberOfNotebooks; count++)
            {
                computerArrayIndex = numberOfComputers - numberOfNotebooks - numberOfDesktops + count - 1;

                Notebook newNotebook = new Notebook(computerArrayIndex + 1);
                newNotebook.NotebookId = count;
        
                arrComp[computerArrayIndex] = newNotebook;
            }

            // desktop 초기화
            for (count = 1; count <= numberOfDesktops; count++)
            {
                computerArrayIndex = numberOfComputers - numberOfDesktops + count - 1;

                Desktop newDesktop = new Desktop(computerArrayIndex + 1);
                newDesktop.DesktopId = count;

                arrComp[computerArrayIndex] = newDesktop;
            }

            computerArrayIndex += 1;

        }

        // user 배열 초기화
        public void InitializeUserArray(int numberOfUsers)
        {
            arrUser = new User[numberOfUsers];

            for (userArrayIndex = 0; userArrayIndex < numberOfUsers; userArrayIndex++)
            {
                arrUser[userArrayIndex] = new User(userArrayIndex + 1);
            }

            userArrayIndex = 0;
        }

        public void SetUserArray(string userType, string userName)
        {
            // student 추가
            if (userType.Contains("Student"))
            {
                Students newStudent = new Students(userArrayIndex + 1)
                {
                    Name = userName,
                    StudentId = numberOfStudents
                };

                numberOfStudents++;

                arrUser[userArrayIndex] = newStudent;

            }

            // gamer 추가
            else if (userType.Contains("Gamer"))
            {
                Gamers newGamer = new Gamers(userArrayIndex + 1);

                numberOfGamers++;

                newGamer.Name = userName;
                newGamer.GamerId = numberOfGamers;

                arrUser[userArrayIndex] = newGamer;
            }

            // worker 추가
            else if (userType.Contains("Worker"))
            {
                Workers newWorker = new Workers(userArrayIndex + 1);

                numberOfWorkers++;

                newWorker.Name = userName;
                newWorker.WorkderId = numberOfWorkers;

                arrUser[userArrayIndex] = newWorker;
            }

            userArrayIndex++;
        }

        public void TestPrint()
        {

            Console.WriteLine("computerIndex = "+ computerArrayIndex);
            Console.WriteLine("userIndex = "+ userArrayIndex);

            for (count = 0; count < computerArrayIndex; count++)
            {
                Console.WriteLine(arrComp[count].ComId);
            }

            for (count = 0; count < userArrayIndex; count++)
            {
                Console.WriteLine(arrUser[count].Name);
            }
        }

        // A: 컴퓨터를 사용자에게 할당하는 메소드
        public void AssignComputerToUser()
        {

        }

        // R: 컴퓨터를 반납
        public void ReturnComputer()
        {

        }

        // T: 하루 시간 경과하는 메소드
        public void PassOneDay()
        {

        }

        // S: 현재 총 지불된 금액, 각 컴퓨터의 대여 상황, 사용자의 현재 상황 정보
        public void PrintComputerAndUser()
        {
            Console.WriteLine($"Total Cost: {totalCost}");

            // computer list 출력
            Console.WriteLine("Computer List:");
            for (count = 0; count < computerArrayIndex; count++)
            {
                Console.WriteLine($"({count + 1}), " +
                    $"type: {arrComp[count].Type}, " +
                    $"ComId: {arrComp[count].ComId}, " +
                    // $"NetId: {arrComp[count]." +
                    $"");
            }
            
            // user list 출력

        }

        // 컴퓨터와 사용자 관리를 위한 메소드
    }
}