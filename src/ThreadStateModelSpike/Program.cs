using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

public class Program
{
    public static void Main()
    {
        //string json = string.Format("{{'TableDefId':{0},'CheckId':{1}}}",2,101);
        //Console.WriteLine(json);
        var model = new StuffModel()
        {
            Finished = false,
            Name = "Guido"
        };

        Console.WriteLine(model.ToString());

        var machine = new Machine();
        ThreadPool.QueueUserWorkItem(new WaitCallback(machine.DoStuff), model);

        Stopwatch s = new Stopwatch();
        s.Start();
        while(s.ElapsedMilliseconds < 10000 && !model.Finished)
        {
            //Thread.Sleep(1);
            Console.WriteLine(model.ToString());
        }
        Console.WriteLine(model.ToString());
        Console.ReadLine();
    }

}

public class Machine
{
    public void DoStuff(object state)
    {
        Console.WriteLine("Doing stuff");
        var model = state as StuffModel;
        model.Finished = true;
    }

}

public class StuffModel
{
    public string Name { get; set; }
    public bool Finished { get; set; }

    public override string ToString()
    {
        return Name + (Finished ? " Finished" : " Waiting");
    }
}