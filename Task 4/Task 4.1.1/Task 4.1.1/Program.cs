using System;
using System.IO;
using System.Threading;

namespace Task_4._1._1
{
    public class Program
    {
        public static void Main()
        {
            Watcher watcher = new Watcher();
            watcher.Start();
        }
    }
}