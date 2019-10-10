using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPractice.BLL
{
    public enum AccountType
    {
        Ordinary,
        Deposit
    }

    public class Bank<T> where T:Account
    {
        T[] accounts;

        public string Name { get; private set; }

        public Bank(string name)
        {
            this.Name = name;
        }

        public void Open(AccountType accountType, decimal sum,
            AccountStateHandler addSumHandler, AccountStateHandler withdrawSumHandler,
            AccountStateHandler calculationHandler, AccountStateHandler closeAccoutHandler,
            AccountStateHandler openAccountHandler)
        {
            T newAccount = null;

            switch (accountType)
            {
                case AccountType.Ordinary:
                    newAccount = new DemandAccount(sum, 1) as T;
                    break;

                case AccountType.Deposit:
                    newAccount = new DepositeAccount(sum, 40) as T;
                    break;
            }
            if (newAccount == null)
                throw new Exception("Ошибка создания счета");
            if (accounts == null)
                accounts = new T[] { newAccount };
            else
            {
                T[] tempAccount = new T[accounts.Length + 1];
                for(int i = 0; i < accounts.Length; i++)
                {
                    tempAccount[i] = accounts[i];
                }
                tempAccount[tempAccount.Length - 1] = newAccount;
                accounts = tempAccount;
            }

            newAccount.Added += addSumHandler;
            newAccount.Withdrawed += withdrawSumHandler;
            newAccount.Opened += openAccountHandler;
            newAccount.Closed += closeAccoutHandler;
            newAccount.Calculated += calculationHandler;

            newAccount.Open();
        }

        public T FindAccount(int id)
        {
            for(int i=0; i < accounts.Length; i++)
            {
                if (accounts[i].Id == id)
                    return accounts[i];
            }
            return null;
        }

        public void Put(decimal sum, int id)
        {
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Счет не найден");
            account.Put(sum);
        }

        public void Withdraw(decimal sum, int id)
        {
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Счет не найден");
            account.Withdraw(sum);
        }

        public void Close(int id)
        {
            int index = 0;
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Счет не найден");

            account.Close();

            if (accounts.Length <= 1)
                accounts = null;
            else
            {
                T[] tempAccount = new T[accounts.Length - 1];
                for(int i=0, j=0; i < accounts.Length; i++)
                {
                    if (i != index)
                        tempAccount[j++] = accounts[i];
                }
                accounts = tempAccount;
            }
        }

        public void CalculatePercentage()
        {
            if (accounts == null)
                return;
            for(int i = 0; i < accounts.Length; i++)
            {
                T account = accounts[i];
                account.IncrementDays();
                account.Calculate();
            }
        }

        public T FindAccount(int id, out int index)
        {
            for(int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Id == id)
                {
                    index = i;
                    return accounts[i];
                }
            }
            index = -1;
            return null;
        }
    }
}
