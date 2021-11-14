using System;
using FinanceSystem.DtoModels.Base;

namespace FinanceSystem.DtoModels.Transaction
{
    public class TransactionGetDto : BaseDto
    {
        public double Money { get; set; }
        public bool TransactionStatus { get; set; }
        public string TransactionType { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime? DateTransaction { get; set; }
    }
}