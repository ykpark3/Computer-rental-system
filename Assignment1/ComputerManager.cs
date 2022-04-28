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
        private int computerArrayIndex = 0, numberOfComputers, numberOfNetbooks, numberOfNotebooks, numberOfDesktops;
        private int userArrayIndex = 0, numberOfUsers = 0, numberOfStudents = 0, numberOfGamers = 0, numberOfWorkers = 0;

        private int totalCost = 0;

        private string[] writeLine = new string[5];


        public void SetComputerArray(int tmpComputers, int tmpNetbooks, int tmpNotebooks, int tmpDesktops)
        {
            numberOfComputers = tmpComputers;
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
                newNetbook.TypeId = newNetbook.NetbookId;

            }

            // notebook 초기화
            for (count = 1; count <= numberOfNotebooks; count++)
            {
                computerArrayIndex = numberOfComputers - numberOfNotebooks - numberOfDesktops + count - 1;

                arrComp[computerArrayIndex] = new Notebook(computerArrayIndex + 1);
                Notebook newNotebook = arrComp[computerArrayIndex] as Notebook;
                newNotebook.NotebookId = count;
                newNotebook.TypeId = newNotebook.NotebookId;
            }

            // desktop 초기화
            for (count = 1; count <= numberOfDesktops; count++)
            {
                computerArrayIndex = numberOfComputers - numberOfDesktops + count - 1;

                arrComp[computerArrayIndex] = new Desktop(computerArrayIndex + 1);
                Desktop newDesktop = arrComp[computerArrayIndex] as Desktop;
                newDesktop.DesktopId = count;
                newDesktop.TypeId = newDesktop.DesktopId;
            
            }

            computerArrayIndex += 1;

        }

        // user 배열 초기화
        public void InitializeUserArray(int tmpUsers)
        {
            numberOfUsers = tmpUsers;

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
                    StudentId = numberOfStudents,
                    TypeId = numberOfStudents
                };

                numberOfStudents++;

                arrUser[userArrayIndex] = newStudent;

            }

            // gamer 추가
            else if (userType.Contains("Gamer"))
            {
                Gamers newGamer = new Gamers(userArrayIndex + 1)
                {
                    Name = userName,
                    GamerId = numberOfGamers,
                    TypeId = numberOfGamers
                };

                numberOfGamers++;

                arrUser[userArrayIndex] = newGamer;
            }

            // worker 추가
            else if (userType.Contains("Worker"))
            {
                Workers newWorker = new Workers(userArrayIndex + 1)
                {
                    Name = userName,
                    WorkderId = numberOfWorkers,
                    TypeId = numberOfWorkers
                };

                numberOfWorkers++;

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
                Console.WriteLine(arrComp[count].TypeId);
            }

            for (count = 0; count < userArrayIndex; count++)
            {
                Console.WriteLine(arrUser[count].Name);
            }
        }

        // A: 컴퓨터를 사용자에게 할당하는 메소드
        public void AssignComputerToUser(int userId, int requestedDays)
        {
            int computerIndex = 0;

            if (arrUser[userId - 1].Type.Contains("Students"))
            {
                computerIndex = Array.FindIndex(arrComp,element => (element.Type == "Notebook")|| (element.Type == "Desktop"));
            }

            arrUser[userId - 1].Rent = "Y";

            arrComp[computerIndex].Available = "N";
            arrComp[computerIndex].RequestedUserId = userId;
            arrComp[computerIndex].DaysRequested = requestedDays;
            arrComp[computerIndex].DaysLeft = requestedDays;
            arrComp[computerIndex].DaysUsed = 0;
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
        public string[] PrintComputerAndUser()
        {
            writeLine[0] = $"Total Cost: {totalCost}" + "\n";
            //Console.WriteLine($"Total Cost: {totalCost}");

            // computer list 출력
            writeLine[0] += "Computer List:" + "\n";

            for (count = 0; count < numberOfComputers; count++)
            {
                writeLine[0] +=
                    $"({arrComp[count].ComId}) " +
                    $"type: {arrComp[count].Type}, " +
                    $"ComId: {arrComp[count].ComId}, ";

                if (arrComp[count].Type.Contains("Netbook"))
                {
                    writeLine[0] +=
                    $"NetId: {arrComp[count].TypeId}, " +
                    $"Used for: {arrComp[count].UsedFor[0]}, ";
                }
                else if (arrComp[count].Type.Contains("Notebook"))
                {
                    writeLine[0] += 
                    $"NoteId: {arrComp[count].TypeId}, " +
                    $"Used for: {arrComp[count].UsedFor[0]}, {arrComp[count].UsedFor[1]}, ";
                }
                else
                {   // desktop
                    writeLine[0] +=
                    $"DeskId: {arrComp[count].TypeId}, " +
                    $"Used for: {arrComp[count].UsedFor[0]}, {arrComp[count].UsedFor[1]}, {arrComp[count].UsedFor[2]}, ";
                }

                writeLine[0] +=
                    $"Avail: {arrComp[count].Available}" + "\n";
            }


            // user list 출력
            writeLine[1] = "User List:" + "\n";

            for (count = 0; count < numberOfUsers; count++)
            {
                writeLine[1] +=
                    $"({arrUser[count].UserId}) " +
                    $"type: {arrUser[count].Type}, " +
                    $"Name: {arrUser[count].Name}, " +
                    $"UserId: {arrUser[count].UserId}, ";

                if (arrUser[count].Type.Contains("Students"))
                {
                    writeLine[1] +=
                    $"StudId: {arrUser[count].TypeId}, " +
                    $"Used for: {arrUser[count].UsedFor[0]}, {arrUser[count].UsedFor[1]}, ";
                }
                else if (arrUser[count].Type.Contains("Gamers"))
                {
                    writeLine[1] +=
                    $"GamerId: {arrUser[count].TypeId}, " +
                    $"Used for: {arrUser[count].UsedFor[0]}, {arrUser[count].UsedFor[1]}, ";
                }
                else
                {      // workers
                    writeLine[1] +=
                    $"WorkerId: {arrUser[count].TypeId}, " +
                    $"Used for: {arrUser[count].UsedFor[0]}, ";
                }

                writeLine[1] +=
                    $"Rent: {arrUser[count].Rent}" + "\n";
            }

            writeLine[2] = "===========================================================" + "\n";

            return writeLine;
        }

        // 컴퓨터와 사용자 관리를 위한 메소드
    }
}