using System;
using System.Collections.Generic;

namespace orm
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseSetup database = new DatabaseSetup();
            List<User> users = database.getAllUsers();

            Dictionary<string, UserData> UserDataDictionary = new Dictionary<string, UserData>();
            foreach (User u in users)
            {
                // Console.WriteLine(u);
                if (UserDataDictionary.ContainsKey(u.Username))
                {

                    // DueDetails object
                    Credentials CredentialsData = new Credentials();
                    CredentialsData.Email = u.Email;
                    CredentialsData.Password = u.Password;

                    // Occurance
                    UserData data = UserDataDictionary[u.Username];
                    // DueDetail list
                    data.CredentialsList.Add(CredentialsData);


                }
                else
                {
                    // DueDetails
                    Credentials CredentialData = new Credentials();
                    CredentialData.Email = u.Email;
                    CredentialData.Password = u.Password;

                    // Occurance
                    UserData data = new UserData();
                    data.Username= u.Username;
                    data.CredentialsList = new List<Credentials>();
                    data.CredentialsList.Add(CredentialData);

                    // Console.WriteLine(data);
                    UserDataDictionary.Add(u.Username, data);
                    // Console.WriteLine("*************");
                }

            }

            // User user1 = database.getUserById(1);
            // User user2 = database.getUserById(1);
            // User user3 = database.getUserById(2);
            // Console.WriteLine(user1.Equals(user2));
            // Console.WriteLine(user2.Equals(user3));

            foreach (var Username in UserDataDictionary.Keys)
            {
                Console.WriteLine(UserDataDictionary[Username]);
            }

        }
    }
}
