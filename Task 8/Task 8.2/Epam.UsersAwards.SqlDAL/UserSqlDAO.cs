using System;
using Epam.UsersAwards.Entities;
using Epam.UsersAwardsDAL.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Linq;

namespace Epam.UsersAwards.SqlDAL
{
    public class UserSqlDAO : IUserDAO
    {
        public string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        //public static SqlConnection _connection = new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;Initial Catalog=UsersAndAwards;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
        public const string JSON_FILES_PATH = @"C:\Users\Sgt.Pepper\Desktop\Study\EPAM\EPAM_Rep\Task 8\ask 8.2\Users\";
        public User AddUser(User user)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Users(Id, Name, DateOfBirth, Age) " +
                    "VALUES(@Id,@Name, @DateOfBirth, @Age)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", Guid.NewGuid());
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@Age", user.Age);


                _connection.Open();
                command.ExecuteNonQuery();

                return new User(
                        id: user.ID,
                        name: user.Name,
                        dateOfBirth: user.DateOfBirth,
                        age: user.Age);
            }
        }

        public User GetUser(Guid id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Users_GetUserById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User(
                        id: (Guid)reader["Id"],
                        name: reader["Name"] as string,
                        dateOfBirth: (DateTime)reader["DateOfBirth"],
                        age: (int)reader["Age"]);
                }
                _connection.Close();

                throw new InvalidOperationException("Cannot find User with ID = " + id);
            }
        }

        public void DeleteUser(Guid id)
        {
            //var connect = new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;Initial Catalog=UsersAndAwards;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string sql = $"Delete From Users Where Id='{id}'";
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(sql, _connection);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public IEnumerable<User> AllUsers(bool orderedById = true)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Id, Name, DateOfBirth, Age FROM Users"
                   + (orderedById ? " ORDER BY Id" : "");
                //var awardsToUsers = "SELECT Id FROM Users WHERE " 
                //var awardsToUsers = "SELECT * FROM AwardsToUsers";
                //var allAwards = "SELECT * FROM Awards";


                var command = new SqlCommand(query, _connection);
                //var command2 = new SqlCommand(awardsToUsers, _connection);
                //var command3 = new SqlCommand(allAwards, _connection);
                

                _connection.Open();

                var reader = command.ExecuteReader();
                /*
                var reader2 = command2.ExecuteReader();
                _connection.Close();

                _connection.Open();
                var reader3 = command3.ExecuteReader();

                List<Award> awardList = new List<Award>();
                List<User> userList = new List<User>();
                while (reader3.Read())
                {
                    var award = new Award(
                        id: (Guid)reader["Id"],
                        title: reader["Title"] as string);
                    awardList.Add(award);
                }*/

                while (reader.Read())
                {
                    yield return new User(
                        id: (Guid)reader["Id"],
                        name: reader["Name"] as string,
                        dateOfBirth: (DateTime)reader["DateOfBirth"],
                        age: (int)reader["Age"]);
                    /*
                    while (reader2.Read())
                    {
                        var award = awardList.Where(x => x.ID.ToString() == reader2["AwardId"]).FirstOrDefault();
                        if (reader2["UserId"]==user.ID.ToString())
                        {
                            user.Awards.Add(award);
                        }
                    }
                    userList.Add(user);
                }
                return userList;*/
                }
            }
        }

        public void EditUser(Guid id, string newName, DateTime newDateTimeOfBirth, int newAge)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = $"UPDATE dbo.Users SET Name='{newName}', DateOfBirth='{newDateTimeOfBirth}', Age='{newAge}'" +
                    $"WHERE Id = '{id}'";
                var command = new SqlCommand(query, _connection);

                try
                {
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        private string GetUserById(Guid id) => JSON_FILES_PATH + id + ".json";
    }
}
