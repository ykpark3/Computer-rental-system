using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{

    // 컴퓨터와 사용자 관리를 위한 메소드들
    class ComputerManager
    {
        private Computer[] arrComp;
        private User[] arrUser;

        private int count = 0;

        // computer에 관한 개수
        private int computerArrayIndex = 0, numberOfComputers = 0, numberOfNetbooks = 0, numberOfNotebooks = 0, numberOfDesktops = 0;
        // user에 관한 개수
        private int userArrayIndex = 0, numberOfUsers = 0, numberOfStudents = 0, numberOfGamers = 0, numberOfWorkers = 0;

        private int computerIndex = 0;

        private int totalCost = 0;  // 총 요금 

        private string[] writeLine = new string[5];

        // computer 배열 값 추가하기
        public void SetComputerArray(int tmpComputers, int tmpNetbooks, int tmpNotebooks, int tmpDesktops)
        {
            numberOfComputers = tmpComputers;
            numberOfNetbooks = tmpNetbooks;
            numberOfNotebooks = tmpNotebooks;
            numberOfDesktops = tmpDesktops;

            arrComp = new Computer[numberOfComputers];

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

        // user 배열 값 추가하기
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

        // A: 컴퓨터를 사용자에게 할당하는 메소드
        public string[] AssignComputerToUser(int userId, int requestedDays)
        {
            if (arrUser[userId - 1].Type.Contains("Students"))
            {
                computerIndex = Array.FindIndex(arrComp, element
                => (element.Type == "Notebook" && element.Available.Contains("Y"))
                || (element.Type == "Desktop" && element.Available.Contains("Y")));
            }

            else if (arrUser[userId - 1].Type.Contains("Gamers"))
            {
                computerIndex = Array.FindIndex(arrComp, element 
                    => (element.Type == "Desktop" && element.Available.Contains("Y")));
            }
            else
            {   // workers
                computerIndex = Array.FindIndex(arrComp, element => element.Available.Contains("Y"));
            }

            // arrUser 대여 중으로 변경
            arrUser[userId - 1].Rent = "Y";
            arrUser[userId - 1].RentComputerId = computerIndex + 1;

            // arrComp 대여 중으로 변경
            arrComp[computerIndex].Available = "N";
            arrComp[computerIndex].RentedUserId = userId;
            arrComp[computerIndex].DaysRequested = requestedDays;
            arrComp[computerIndex].DaysLeft = requestedDays;
            arrComp[computerIndex].DaysUsed = 0;

            writeLine[0] = $"Computer #{arrComp[computerIndex].ComId} " +
                $"has been assigned to User #{arrUser[userId - 1].UserId}" + "\n";

            writeLine[0] += "===========================================================";

            return writeLine;
        }

        // R: 컴퓨터를 반납
        public string[] ReturnComputer(int userId, char command)
        {
            computerIndex = Array.FindIndex(arrComp, element
                => element.RentedUserId.Equals(userId));

            totalCost += (arrComp[computerIndex].price * arrComp[computerIndex].DaysUsed);

            // user 대여 중 아닌 것으로 바꾸기
            arrUser[userId - 1].Rent = "N";
            arrUser[userId - 1].RentComputerId = 0;

            // computer 대여 중 아닌 것으로 바꾸기
            arrComp[computerIndex].Available = "Y";
            arrComp[computerIndex].RentedUserId = 0;
            arrComp[computerIndex].DaysRequested = 0;
            arrComp[computerIndex].DaysLeft = 0;
            arrComp[computerIndex].DaysUsed = 0;

            // R 명령어로 반납하는 경우
            if (command.Equals('R'))
            {
                writeLine[0] =
                    $"User #{arrUser[userId - 1].UserId} has returned " +
                    $"Computer #{arrUser[userId - 1].RentComputerId} and paid {totalCost} won.";

                writeLine[0] += "\n" + "===========================================================";

                return writeLine;
            }
        }

        // T: 하루 시간 경과하는 메소드
        public string[] PassOneDay()
        { 
            writeLine[0] = "It has passed one day...";
          
            for (count = 0; count <numberOfComputers; count++)
            {
                if (arrComp[count].Available.Contains("N")) // 대여 중인 컴퓨터인 경우
                {
                    arrComp[count].DaysLeft -= 1;   // 남은 대여일 수 1 감소
                    arrComp[count].DaysUsed += 1;   // 사용한 일 수 1 증가

                    if (arrComp[count].DaysLeft <= 0)    // 남은 대여일 수가 없는 경우
                    {
                        writeLine[0] += "\n" +
                            $"Time for Computer #{arrComp[count].ComId} has expired. " +
                            $"User #{arrComp[count].RentedUserId} has returned " +
                            $"Computer #{arrComp[count].ComId} " +
                            $"and paid {arrComp[count].price * arrComp[count].DaysUsed} won.";

                        ReturnComputer(arrComp[count].RentedUserId, 'T');    // 반납
                    }
                }                
            }

            writeLine[0] += "\n" + "===========================================================";
            return writeLine;            
        }

        // S: 현재 총 지불된 금액, 각 컴퓨터의 대여 상황, 사용자의 현재 상황 정보
        public string[] PrintComputerAndUser()
        {
            writeLine[0] = $"Total Cost: {totalCost}" + "\n";

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

                // 대여 불가능한 경우
                if (arrComp[count].Available.Contains("N"))
                {
                    writeLine[0] +=
                        $"(UserId: {arrComp[count].RentedUserId}, " +
                        $"DR: {arrComp[count].DaysRequested}, " +
                        $"DL: {arrComp[count].DaysLeft}, " +
                        $"DU: {arrComp[count].DaysUsed})" + "\n";
                }
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

                // 대여 중인 경우
                if (arrUser[count].Rent.Contains("Y"))
                {
                    writeLine[1] +=
                        $"(RentCompId: {arrUser[count].RentComputerId})" + "\n";
                }
            }

            writeLine[2] = "===========================================================";

            return writeLine;
        }

    }
}