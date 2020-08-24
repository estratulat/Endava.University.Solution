using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Endava.University.Solution.Repository.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }

        public List<Wallet> Wallets { get; set; } = new List<Wallet>();
    }
}
