using System;
using System.Timers;

namespace DateAndTime
{
    class LocalTimer
    {
        public TimeSpan IntervalTime { get; set; }
        
        public Timer timer { get; set; }
        
        public DateTime DateTimeNow { get; set; }

        private bool _active;
        
        private double intervals; //counts how many intervals have elapsed
        
        private double indicatorIntervals; //the number of intervals between indicator dots. This should not be confused with intervalIndicator.
                                           //I did not choose that definition because I think it's functioning like how a loading screen does.
        public bool active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value;
                if (value)
                {
                    timer.Elapsed += Timer_Elapsed;
                }
                else
                {
                    timer.Elapsed -= Timer_Elapsed;
                }
            }
        }
        
        public LocalTimer(TimeSpan intervalTime, DateTime now, int indicatorIntervalsDelay = 5)
        {
            IntervalTime = intervalTime;

            DateTimeNow = now;

            timer = new Timer();
            
            intervals = timer.Interval;
            
            indicatorIntervals = indicatorIntervalsDelay;
            
            timer.Start();
            
            active = true;
        }
        
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            intervals++;

            if (intervals == IntervalTime.Milliseconds)
            {
                // TODO: The timer is behind the real time in seconds.

                timer.Stop();

                Console.WriteLine("\nTime's up!");
                
                DateTimeNow += IntervalTime;
                
                Console.WriteLine($"It is now:{DateTimeNow}");
                
                for (int i = 0; i < 10; i++)
                {
                    Console.Beep(432, 500);
                }

                Console.WriteLine("If you want to exit the program you can enter \x1b[1mexit\x1b[0m");

                var command = Console.ReadLine();

                if (command == "exit")
                {
                    Console.WriteLine("Bye!");

                    Environment.Exit(0);
                }

            }

            else
            {
                if (intervals % indicatorIntervals == 0.0) Console.Write(".");
            }
        }
    }
}
