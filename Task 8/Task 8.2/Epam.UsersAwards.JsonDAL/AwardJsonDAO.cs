using Epam.UsersAwards.Entities;
using Epam.UsersAwardsDAL.Interfaces;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Epam.UsersAwards.JsonDAL
{
    public class AwardJsonDAO : IAwardDAO
    {
        public const string JSON_AWARDS_PATH = @"C:\Users\Sgt.Pepper\Desktop\Study\EPAM\EPAM_Rep\Task 8\Task 8.2\Awards\";
        public const string JSON_USERS_PATH = @"C:\Users\Sgt.Pepper\Desktop\Study\EPAM\EPAM_Rep\Task 8\Task 8.2\Users\";
        public Award AddAward(Award award)
        {
            string json = JsonConvert.SerializeObject(award);
            File.WriteAllText(GetAwardById(award.ID), json);
            return award;
        }
        public IEnumerable<Award> AllAwards()
        {
            List<Award> awardList = new List<Award>();
            string[] files = Directory.GetFiles(JSON_AWARDS_PATH, "*.json");
            foreach (string filename in files)
            {
                var jsonFull = File.ReadAllText(filename);
                awardList.Add(JsonConvert.DeserializeObject<Award>(jsonFull));
            }

            return awardList;
        }

        public void DeleteAward(Guid id)
        {
            if (File.Exists(GetAwardById(id)))
            {
                string[] files = Directory.GetFiles(JSON_USERS_PATH, "*.json");
                Award award = JsonConvert.DeserializeObject<Award>(File.ReadAllText(GetAwardById(id)));
                foreach (string filename in files)
                {
                    User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(filename));

                    List<Award> copyList = user.Awards.ToList<Award>();
                    user.Awards = new List<Award>();

                    foreach (Award a in copyList)
                    {
                        if (a.ID != award.ID)
                        {
                            user.Awards.Add(a);
                        }
                    }

                    File.WriteAllText(filename, JsonConvert.SerializeObject(user));
                }
                File.Delete(GetAwardById(id));
            }
            else
            {
                throw new FileNotFoundException(
                    string.Format("Award with ID {0} at path {1} isn`t created", id, JSON_AWARDS_PATH));
            }
        }

        public void EditAward(Guid id, string newTitle)
        {
            if (!File.Exists(GetAwardById(id)))
            {
                throw new FileNotFoundException(
                    string.Format("File with name {0} at path {1} isn`t created!",
                    id, JSON_AWARDS_PATH));
            }
            Award award = JsonConvert.DeserializeObject<Award>(File.ReadAllText(GetAwardById(id)));
            award.EditAward(newTitle);
            File.WriteAllText(GetAwardById(id), JsonConvert.SerializeObject(award));
        }

        public void GiveAward(Guid userId, Guid awardId)
        {
            if (!File.Exists(GetUserById(userId)))
                throw new FileNotFoundException(
                    string.Format("User with id {0} at path {1} isn`t created!",
                    userId, JSON_USERS_PATH));

            if (!File.Exists(GetAwardById(awardId)))
                throw new FileNotFoundException(
                    string.Format("Award with id {0} at path {1} isn`t created!",
                    userId, JSON_AWARDS_PATH));

            User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(GetUserById(userId)));
            Award award = JsonConvert.DeserializeObject<Award>(File.ReadAllText(GetAwardById(awardId)));

            award.GiveAward(user);
            user.GetAward(award);

            File.WriteAllText(GetUserById(userId), JsonConvert.SerializeObject(user, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
            File.WriteAllText(GetAwardById(awardId), JsonConvert.SerializeObject(award, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        private string GetAwardById(Guid id) => JSON_AWARDS_PATH + id + ".json";

        private string GetUserById(Guid id) => JSON_USERS_PATH + id + ".json";
    }
}
