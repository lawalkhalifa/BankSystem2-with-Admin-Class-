using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankSystem2
{
    internal class User
    {
        private string username;
        private string password;
        private List<Account> accounts;
        internal readonly Account Accounts;
         public string Username { get; internal set; }
        public string Password { get; internal set; }
        public bool IsAdmin { get; internal set; }
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.accounts = new List<Account>();
        }

        public User()
        {
        }

        public void RunUserSystem()
        { 
        
        }
        internal class Account
        {
            private string accountName;
            public string Name { get; }
            public string Number { get; }
            public double AccountNumber { get; internal set; }
            public string accountType { get; set; }
            public double Balance { get; }
            public string Password { get; private set; }
            public Account(string type, double balance, string password)
            {
          
                accountType = type;
                Balance = balance;
                Password = password;
            }
            public Account(string accountName, string accountNumber)
            {
                this.accountName = accountName;
               
            }

        }
    }

}


