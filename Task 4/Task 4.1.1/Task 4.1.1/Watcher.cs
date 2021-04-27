using System;
using System.IO;
using System.Threading;

namespace Task_4._1._1
{
    public class Watcher
    {
        public FileSystemWatcher watcher;
        public bool watchOn = true;
        object obj = new object();
        private string PlaceForLogs = @"E:\Logs\Logs.txt";
        public Watcher()
        {
            ChangeMode();
            if (watchOn)
            {
                Console.WriteLine("Отслеживаю изменения...");
                watcher = new FileSystemWatcher(@"E:\Storage");

                watcher.Deleted += new FileSystemEventHandler(OnDelete);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnCreate);
                watcher.Error += OnError;

                watcher.Filter = "*.txt";
                watcher.IncludeSubdirectories = true;
            }
            
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (watchOn)
            {
                Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            watchOn = false;
        }

        private void Follow()
        {
            Console.WriteLine("Отслеживаю изменения...");

            watcher.Path = Path.GetDirectoryName(@"E:\Storage");

            watcher.Deleted += new FileSystemEventHandler(OnDelete);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreate);
            watcher.Error += OnError;

            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
        }

        //private void Rollback()
        //{
        //    var temp = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        //    Console.WriteLine("Введите дату и/или время на которую \nнеобходимо сделать откат, вида \"{0}\" :", temp);
        //    dateTimeRestoration = Console.ReadLine();
        //}

        public void ChangeMode()
        {
            while (true)
            {
                Console.WriteLine("Выберите режим: \n1.Наблюдения \n2.Откат изменений");
                var changeMode = Console.ReadLine();

                if (changeMode == "1")
                {
                    
                    Console.WriteLine("Выбран режим наблюдения");
                    break;
                }
                else if (changeMode == "2")
                {
                    watchOn = false;
                    Console.WriteLine("Выбран режим отката изменений");
                    break;
                }
            }
        }

        public void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Файл: {0} {1}", e.FullPath, e.ChangeType.ToString());
            string fileEvent = "изменен";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }

        public void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("Файл переименован из {0} в {1}", e.OldFullPath, e.FullPath);
            string fileEvent = "переименован в " + e.FullPath;
            string filePath = e.OldFullPath;
            RecordEntry(fileEvent, filePath);
        }

        public void OnDelete(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Файл: {0} удален", e.FullPath);
            string fileEvent = "удален";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }
        public void OnCreate(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Файл: {0} создан", e.FullPath);
            string fileEvent = "создан";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }

        private void OnError(object source, ErrorEventArgs e)
        {
            PrintException(e.GetException());
        }

        private void PrintException(Exception ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter(PlaceForLogs, true))
                {
                    writer.WriteLine(String.Format("{0} файл {1} был {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
        }
    }
}
