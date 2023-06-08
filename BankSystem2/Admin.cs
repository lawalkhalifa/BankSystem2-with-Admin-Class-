using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem2
{
    class Admin
    {
        private Dictionary<string, User> users;
        private Dictionary<string, Accounts> accounts;

        public Admin()
        {
        }

        public Admin(Dictionary<string, User> users, Dictionary<string, Accounts> accounts)
        {
            this.users = users;
            this.accounts = accounts;
        }
        public void AuditAccounts()
        {
            Console.WriteLine("Account Audit:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account Number: {account.Key}");
                Console.WriteLine($"Account Type: {account.Value.Type}");
                Console.WriteLine($"Account Balance: {account.Value.Balance}");
                Console.WriteLine("---------------");
            }
        }
    }
}
