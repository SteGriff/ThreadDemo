using System;
using System.Threading;
using ThreadDemo.Common;

namespace ThreadDemo.CoreCli
{
    class Program
    {
        static void Main(string[] args)
        {
            //AlphabetDemo();
            BarberDemo();
        }

        static void AlphabetDemo()
        {
            var alpha = new Alphabet();

            for (int i = 0; i < 5; i++)
            {
                // 1. New Thread
                //var printer = new Thread(new ThreadStart(alpha.Print));
                //printer.Start();

                // 2. ThreadPool Queue
                ThreadPool.QueueUserWorkItem(new WaitCallback(alpha.Print));
            }
            
            Console.ReadLine();
        }

        static void BarberDemo()
        {
            var waitingRoom = new WaitingRoom();
            var barber = new Barber(waitingRoom);

            var roomThread = new Thread(new ThreadStart(waitingRoom.Run));
            var barberThread = new Thread(new ThreadStart(barber.Run));

            roomThread.Start();
            barberThread.Start();

            Console.ReadLine();
        }

    }
}
