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
        private string StorageDir = @"E:\Storage";
        private string BackupDir = @"E:\Backup\";
        public Watcher()
        {
            CreateFolder();
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
            else
            {
                Rollback();
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

        private void Rollback()
        {
            var temp = "yyyy.MM.dd_HH-mm-ss";
            Console.WriteLine("Введите дату и время на которую необходимо сделать откат, вида \"{0}\" :", temp);
            string dateTimeRollback = Console.ReadLine();

            foreach (var s1 in Directory.GetFiles(StorageDir))
            {
                if (File.Exists(s1) & !File.Exists(BackupDir + dateTimeRollback))
                {
                    File.Delete(s1);
                }
            }

            CopyDir(BackupDir + dateTimeRollback, StorageDir);
            Console.WriteLine("Откат успешно произведён");
            Environment.Exit(0);
        }

        private void ChangeMode()
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

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Файл: {0} {1}", e.FullPath, e.ChangeType.ToString());
            string fileEvent = "изменен";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
            CopyDir(StorageDir, BackupDir);
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("Файл переименован из {0} в {1}", e.OldFullPath, e.FullPath);
            string fileEvent = "переименован в " + e.FullPath;
            string filePath = e.OldFullPath;
            RecordEntry(fileEvent, filePath);
            CreateFolder();

        }

        private void OnDelete(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Файл: {0} удален", e.FullPath);
            string fileEvent = "удален";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
            CreateFolder();
        }
        private void OnCreate(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Файл: {0} создан", e.FullPath);
            string fileEvent = "создан";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
            CreateFolder();
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

        private void CopyDir(string FromDir, string ToDir)
        {
            Directory.CreateDirectory(ToDir);
            foreach (string s1 in Directory.GetFiles(FromDir))
            {
                string s2 = ToDir + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2, true);
            }
            foreach (string s in Directory.GetDirectories(FromDir))
            {
                CopyDir(s, ToDir + "\\" + Path.GetFileName(s));
            }
        }

        private void CreateFolder()
        {
            string currentTime = DateTime.Now.ToString("yyyy.MM.dd_HH-mm-ss");
            string folder = Path.Combine(BackupDir, currentTime);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            CopyDir(StorageDir, folder);
        }
    }
}
