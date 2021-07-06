using System;
using Epam.UsersAwards.Entities;
using System.Collections.Generic;
using Epam.UsersAwardsDAL.Interfaces;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

namespace Epam.UsersAwards.SqlDAL
{
    public class AwardSqlDAO : IAwardDAO
    {
        public string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public const string JSON_FILES_PATH = @"C:\Users\Sgt.Pepper\Desktop\Study\EPAM\EPAM_Rep\Task 8\Task 8.2\Awards\";
        public Award AddAward(Award award)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Awards(Id, Title) " +
                    "VALUES(@Id,@Title)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", Guid.NewGuid());
                command.Parameters.AddWithValue("@Title", award.Title);

                _connection.Open();
                command.ExecuteNonQuery();

                return new Award(
                        id: award.ID,
                        title: award.Title);
            }
        }

        public IEnumerable<Award> AllAwards()
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Id, Title FROM Awards";

                var command = new SqlCommand(query, _connection);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Award(
                        id: (Guid)reader["Id"],
                        title: reader["Title"] as string);
                }
            }
        }

        public void DeleteAward(Guid id)
        {
            string sql = $"Delete From Awards Where Id='{id}'";
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(sql, _connection);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }

        }

        public void EditAward(Guid id, string newTitle)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = $"UPDATE dbo.Awards SET Title='{newTitle}'" +
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

        public void GiveAward(Guid userId, Guid awardId)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.AwardsToUsers(UserId, AwardId) " +
                    "VALUES(@userId,@awardId)";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@userId", userId.ToString());
                command.Parameters.AddWithValue("@awardId", awardId.ToString());

                _connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
