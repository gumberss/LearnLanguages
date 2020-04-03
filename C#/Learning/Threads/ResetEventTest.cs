﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Learning.Threads
{
    public class ResetEventTest
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);

        public ResetEventTest()
        {
            ////This class is a lightweight alternative to ManualResetEvent.
            //You can use this class for better performance than ManualResetEvent when wait times are expected to be very short, and when the event does not cross a process boundary.
            ManualResetEventSlim mres = new ManualResetEventSlim(); 

            //A single waiting thread is unblocked each time the Set method is called
            AutoResetEvent are = new AutoResetEvent(false);

            //Represents a synchronization primitive that is signaled when its count reaches zero.
            CountdownEvent ce = new CountdownEvent(0);
        }

        public void Process()
        {
            Console.WriteLine("\nStart 3 named threads that block on a ManualResetEvent:\n");

            for (int i = 0; i <= 2; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\nWhen all three threads have started, press Enter to call Set()" +
                              "\nto release all the threads.\n");
            Console.ReadLine();

            mre.Set();

            Thread.Sleep(500);
            Console.WriteLine("\nWhen a ManualResetEvent is signaled, threads that call WaitOne()" +
                              "\ndo not block. Press Enter to show this.\n");
            Console.ReadLine();

            for (int i = 3; i <= 4; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\nPress Enter to call Reset(), so that threads once again block" +
                              "\nwhen they call WaitOne().\n");
            Console.ReadLine();

            mre.Reset();

            // Start a thread that waits on the ManualResetEvent.
            Thread t5 = new Thread(ThreadProc);
            t5.Name = "Thread_5";
            t5.Start();

            Thread.Sleep(500);
            Console.WriteLine("\nPress Enter to call Set() and conclude the demo.");
            Console.ReadLine();

            mre.Set();

            // If you run this example in Visual Studio, uncomment the following line:
            //Console.ReadLine();
        }

        private static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine(name + " starts and calls mre.WaitOne()");

            mre.WaitOne();

            Console.WriteLine(name + " ends.");
        }

    }
}
