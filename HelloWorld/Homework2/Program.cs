using System;
using System.Collections.Generic;
using Homework2.Models;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>
            {
                new User { Name = "Dave", Password = "hello" },
                new User { Name = "Steve", Password = "steve" },
                new User { Name = "Lisa", Password = "hello" }
            };

            users.FindAll(u =>
            {
                if (u.Password == "hello")
                {
                    Console.WriteLine(u.Password);
                }
                return u.Password == "hello";
            });
            users.RemoveAll(u => u.Password == u.Name.ToLower());
            users.Remove(users.Find(u => u.Password == "hello"));
            users.FindAll(u =>
            {
                Console.WriteLine($"{u.Name}: {u.Password}");
                return true;
            });
        }
    }
}
