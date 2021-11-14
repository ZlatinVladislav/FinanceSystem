using System;
using FinanceSystem.Infrastructure.Models.Base;

namespace FinanceSystem.Infrastructure.Models
{
    public class Transaction : BaseEntity
    {
        public double? Money { get; set; }
        public bool TransactionStatus { get; set; }
        public Guid? TransactionTypeId { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime? DateTransaction { get; set; } = DateTime.Now;
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}