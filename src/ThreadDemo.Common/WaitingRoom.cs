using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadDemo.Common
{
    public class WaitingRoom
    {
        public List<Customer> CustomersWaiting { get; set; }
        private Random _random;

        public WaitingRoom()
        {
            _random = new Random();
            CustomersWaiting = new List<Customer>();
        }

        public void Run()
        {
            while (true)
            {
                CreateNewCustomer();

                int msWait = 100 * _random.Next(5, 20);
                Thread.Sleep(msWait);
            }
        }

        private void CreateNewCustomer()
        {
            if (CustomersWaiting.Count > 5)
            {
                return;
            }
            
            var c = new Customer();
            CustomersWaiting.Add(c);
            Console.WriteLine($"WaitingRoom - {c.ToString()} walked in");
        }

        public Customer SendCustomer()
        {
            if (CustomersWaiting.Any())
            {
                var c = CustomersWaiting.First();
                Console.WriteLine("WaitingRoom sending " + c.ToString());
                CustomersWaiting.Remove(c);
                return c;
            }
            return null;
        }
    }
}
