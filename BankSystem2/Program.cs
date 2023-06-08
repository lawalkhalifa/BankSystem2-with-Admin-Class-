using System;
using System.Runtime;

namespace BankSystem2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank1 = new Bank();
            Accounts accounts1 = new Accounts();
            User user1 = new User();
            Admin admin = new Admin();

            bank1.BankApp();
            accounts1.RunAccountSystem();
            user1.RunUserSystem();
            admin.AuditAccounts();
        }
    }
}
