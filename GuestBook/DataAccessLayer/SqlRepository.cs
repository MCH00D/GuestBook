using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using GuestBook.Models;

namespace GuestBook.DataAccessLayer
{
    public class SqlRepository : IRepository
    {
        private string _connectionString = WebConfigurationManager.ConnectionStrings["GB"].ConnectionString;

        public void CreateRecord(Record record)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = @"
                    INSERT INTO [Records]([Message], [Author], [Date]) 
                    VALUES(@message, @author, @date);";

                command.Parameters.AddWithValue("message", record.Message);
                command.Parameters.AddWithValue("author", record.Author);
                command.Parameters.AddWithValue("date", record.Date);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Record> GetRecords()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT [Id] , [Message], [Author], [Date] 
                    FROM [Records];";

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return ParseReader(reader);
                }
            }
        }

        public Record GetRecord(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT [Id] , [Message], [Author], [Date] 
                    FROM [Records]
                    WHERE Id = @Id;";

                command.Parameters.AddWithValue("Id", id);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ParseRecord(reader);
                    }
                    return null;
                }
            }
        }

        public void UpdateRecord(Record record)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = @"
                    UPDATE [Records]
                    SET [Message] = @message
                    WHERE Id = @Id;";

                command.Parameters.AddWithValue("Id", record.Id);
                command.Parameters.AddWithValue("message", record.Message);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteRecord(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = @"
                    DELETE FROM [Records] 
                    WHERE Id = @Id;";

                command.Parameters.AddWithValue("Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static List<Record> ParseReader(SqlDataReader reader)
        {
            List<Record> result = new List<Record>();

            while (reader.Read())
            {
                result.Add(ParseRecord(reader));
            }

            return result;
        }

        private static Record ParseRecord(SqlDataReader reader)
        {
            Record record = new Record
            {
                Id = (int)reader["Id"],
                Message = (string)reader["Message"],
                Author = (string)reader["Author"],
                Date = (DateTime)reader["Date"],
            };

            return record;
        }
    }
}