using System;
using System.Collections.Generic;

namespace BankSystem2
{
    class Accounts
    {
        private static Dictionary<string, Accounts> accounts = new Dictionary<string, Accounts>();
        private static string currentUser = "";

        public double AccountNumber { get; private set; }
        public string Type { get; private set; }
        public double Balance { get; set; }
        private string Password { get; set; }
        public string accountType { get; private set; }

        public double TotalDeposits { get; set; }
        public double TotalWithdrawals { get;  set; }
        public double Minimumbalance { get; set; }
        
        public double initialBalance { get; set; }


        public Accounts(double totaldeposits, double totalwithdrawals)
        {
            TotalDeposits = totaldeposits;
            TotalWithdrawals = totalwithdrawals;
        }
        public Accounts(string accountType, double initialBalance,double minimumbalance, string password)
        {
            Type = accountType;
            Balance = initialBalance;
            Password = password;
            Minimumbalance = minimumbalance;
        }

        public Accounts(string accountType, double initialBalance, string password)
        {
            Password = password;
        }

        public Accounts(string accountType, double initialBalance)
        {
        }

        public Accounts()
        {
        }

        public string GetPassword()
        {
            return Password;
        }

        internal void RunAccountSystem()
        { }
    }
}
