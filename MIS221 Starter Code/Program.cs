using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MIS221_Starter_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starter Code
            int menuChoice = MenuOptions();
            RouteChoice(menuChoice);
        }

        //Presents the Menu Options
        public static int MenuOptions()
        {
            Console.Clear();
            Console.WriteLine("Enter '1'    to encode a file.");
            Console.WriteLine("Enter '2'    to decode a file.");
            Console.WriteLine("Enter '3'    to get a word count of the file.");
            Console.WriteLine("Enter '4'    to exit the system.");
            int menuChoice = int.Parse(Console.ReadLine());
            menuChoice = InputCheck(menuChoice);
            return menuChoice;
        }

        //Routes the user based on their menu choice
        public static void RouteChoice(int menuChoice)
        {
            if(menuChoice == 1)
            {
                string code = GoToEncode();
                SaveText(code);
                MenuOptions();
                RouteChoice(menuChoice);
            }
            else if(menuChoice == 2)
            {
                string decode = GoToDecode();
                SaveText(decode);
                MenuOptions();
                RouteChoice(menuChoice);
            }
            else if(menuChoice == 3)
            {
                GoToWordCount();
                MenuOptions();
                RouteChoice(menuChoice);
            }
            else if(menuChoice == 4)
            {
                GoToExit();
            }
        }


        //Routes to Encode File
        public static string GoToEncode()
        {
            Console.Clear();
            Console.WriteLine("Please enter the path of the file you would like to encode.");
            string file = Console.ReadLine();
            //C:\Demo\Test.txt
            StreamReader inFile = new StreamReader(file);
            file = inFile.ReadLine();
            if(file != null)
            {
                Console.WriteLine(file);
                string code = EncodeROT13(file);
                Console.WriteLine(code);
                inFile.Close();
                Console.ReadKey();
                return code;
            }
            inFile.Close();
            Console.ReadKey();
            return file;
        }


        //Routes to Decode File
        public static string GoToDecode()
        {
            Console.Clear();
            Console.WriteLine("Please enter the path of the file you would like to decode.");
            string file = Console.ReadLine();
            //C:\Demo\Test2.txt
            StreamReader inFile = new StreamReader(file);
            file = inFile.ReadLine();
            if(file != null)
            {
                Console.WriteLine(file);
                string code = DecodeROT13(file);
                Console.WriteLine(code);
                inFile.Close();
                Console.ReadKey();
                return code;
            }
            inFile.Close();
            Console.ReadKey();
            return file;
        }


        //Routes to Word Count
        public static void GoToWordCount()
        {
            Console.Clear();
            Console.WriteLine("Please enter the path of the file you would like to count the number of words in.");
            string file = Console.ReadLine();
            //C:\Demo\Test.txt
            StreamReader inFile = new StreamReader(file);
            file = inFile.ReadLine();
            if (file != null)
            {
                Console.WriteLine(file);
                int count = WordCount(file);
                Console.WriteLine("'" + file + "'" + " has " + count + " words in it.");
                inFile.Close();
                Console.ReadKey();
            }
            inFile.Close();
            Console.ReadKey();
        }


        //Routes to Exit System
        public static void GoToExit()
        {
            Console.Clear();
            Console.WriteLine("Goodbye!");
            Console.ReadKey();
            System.Environment.Exit(1);
        }


        //Checks if Menu Choice Input is Valid
        public static int InputCheck(int menuChoice)
        {
            if(menuChoice < 1 || menuChoice > 4)
            {
                ErrorMessage();
                int newMenuChoice = int.Parse(Console.ReadLine());
                return newMenuChoice;
            }
            else
            {
                return menuChoice;
            }
        }


        //Displays Error Message
        public static void ErrorMessage()
        {
            Console.WriteLine("Error, your input was not valid, please enter a valid input.");
        }


        //Encodes file using ROT13
        public static string EncodeROT13(string file)
        {
            char[] text = file.ToCharArray();
            for(int i = 0; i < text.Length; i++)
            {
                int letter = text[i];
                if(letter >= 'a' && letter <= 'z')
                {
                    if(letter > 'm')
                    {
                        letter -= 13;
                    }
                    else
                    {
                        letter += 13;
                    }
                }
                else if(letter >= 'A' && letter <= 'Z')
                {
                    if(letter > 'M')
                    {
                        letter -= 13;
                    }
                    else
                    {
                        letter += 13;
                    }
                }
                text[i] = (char)letter;
            }
            return new string(text);
        }


        //Decodes file using ROT13
        public static string DecodeROT13(string file)
        {
            char[] text = file.ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                int letter = text[i];
                if (letter >= 'a' && letter <= 'z')
                {
                    if (letter < 'm')
                    {
                        letter += 13;
                    }
                    else
                    {
                        letter -= 13;
                    }
                }
                else if (letter >= 'A' && letter <= 'Z')
                {
                    if (letter < 'M')
                    {
                        letter += 13;
                    }
                    else
                    {
                        letter -= 13;
                    }
                }
                text[i] = (char)letter;
            }
            return new string(text);
        }


        //Saves Encoded Text to File
        public static void SaveText(string code)
        {
            Console.Clear();
            Console.WriteLine("Please enter the path of the file you would like to save the encoded text to.");
            string file = Console.ReadLine();
            //C:\Demo\Test2.txt for the newly encoded text
            //C:\Demo\Test3.txt for the newly decoded text
            StreamWriter outFile = new StreamWriter(file);
            outFile.WriteLine(code);
            outFile.Close();
            Console.WriteLine("Your file has been saved!");
            Console.ReadKey();
        }


        //Counts Number of Words in Text File
        public static int WordCount(string file)
        {
            int count = 1;
            for(int i = 0; i <= file.Length - 1; i++)
            {
                if (file[i] == ' ' || file[i] == '\n' || file[i] == '\t')
                {
                    count++;
                }
            }
            return count;
        }

    }
}
