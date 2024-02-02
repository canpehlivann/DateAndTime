using System;

namespace DateAndTime
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to our basic date and time demo.");
            
            Console.WriteLine("It is currently: " + DateTime.Now + " local time.");
            
            Console.WriteLine("Let's set a timer.");

            Console.WriteLine("When do you want to set the timer?");

            Console.WriteLine("Please enter a date exactly like above.");

            var date = Console.ReadLine();

            try
            {
                if (DateTime.TryParse(date, out DateTime temp) == true)
                {

                    var now = DateTime.Now;

                    TimeSpan interval = temp - now;

                    LocalTimer timer = new LocalTimer(interval,now);

                    Console.WriteLine("Timer started at: " + now + " local time.");

                    Console.WriteLine("Timer set.Please wait to get notified.");

                    Console.WriteLine("If you want to stop the timer you can enter \x1b[1mcancel\x1b[0m");

                    var command = Console.ReadLine();

                    if (command == "cancel")
                    {
                        Console.WriteLine("Bye!");
                        timer.timer.Stop();
                    }
                }
            }

            catch (ArgumentException argEx)
            {
                Console.WriteLine("Probably you did not give an acceptable input. Please enter the date in true format.");
                
                Console.WriteLine("Formatting is should be exactly this:");
                
                Console.WriteLine("Day.Month.Year Hour:Minute:Second");
                
                Console.WriteLine($"Error message: {argEx.Message}");
            }
        }
    }
}
