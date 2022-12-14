using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace Проводник
{
    internal class Program
    {
        public static object MyDriveInfo { get; private set; }
        static int position = 0;

        static void fail(string path)
        {
            Console.Clear();

            string[] allFiles = Directory.GetDirectories(path);
            foreach (string file in allFiles)
            {
                Console.WriteLine("   " + file);
            }
            Strelka();

            if (position == -1)
            {
                return;
            }
            else
            {
                string nomerok = allFiles[position];
                fail(nomerok);
            }
            Console.Clear();

        }

        private static void Menu()
        {

            Console.SetCursorPosition(5, 4);
            DriveInfo[] disks = DriveInfo.GetDrives();
            foreach (var drive in DriveInfo.GetDrives())
            {
                Console.SetCursorPosition(50, 0);
                Console.WriteLine("Этот компьютер");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                Console.SetCursorPosition(0, 3);
                foreach (DriveInfo a in allDrives)
                {
                    Console.WriteLine("   Имя диска: " + a.Name);
                    Console.WriteLine("   Размер диска:" + a.TotalSize / 1024 / 1024 / 1024 + " GB");

                }
            }
        }
        static void Strelka()
        {

            ConsoleKeyInfo key = Console.ReadKey();

            while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
            {

                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    position--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    position++;

                }
                Console.SetCursorPosition(1, position);
                Console.WriteLine("->");
            }
            if (key.Key == ConsoleKey.Escape)
            {
                position = -1;
            }
        }
        private static void Main(string[] args)
        {
            while (true)
            {
                //string name = "C:\\";
                Menu();
                Strelka();
                if (position == 3)
                {
                    fail("C:\\");
                }
                else if (position == 6)
                {
                    fail("D:\\");
                }
               

            }
        }
    }
}
