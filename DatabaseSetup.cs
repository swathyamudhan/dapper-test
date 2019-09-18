using Dapper;
using System;
using System.IO;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace orm
{
    public class DatabaseSetup
    {
        private SQLiteConnection connection;

        public DatabaseSetup()
        {
            CreateAndOpenDb();
        }

        private void CreateAndOpenDb()
        {
            var dbFilePath = "./TestDb.sqlite";
            if (!File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);
                connection = new SQLiteConnection(string.Format(
                    "Data Source={0};Version=3;", dbFilePath));
                connection.Open();
                SeedDatabase();
            }
            else
            {
                connection = new SQLiteConnection(string.Format(
                "Data Source={0};Version=3;", dbFilePath));
                connection.Open();
            }
        }

        public void ExecuteNonQuery(string commandText)
        {// Ensure we have a connection
            if (connection == null)
            {
                throw new NullReferenceException("Please provide a connection");
            }

            // Ensure that the connection state is Open
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            // Use Dapper to execute the given query
            connection.Execute(commandText);
        }

        private void SeedDatabase()
        {
            // Create a Users table
            ExecuteNonQuery(@"
        CREATE TABLE IF NOT EXISTS [Users] (
            [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
            [Username] NVARCHAR(64) NOT NULL,
            [Email] NVARCHAR(128) NOT NULL,
            [Password] NVARCHAR(128) NOT NULL,
            [DateCreated] TIMESTAMP DEFAULT CURRENT_TIMESTAMP
        )");

            // Insert an ADMIN user
            ExecuteNonQuery(@"
        INSERT INTO Users
            (Username, Email, Password)
        VALUES
            ('admin', 'jon@gmail.com', 'test')");
            ExecuteNonQuery(@"
        INSERT INTO Users
            (Username, Email, Password)
        VALUES
            ('swathy', 'swathy1@gmail.com', 'test1')");
            ExecuteNonQuery(@"
        INSERT INTO Users
            (Username, Email, Password)
        VALUES
            ('swathy', 'swathy2@gmail.com', 'test2')");
            ExecuteNonQuery(@"
        INSERT INTO Users
            (Username, Email, Password)
        VALUES
            ('swathy', 'swathy3@gmail.com', 'test3')");
        }


        public List<User> getAllUsers()
        {
            List<User> userList = new List<User>();
            IEnumerable<User> users = connection.Query<User>("SELECT * FROM Users");
            userList = users.AsList();
            return userList;
        }

        public User getUserById(int id)
        {
            User user;
            List<User> userList = connection.Query<User>(string.Format("SELECT * FROM Users WHERE Id = {0}", id)).AsList();
            user = userList[0];
            return user;

        }

    }
}