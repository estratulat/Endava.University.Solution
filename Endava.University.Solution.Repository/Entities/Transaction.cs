using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Endava.University.Solution.Repository.Entities
{
    public class Transaction
    {
        [MaxLength(32)]
        public string Id { get; set; }
        public int SourceWalletId { get; set; }
        public int DestinationWalletId { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(10)]
        public string State { get; set; }
        [MaxLength(200)]
        public string Comment { get; set; }
    }
}
