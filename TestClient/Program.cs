using Endava.University.Solution.Repository;
using Endava.University.Solution.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Default Db Context");

            //To connect to an sql or azure sql server jusr use: UseSqlServer(connectionString)
            var options = new DbContextOptionsBuilder<RepositoryDbContext>()
                    .UseSqlite("Data Source=endavaUniversity.db")
                    //.UseLoggerFactory(loggerFactory) 
                    .Options;

            using (var db = new RepositoryDbContext(options))
            {
                // Create
                var user = new User
                {
                    FirstName = "Maria",
                    LastName = "Antuanetta"
                };
                Console.WriteLine($"Inserting a new user: {user.FirstName} {user.LastName}.");
                db.Add(user);
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a user");
                var returnedUser = db.Users
                    .OrderBy(u => u.Id)
                    .Where(u => u.FirstName.Equals(user.FirstName)).First();
                Console.WriteLine($"User: {returnedUser.FirstName} {returnedUser.LastName}; Id: {returnedUser.Id}");

                // Update
                Console.WriteLine("Updating the user (Carlos) and adding a wallet");
                returnedUser.LastName = "Carlos";
                returnedUser.Wallets.Add(
                    new Wallet
                    {
                        Amount = 100,
                        Currency = "USD",
                    });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for an updated user");
                var updatedUser = db.Users
                    .OrderBy(u => u.Id)
                    .Where(u => u.FirstName.Equals(user.FirstName)).First();
                Console.WriteLine($"User: {updatedUser.FirstName} {updatedUser.LastName}; Id: {updatedUser.Id}");

                Console.WriteLine($"User' wallet Id: {updatedUser.Wallets.First()?.Id}");
                Console.WriteLine($"Wallet' user Id: {updatedUser.Wallets.First()?.UserId}");

                // Delete
                Console.WriteLine("Delete the user");
                db.Remove(updatedUser);
                db.SaveChanges();
            }
        }
    }
}
