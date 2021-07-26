using System.Collections.Generic;
using FinanceSystem.Infrastructure.Models.Base;

namespace FinanceSystem.Infrastructure.Models
{
    public class TransactionType : BaseEntity
    {
        public string TransactionTypes { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
