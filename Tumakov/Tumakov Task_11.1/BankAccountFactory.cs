using System;
using System.Collections.Generic;

namespace Tumakov.Tumakov_Task_11._1
{
    class BankAccountFactory
    {
        private Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        public int CreateAccount()
        {
            int AccountNumber = GenerateAccountNumber();
            BankAccount account = new BankAccount(AccountNumber);
            accounts.Add(AccountNumber, account);
            return AccountNumber;
        }

        public void CloseAccount(int AccountNumber)
        {
            if (accounts.ContainsKey(AccountNumber))
            {
                accounts.Remove(AccountNumber);
            }
            else
            {
                throw new ArgumentException("Номер счета не найден.");
            }
        }
        private int GenerateAccountNumber()
        {
            Random random = new Random();
            return random.Next(10000000, 99999999);
        }
    } 
}
