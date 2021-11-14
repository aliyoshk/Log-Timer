using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;

namespace TimeLogWriter
{
    class Program
    {
             private static System.Timers.Timer aTimer;

        public static void Main()
        {
            SetTimer();
           DateTime time = DateTime.Now;
           string path = @"C:\Assignment\seconds.txt";
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", time);
            
            
           File.WriteAllLines(path, new string[] { time.ToString() }); // it will read the time the program start running


            Console.ReadLine();
            aTimer.Stop(); 
            aTimer.Dispose();
            Console.WriteLine("Terminating the application...");
        }

        private static void SetTimer()
        {
            // Create a timer with a ten second interval.
            aTimer = new System.Timers.Timer(10000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent; // These is not as usual increment, in this case is called operator overloading since they are objects not Arithmetic operators
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            string path = @"C:\Assignment\seconds.txt";
            DateTime a = e.SignalTime;
            

            //File.WriteAllLines(path, new string[] { a.ToString() }); // this will record time in text file according to regostration in sequential manner

            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", a);

            List<string> lines = File.ReadAllLines(path).ToList(); 
            foreach(var line in lines)
            {
                var newList = line.OrderByDescending(x => lines).ToList(); // this is going to display the latest time registered in path 
            }
        }
    }
}
