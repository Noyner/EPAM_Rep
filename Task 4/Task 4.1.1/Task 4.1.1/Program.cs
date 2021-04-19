using System;
using System.IO;

public class Test
{
    public static void Main()
    {
        FileSystemWatcher watcher = new FileSystemWatcher();
        Console.WriteLine("Отслеживаю изменения...");

        watcher.Path = Path.GetDirectoryName(@"D:\Storage"); 
        watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size;

        watcher.Deleted += new FileSystemEventHandler(OnDelete);
        watcher.Renamed += new RenamedEventHandler(OnRenamed);
        watcher.Changed += new FileSystemEventHandler(OnChanged);
        watcher.Created += new FileSystemEventHandler(OnCreate);
        watcher.Error += OnError;

        watcher.Filter = "*.txt";
        watcher.IncludeSubdirectories = true;
        watcher.EnableRaisingEvents = true;

        Console.ReadLine();
    }


    public static void OnChanged(object source, FileSystemEventArgs e)
    {
        Console.WriteLine("Файл: {0} {1}", e.FullPath, e.ChangeType.ToString());
    }

    public static void OnRenamed(object source, RenamedEventArgs e)
    {
        Console.WriteLine("Файл переименован из {0} в {1}", e.OldFullPath, e.FullPath);
    }

    public static void OnDelete(object source, FileSystemEventArgs e)
    {
        Console.WriteLine("Файл: {0} удален", e.FullPath);
    }
    public static void OnCreate(object source, FileSystemEventArgs e)
    {
        Console.WriteLine("Файл: {0} создан", e.FullPath);
    }

    private static void OnError(object source, ErrorEventArgs e)
    {
        PrintException(e.GetException());
    }

    private static void PrintException(Exception? ex)
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

}