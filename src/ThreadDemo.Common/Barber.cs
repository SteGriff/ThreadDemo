using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadDemo.Common
{
    public class Barber
    {
        public Customer Customer { get; set; }
        public WaitingRoom WaitingRoom { get; set; }

        public Barber(WaitingRoom waitingRoom)
        {
            WaitingRoom = waitingRoom;
        }

        public void Run()
        {
            while(true)
            {
                var anybodyThere = CheckForCustomers();
                if (anybodyThere)
                {
                    CutHair();
                }
                else
                {
                    Sleep();
                }
            }
        }

        private bool CheckForCustomers()
        {
            Console.WriteLine("Barber looking for customers...");
            if (WaitingRoom.CustomersWaiting.Any())
            {
                Customer = WaitingRoom.SendCustomer();
                Console.WriteLine("Barber found " + Customer.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("Barber - nobody there!");
            }
            return false;
        }

        private void CutHair()
        {
            Console.WriteLine("Barber started cutting the hair of " + Customer.ToString());
            Thread.Sleep(1000);
            Console.WriteLine("Barber finished cutting the hair of " + Customer.ToString());
        }

        private void Sleep()
        {
            Console.WriteLine("Barber sleeping");
            Thread.Sleep(1000);
        }
    }
}
