using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankSystem2.User;
using static BankSystem2.Accounts;

namespace BankSystem2
{
    class Bank
    {


        class UserDetails
        {
            private Dictionary<string, UserDetails> userDetails;
            public string Username { get; set; }
            public string Password { get; set; }

            public UserDetails(string username, string password)
            {
                Username = username;
                Password = password;
            }
        }

        private Dictionary<string, User> users;
        Dictionary<string, Accounts> accounts = new Dictionary<string, Accounts>();

        public Dictionary<double, double> acounta { get; private set; }

        private User currentUser;

        public double AccountNumber { get; private set; }
        public double accountNumber { get; private set; }
        public Accounts newAccount { get; private set; }
        public string accountType { get; private set; }
      

        private Admin admin;

      

        internal void BankApp()
        {

            users = new Dictionary<string, User>();
            accounts = new Dictionary<string, Accounts>();

            admin = new Admin(users, accounts);




            currentUser = null;


            bool isAdmin = true;
            bool isRunning = true;
            bool isLoggedIn = false;

            while (isRunning)
            {
                Console.WriteLine("Please choose from one of the following options...");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Create an Account (Current or Savings)");
                Console.WriteLine("4. Deposit");
                Console.WriteLine("5. Withdraw");
                Console.WriteLine("6. Audit Accounts");
                Console.WriteLine("7. Exit");
                


                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Signup();
                        break;
                    case 2:
                        isLoggedIn = Login();
                        break;
                    case 3:
                        if (isLoggedIn)
                        {
                            CreateAccount();
                        }
                        else
                        {
                            Console.WriteLine("Please login first.");
                        }
                        break;
                    case 4:
                        if (isLoggedIn)
                        {

                            Deposit();
                        }
                        else
                        {
                            Console.WriteLine("Please login first.");
                        }
                        break;
                    case 5:
                        if (isLoggedIn)
                        {
                            Withdraw();
                        }
                        else
                        {
                            Console.WriteLine("Please Login First");
                        }
                        break;
                     case 6:
                        isRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                    case 7:
                        if (isLoggedIn)
                        {
                            if (isAdmin)
                            {
                                admin.AuditAccounts();
                            }
                            else
                            {
                                Console.WriteLine("You dont have admin privileges.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please login first.");
                        }
                        break;
                }
            }


            void Signup()
            {
                Console.Write("Please enter your username: ");
                string username = Console.ReadLine();

                if (users.ContainsKey(username))
                {
                    Console.WriteLine("Username already exists. Please try again.");
                    return;
                }

                Console.Write("Please enter your password: ");
                string password = Console.ReadLine();

                User newUser = new User();
                newUser.Username = username;
                newUser.Password = password;
                users.Add(username, newUser);
                accounts.Add(password, newAccount);
                Console.WriteLine($"Signup successful! Welcome, {username}!");
            }
            bool Login()
            {
                Console.Write("Please Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                if (users.ContainsKey(username) && string.Equals(users[username].Password, password))
                {
                    currentUser = users[username];
                    Console.WriteLine($"Welcome, {currentUser.Username}!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                    return false;
                }
            }

            void CreateAccount()
            {
                Console.Write("Enter the account type (Current or Savings): ");
                string accountType = Console.ReadLine();
                Console.Write("Enter the initial balance: ");
                double initialBalance = double.Parse(Console.ReadLine());
                Console.Write("Enter your password to confirm: ");
                string password = Console.ReadLine();

                if (string.Equals(currentUser.Password, password))
                {
                    Random random = new Random();
                    var accountNumber = random.Next(100000, 200000);


                    Accounts newAccount = new Accounts(accountType, initialBalance, password);
                    accounts.Add(accountNumber.ToString(), newAccount);
                    if (accountType.ToLower() == "current")
                    {
                       
                        Console.WriteLine($"Current account created successfully! Account number: {accountNumber}");
                    }
                    else if (accountType.ToLower() == "savings")
                    {
                        double minimumBalance = 1000;
                        if (initialBalance >= minimumBalance)
                        {

                            Console.WriteLine($"Savings account created successfully! Account number: {accountNumber}");
                        }
                        else
                        {
                            Console.WriteLine($"Insufficient initial balance for a savings account. Minimum balance required: {minimumBalance}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Account created successfully! Account number:  {accountNumber}");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect password. Account creation failed.");
                }
            }
            void Deposit()
            {
                Console.Write("Enter your account Number: ");
                string accountNumber = Console.ReadLine();
                Console.Write("Enter the amount to deposit: ");
                double depositAmount = double.Parse(Console.ReadLine());

                if (accounts.ContainsKey(accountNumber))
                {
                    double initialBalance = 0;
                    Accounts newAccount = new Accounts(accountNumber, initialBalance) ;
                    accounts[accountNumber].Balance += depositAmount;

                    depositAmount += initialBalance;

                    Console.WriteLine($"Deposit successful! New balance: {accounts[accountNumber].Balance}");

                }
                else
                {
                    Console.WriteLine("Invalid Account number!");
                }
            }

            void Withdraw()
            {
                Console.Write("Enter the account number: ");
                string accountNumber = Console.ReadLine();
                Console.Write("Enter the amount to withdraw: ");
                double withdrawamount = double.Parse(Console.ReadLine());

                if (accounts.ContainsKey(accountNumber))
                {
                    
                    Accounts account = accounts[accountNumber];
                    if (account.accountType.ToLower() == "savings" && account.Balance - withdrawamount < 1000)
                    {
                        _ = account.Balance + account.TotalDeposits - account.TotalWithdrawals;
                        Console.WriteLine("Insufficient funds. Transaction Failed.");
                    }
                    else if (withdrawamount <= account.Balance)
                    {
                        account.Balance -= withdrawamount;
                        account.TotalWithdrawals += withdrawamount;
                        Console.WriteLine("Withdrawal Successful!");
                        Console.WriteLine($"Remaining balance: {account.Balance}");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds. Transaction failed.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid account number!");
                }

            }
        }
    }
}
