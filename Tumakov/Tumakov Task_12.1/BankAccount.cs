using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov.Tumakov_Task_12._1
{
    class BankAccountOp
    {
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public decimal Balance { get; set; }

        /*Переопределяем оператор ==*/
        public static bool operator ==(BankAccountOp account1, BankAccountOp account2)
        {
            if (ReferenceEquals(account1, account2))
            {
                return true;
            }

            if (ReferenceEquals(account1, null) || ReferenceEquals(account2, null))
            {
                return false;
            }

            return account1.AccountNumber == account2.AccountNumber &&
                   account1.AccountHolder == account2.AccountHolder &&
                   account1.Balance == account2.Balance;
        }

        /*Переопределяем оператор =!*/
        public static bool operator !=(BankAccountOp account1, BankAccountOp account2)
        {
            return !(account1 == account2);
        }
        /*Переопределяем метод Equals*/
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            BankAccountOp otherAccount = (BankAccountOp)obj;

            return AccountNumber == otherAccount.AccountNumber &&
                   AccountHolder == otherAccount.AccountHolder &&
                   Balance == otherAccount.Balance;
        }
        /*Переопределяем метод GetHashCode*/
        public override int GetHashCode()
        {
            return AccountNumber.GetHashCode() ^ AccountHolder.GetHashCode() ^ Balance.GetHashCode();
        }
        /*Переопределяем метод ToString для вывода инфы об счете*/
        public override string ToString()
        {
            return $"Account Number: {AccountNumber}\nAccount Holder: {AccountHolder}\nBalance: {Balance}";
        }
    }
}
