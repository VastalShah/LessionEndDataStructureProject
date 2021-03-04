using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LessionEndDataStructureProject
{
    class SchoolProject
    {
        public static void Do()
        {
            WriteData();
            ReadData();
        }

        private static void WriteData()
        {
            string dir = Directory.GetCurrentDirectory();
            string path = dir + "\\studentData.txt";
            Console.WriteLine(path);
            if (File.Exists(path))
            {
                Console.WriteLine("File Exists");
            }
            else
            {
                Console.WriteLine("File does not exist");
            }

            StreamWriter wrt = File.CreateText(path);
            wrt.WriteLine("Ram, CSE");
            wrt.WriteLine("Sita, ME");
            wrt.WriteLine("Shyam, Civil");
            wrt.WriteLine("Geeta, PE");
            wrt.Close();
            Console.WriteLine("Content has been written in the student file");
        }

        private static void ReadData()
        {
            string dir = Directory.GetCurrentDirectory();
            string path = dir + "\\studentData.txt";
            if (File.Exists(path))
            {
                Console.WriteLine("File Exists");
                var data = File.ReadAllLines(path);
                //Sorting the data
                Console.WriteLine("\nCalling the Sort Function...\n");
                SortStudentData(data);

                //Searching for a student
                Console.WriteLine("\n\nEnter a student name to search");
                string input = Console.ReadLine();
                SearchStudent(input, data);
            }
            else
            {
                Console.WriteLine("File Does not exist");
            }
        }

        private static void SearchStudent(string input, string[] data)
        {
            bool flag = false;
            foreach (string text in data)
            {
                string[] person = text.Split(", ");
                string name = text.Substring(0, person[0].Length);
                if (name == input)
                {
                    Console.WriteLine("\nThe Details of the student is:\n" + text);
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("No student data found");
            }
        }

        private static void SortStudentData(string[] data)
        {
            string temp;
            for (int i = 1; i < data.Length - 1; i++)
            {
                for (int j = 0; j < data.Length - 1; j++)
                {
                    if (data[j + 1].CompareTo(data[j]) < 0)
                    {
                        temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted Array is:");
            foreach (var d in data)
            {
                Console.WriteLine(d);
            }
        }
    }
}
