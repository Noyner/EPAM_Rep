using Epam.Task8._1.Common.Entities;
using Epam.UsersDAL.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Epam.Task8._1.DAL
{
    public class AwardsJsonDAO : IAwardDAO
    {
        public const string JSON_FILES_PATH = @"C:\Users\Sgt.Pepper\Desktop\Study\EPAM\EPAM_Rep\Task 8\Task 8 ASP\Awards\";
        public void AddAward(Award award)
        {
            string json = JsonConvert.SerializeObject(award);
            File.WriteAllText(GetAwardById(award.ID), json);
        }
        public void AllAward()
        {
            Console.WriteLine("Award list: " + Environment.NewLine);
            string[] files = Directory.GetFiles(JSON_FILES_PATH, "*.json");
            foreach (string filename in files)
            {
                var jsonFull = File.ReadAllText(filename);
                Console.WriteLine(jsonFull);
            }
        }
        private string GetAwardById(Guid id) => JSON_FILES_PATH + id + ".json";
    }
}
