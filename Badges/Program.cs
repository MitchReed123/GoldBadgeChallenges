using System;
using System.Drawing;
using System.Threading;

namespace Badges
{
    class Program
    {

        
        static void Main(string[] args)
        {
            //ConsoleTitle();
            ShowSimplePercentage();
            
            BadgeUI badges = new BadgeUI();
            badges.Start();
        }

        static void ShowSimplePercentage()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.Write($"\rStarting Up: %{i}");
                Thread.Sleep(25);
            }
            Console.Write("\rDone!");
        }

        static void ConsoleTitle()
        {
            string Progresbar = "Mitchells Console";
            var title = "";
            while (true)
            {
                for (int i = 0; i < Progresbar.Length; i++)
                {
                    title += Progresbar[i];
                    Console.Title = title;
                    Thread.Sleep(100);
                }
                title = "";
            }
        }
    }
}
