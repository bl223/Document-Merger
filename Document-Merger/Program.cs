using System;
using System.IO;

namespace DocumentMerger
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            bool response = false;
            while (!response)
            {
             
                string path1 = @"C:\input1.txt";
                string path2 = @"C:\input2.txt";
                string newFilePath = @"C:\output.txt";

                string allText = System.IO.File.ReadAllText(path1);

                allText += "\r\n";

                allText += System.IO.File.ReadAllText(path2);

                using (FileStream fs = new FileStream(newFilePath, FileMode.OpenOrCreate))
                {
                    System.IO.File.WriteAllText(newFilePath, allText);
                }


                Console.WriteLine("Document Merger");

                Console.Write("\nEnter first File name: ");
                string fFname = GetUserInput();

                Console.Write("\nEnter second File name: ");
                string sFname = GetUserInput();

                Console.WriteLine("Merged Files:" + fFname + "" + sFname + ".txt");
                Console.ReadLine();


                Console.WriteLine("Would you like to create another URL? [y/n]");

                string option = Console.ReadLine();

                if (option == "n")
                {
                    response = true;
                }
            }
        }
         
        //Functions
        static string GetUserInput()
        {
            string input = "";
            do
            {
                input = Console.ReadLine();
                if (IsValid(input)) return input;
                Console.Write("Input File name does not exist. Enter again: ");
            } while (true);
        }

        static bool IsValid(string input)
        {
            foreach (char character in input.ToCharArray())
            {
                if ((character >= 0x00 && character <= 0x1F) || character == 0x7F)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
