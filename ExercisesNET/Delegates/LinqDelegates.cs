﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Delegates
{
    public static class LinqDelegates
    {
        static void Main()
        {
            var users = CreateCollection.GetUsers();

            var isNotNull =  //;

            users.Where(u => u != null)  //IsNoNull
                .Where(u => u.IsActive && u is SuperUser) //IsActiveSuperUser
                .OrderBy(u => u.Name) //OrderByName
                .Select(u => u.Name) //GetName
                .Count(s => s.StartsWith("s")); //StartsWithS
        }
    }


    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
    public class SuperUser : User
    {
        public bool IsAdmin { get; set; }
    }

    public static class CreateCollection
    {
        public static IEnumerable<User> GetUsers()
        {
            yield return new User { Id = 1, Name = "John", IsActive = true, Password = "Password" };
            yield return new User { Id = 7, Name = "Susan", IsActive = true, Password = "qwerasdf" };
            yield return new User { Id = 2, Name = "Andrew", IsActive = true, Password = "qwerty" };
            yield return new User { Id = 4, Name = "Anthony", IsActive = false, Password = "1qazXSW@" };
            yield return new SuperUser { Id = 11, Name = "Stephan", IsActive = true, Password = "aaa", IsAdmin = false };
            yield return new SuperUser { Id = 15, Name = "Susan", IsActive = true, Password = "qwerasdf", IsAdmin = false };
            yield return new User { Id = 9, Name = "Mark", IsActive = true, Password = "" };
            yield return new User { Id = 5, Name = "Jason", IsActive = true, Password = "ASD!@#" };
            yield return new User { Id = 14, Name = "Adam", IsActive = true, Password = "z" };
            yield return new User { Id = 6, Name = "Phil", IsActive = true, Password = "!@#$$%" };
            yield return new SuperUser { Id = 12, Name = "Tom", IsActive = true, Password = "!@#$$%", IsAdmin = true };
            yield return null;
            yield return new User { Id = 3, Name = "Paul", IsActive = true, Password = "QWERTY" };
            yield return new User { Id = 8, Name = "Adam", IsActive = false, Password = null };
            yield return new User { Id = 10, Name = "Sara", IsActive = true, Password = "6yhnMJU&" };
            yield return new SuperUser { Id = 13, Name = "Catherine", IsActive = false, Password = "password", IsAdmin = true };
        }
    }
}
