using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

namespace FinanceSystem.Infrastructure.Context.SeedData
{
    public class Seed
    {
        public static async Task SeedData(FinanceSystemDBContext context, UserManager<AppUser> userManager)
        {
            var userId = Guid.NewGuid().ToString();
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new() {Id = userId, DisplayName = "Bob", UserName = "bob", Email = "bob@test.com", Role = "Admin"},
                    new() {DisplayName = "Tom", UserName = "tom", Email = "tom@test.com", Role = "Admin"},
                    new() {DisplayName = "Jane", UserName = "jane", Email = "jane@test.com", Role = "User"}
                };

                foreach (var user in users) await userManager.CreateAsync(user, "Pa$$word1");
            }

            if (context.Transaction.Any()) return;

            var transactions = new List<Transaction>
            {
                new()
                {
                    Money = 7001,
                    TransactionStatus = false,
                    TransactionType = new TransactionType
                    {
                        Id = Guid.NewGuid(),
                        TransactionTypes = "type1"
                    }
                },
                new()
                {
                    Money = 7002,
                    TransactionStatus = false,
                    TransactionType = new TransactionType
                    {
                        Id = Guid.NewGuid(),
                        TransactionTypes = "type1"
                    }
                },
                new()
                {
                    Money = 7003,
                    TransactionStatus = false,
                    TransactionType = new TransactionType
                    {
                        Id = Guid.NewGuid(),
                        TransactionTypes = "type1"
                    }
                },
                new()
                {
                    Money = 7004,
                    TransactionStatus = false,
                    TransactionType = new TransactionType
                    {
                        Id = Guid.NewGuid(),
                        TransactionTypes = "type1"
                    }
                },
                new()
                {
                    Money = 7005,
                    TransactionStatus = false,
                    TransactionType = new TransactionType
                    {
                        Id = Guid.NewGuid(),
                        TransactionTypes = "type1"
                    }
                },
                new()
                {
                    Money = 7006,
                    TransactionStatus = false,
                    TransactionType = new TransactionType
                    {
                        Id = Guid.NewGuid(),
                        TransactionTypes = "type1"
                    }
                },
                new()
                {
                    Money = 7007,
                    TransactionStatus = false,
                    TransactionType = new TransactionType
                    {
                        Id = Guid.NewGuid(),
                        TransactionTypes = "type1"
                    }
                },
                new()
                {
                    Money = 7008,
                    TransactionStatus = false,
                    TransactionType = new TransactionType
                    {
                        Id = Guid.NewGuid(),
                        TransactionTypes = "type1"
                    }
                },
                new()
                {
                    Money = 7009,
                    TransactionStatus = false,
                    TransactionType = new TransactionType
                    {
                        Id = Guid.NewGuid(),
                        TransactionTypes = "type1"
                    }
                },
                new()
                {
                    Money = 7010,
                    TransactionStatus = false,
                    TransactionType = new TransactionType
                    {
                        Id = Guid.NewGuid(),
                        TransactionTypes = "type1"
                    }
                },
                new()
                {
                    Money = 7011,
                    TransactionStatus = false,
                    TransactionType = new TransactionType
                    {
                        Id = Guid.NewGuid(),
                        TransactionTypes = "type1"
                    }
                }
            };

            var transactionTypes = new List<TransactionType>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    TransactionTypes = "type1"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    TransactionTypes = "type2"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    TransactionTypes = "type3"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    TransactionTypes = "type4"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    TransactionTypes = "type5"
                }
            };

            await context.Transaction.AddRangeAsync(transactions);
            await context.TransactionType.AddRangeAsync(transactionTypes);
            await context.SaveChangesAsync();
        }
    }
}