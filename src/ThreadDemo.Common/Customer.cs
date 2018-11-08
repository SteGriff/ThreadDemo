using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadDemo.Common
{
    public class Customer
    {
        private List< string> Names = new List<string>()
        {
            "Ankit" ,
            "Anni",
            "Aynes",
            "Dom",
            "Ed",
            "Ian",
            "Johnny",
            "Joe",
            "Kaja",
             "Kat",
             "Lance",
             "Margaret",
             "Mike",
             "Nisreen",
             "Paul",
             "Roger",
             "Ste",
             "Sue",
             "Tom"
        };

        public string Name { get; set; }

        public string ID { get; set; }

        public string ThreadId
        {
            get
            {
                return Thread.CurrentThread.ManagedThreadId.ToString();
            }
        }

        private Random _random;

        public Customer()
        {
            _random = new Random();
            int nameNum = _random.Next(0, 20);
            Name = Names[nameNum];

            ID = Guid.NewGuid().ToString().Split(new char[] { '-' }).First();
        }

        public override string ToString()
        {
            return $"{Name} {ThreadId}";
        }
    }
}
