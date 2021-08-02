using System;
using System.ComponentModel.DataAnnotations;
using FinanceSystem.DtoModels.Base;

namespace FinanceSystem.DtoModels.Transaction
{
    public class TransactionDto : BaseDto
    {
        [Required]
        public double Money { get; set; }

        [Required]
        public bool TransactionStatus { get; set; }

        [Required]
        public Guid TransactionTypeId { get; set; }

        [Required]
        public bool IsCanceled { get; set; }

        [Required]
        public DateTime? DateTransaction { get; set; }
    }
}