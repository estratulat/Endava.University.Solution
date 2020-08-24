using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Endava.University.Solution.Repository.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        [MaxLength(3)]
        public string Currency { get; set; }
        public decimal Amount { get; set; }

        public int UserId { get; set; }
    }
}
