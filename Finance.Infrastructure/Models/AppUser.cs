using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace FinanceSystem.Infrastructure.Models
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}