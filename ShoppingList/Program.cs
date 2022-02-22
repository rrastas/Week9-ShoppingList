using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Kaks projekti ühes */

            string rootDirectory = @"C:\Users\...\Samples";

            Console.WriteLine("Enter directory name:");
            string newDirectory = Console.ReadLine();

            Console.WriteLine("Enter file name:");
            string userNamedFile = Console.ReadLine();


            if (Directory.Exists($"{rootDirectory}\\{newDirectory}") && File.Exists($"{rootDirectory}\\{newDirectory}\\{userNamedFile}"))
            {
                Console.WriteLine($"Directory and File exist.");
            }
            else
            {
                Directory.CreateDirectory($"{rootDirectory}\\{newDirectory}");
                FileStream myFile = File.Create($"{rootDirectory}\\{newDirectory}\\{userNamedFile}");
                myFile.Close();

                string fileLocation = @$"C:\Users\...\Samples\{newDirectory}";
                string fileName = @$"\\{userNamedFile}";

                string[] arrayFromFile = File.ReadAllLines($"{fileLocation}{fileName}");
                List<string> myShoppingList = arrayFromFile.ToList<string>();

                bool loopActive = true;

                while (loopActive)
                {
                    Console.WriteLine("Would you like to add a new item? Y/N:");
                    char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                    if (userInput == 'y')
                    {
                        Console.WriteLine("Enter your item:");
                        string userItem = Console.ReadLine();
                        myShoppingList.Add(userItem);
                    }
                    else
                    {
                        loopActive = false;
                        Console.Clear();
                        Console.WriteLine("Take care!");
                    }

                    Console.WriteLine();

                    foreach (string item in myShoppingList)
                    {
                        Console.WriteLine($"Your item is: {item}");
                    }

                    File.WriteAllLines($"{fileLocation}{fileName}", myShoppingList);

                }
            }
        }
    }
}
