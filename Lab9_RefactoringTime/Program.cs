using System;
using System.Collections.Generic;

namespace Lab9_RefactoringTime
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string> { "Mark", "Paul", "Maria", "Laurel", "Adrienne", "Eli" };
            List<string> hometown = new List<string> { "Arlington Heights, IL", "Grosse Pointe, MI", "Ferndale, MI", "Troy, MI", "Macomb, MI", "Armada, MI" };
            List<string> favFood = new List<string> { "pizza", "steak and potatoes", "grape leaves", "tacos!", "salmon and rice", "sushi" };
            List<string> favSport = new List<string> { "disc golf", "hockey", "basketball", "softball", "golf", "golf" };
            List<string> tvShow = new List<string> { "Game of Thrones", "Breaking Bad", "The Good Place", "The Detour", "The Office", "Rick and Morty" };
            List<string> topic = new List<string> { "Hometown", "Favorite Food", "Favorite Sport", "Favorite TV Show" };
            List<string> answers = new List<string> { "add", "learn" };

            Console.WriteLine("Welcome! Let's get to know your classmates.");
            bool again = true;
            while (again)
            {

                int choice = TryParseInput(GetInput("Would you like to add a student or learn about a student\n1.Add\n2.Learn" +
                    "\nEnter choice: ").ToLower(), answers, 0, answers.Count);

                if (choice == 0)
                {
                    AddNewInput("Please enter the students name: ", students);
                    int addIndex = students.Count - 1;
                    string studentName = students[addIndex];
                    AddNewInput($"Please enter " + studentName + "'s hometown: ", hometown);
                    AddNewInput($"Please enter " + studentName + "'s favorite food: ", favFood);
                    AddNewInput($"Please enter " + studentName + "'s favorite sport: ", favSport);
                    AddNewInput($"Please enter " + studentName + "'s favorite TV show: ", tvShow);

                }
                else if (choice == 1)
                {
                    PrintList("Which student would you like to know about?", students);
                    int studentNumber = TryParseInput(GetInput("Enter your choice: "), students, 0, students.Count);
                    if (studentNumber == -100)
                    {
                        
                        again = true;
                    }
                    else
                    {
                        PrintList($"What would you like to know about {students[studentNumber]}", topic);
                        int topicNumber = TryParseInput(GetInput("Enter your choice: "), topic, 0, topic.Count);
                        if (studentNumber == -100)
                        {
                            Console.WriteLine("Improper input");
                            again = PlayAgain("Would you like to try again?(y/n): ");
                        }
                        else
                        {
                            switch (topicNumber)
                            {
                                case 0:
                                    Console.WriteLine($"{students[studentNumber]} is from {hometown[studentNumber]}");
                                    break;
                                case 1:
                                    Console.WriteLine($"{students[studentNumber]}'s favorite food is {favFood[studentNumber]}");
                                    break;
                                case 2:
                                    Console.WriteLine($"{students[studentNumber]}'s favorite sport is {favSport[studentNumber]}");
                                    break;
                                case 3:
                                    Console.WriteLine($"{students[studentNumber]}'s favorite TV show is {tvShow[studentNumber]}");
                                    break;
                                default:
                                    Console.WriteLine("Whoops");
                                    break;
                            }
                        }

                        
                    }


                    

                }
                else
                {
                    again = true;
                }

                again = PlayAgain("Would you like to try again?(y/n): ");
                Console.Clear();
            }
            Console.WriteLine("Good Bye!");
        }
        public static void PrintList(string message, List<string> inputList)
        {
            Console.WriteLine(message);
            for (int i = 0; i < inputList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{inputList[i]}");
            }
        }
        public static string GetInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
        public static int TryParseInput(string input, List<string> inputList, int min, int max)
        {
            try
            {
                int inputNum = int.Parse(input);
                inputNum--;
                if (inputNum >= min && inputNum < max)
                {
                    return inputNum;
                }
                else
                {
                    Console.WriteLine("This is gonna cause a problem");
                    return -100;
                }

            }
            catch (FormatException)
            {

                if (inputList.Contains(input))
                {
                    int i = inputList.IndexOf(input);
                    return i--;
                }
                else
                {
                    Console.WriteLine("That name is not on our list");
                    return -100;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("That number was too high or too low");
                return -100;
            }
            catch (Exception)
            {
                Console.WriteLine("That number was not within the range");
                return -100;

            }
        }
        public static bool PlayAgain(string message)
        {
            string isValid = "";
            while (isValid != "y" && isValid != "n")
            {
                Console.Write(message);
                isValid = Console.ReadLine().ToLower();
            }
            if (isValid == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void AddNewInput(string message, List<string> inputList)
        {
            string input = "  ";
            bool isEmpty = string.IsNullOrWhiteSpace(input);
            while (isEmpty)
            {
                input = GetInput(message);
                isEmpty = string.IsNullOrWhiteSpace(input);
                
            }
            inputList.Add(input);
        }

    }
}
