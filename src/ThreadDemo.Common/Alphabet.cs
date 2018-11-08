using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo.Common
{
    public class Alphabet
    {
        public void Print(object state = null)
        {
            lock (Lockables.AlphabetLock)
            {
                var letters = "abcdefghijklmnopqrstuvwxyz";
                foreach (var letter in letters)
                {
                    string report = $"{Thread.CurrentThread.ManagedThreadId}{letter} ";
                    Console.Write(report);
                }
            }
        }



        public Task PrintAsync()
        {
            return new Task(() =>
            {
                Print();
            });
        }
    }
}
