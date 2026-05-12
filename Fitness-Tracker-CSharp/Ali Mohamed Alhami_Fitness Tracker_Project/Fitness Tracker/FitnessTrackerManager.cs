using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness_Tracker
{
    // This is the  Static class that manages all users. More over, handles file I/O and provides login/registration logic.
    public static class FitnessTrackerManager
    {
        // this is the Private static fields  which hold the list of users, the currently logged-in user, and the file path.
        private static List<User> users = new List<User>();
        private static User currentUser = null;
        private static string dataFilePath = "users.dat";

        public static List<User> Users { get => users; }
        public static User CurrentUser { get => currentUser; set => currentUser = value; }

        // This as you see Loads the list of users from a binary file. If the file does not exist or is corrupted it creates an empty list. 
        public static void LoadData()
        {
            if (File.Exists(dataFilePath))
            {
                try
                {
                    using (FileStream fs = new FileStream(dataFilePath, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        users = (List<User>)formatter.Deserialize(fs);
                    }
                }
                catch (Exception)
                {
                    users = new List<User>();
                }
            }
            else
            {
                users = new List<User>();
            }
        }

        // This code saves the current list of users to a binary file.
        public static void SaveData()
        {
            try
            {
                using (FileStream fs = new FileStream(dataFilePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, users);
                }
            }
            catch (Exception)
            {
                
            }
        }

        // This validates the  username and password according to the rules, then it  creates a new user and saves.
        public static bool RegisterUser(string username, string password, out string errorMessage)
        {
            errorMessage = "";
            if (!System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
            {
                errorMessage = "Username must contain only letters and numbers.";
                return false;
            }
            if (password.Length != 12)
            {
                errorMessage = "Password must be exactly 12 characters long.";
                return false;
            }
            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower))
            {
                errorMessage = "Password must contain at least one uppercase and one lowercase letter.";
                return false;
            }
            if (users.Exists(u => u.Username == username))
            {
                errorMessage = "Username already exists.";
                return false;
            }

            User newUser = new User(username, password);
            users.Add(newUser);
            SaveData();
            return true;
        }

        // This Attempts to find a user with matching username and password, and it sets currentUser if found.
        public static bool Login(string username, string password)
        {
            currentUser = users.Find(u => u.Username == username && u.Password == password);
            return currentUser != null;
        }

        // This clears the currently logged-in user.

        public static void Logout()
        {
            currentUser = null;
        }
    }
}