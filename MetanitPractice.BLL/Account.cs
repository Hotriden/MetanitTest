using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MetanitPractice.BLL
{
    public abstract class Account : IAccount
    {
        protected internal event AccountStateHandler Withdrawed;

        protected internal event AccountStateHandler Added;

        protected internal event AccountStateHandler Opened;

        protected internal event AccountStateHandler Closed;

        protected internal event AccountStateHandler Calculated;

        protected int _id;

        static int counter = 0;

        protected decimal _sum;

        protected int _percentage;

        protected int _days;

        public Account(decimal sum, int perc)
        {
            _sum = sum;
            _percentage = perc;
            _id =++ counter;
        }

        public int Id
        {
            get { return _id; }
        }

        public decimal CurrentSum
        {
            get { return _sum; }
        }

        public int Days
        {
            get { return _days; }
        }

        private void CallEvent(AccountEventArgs e, AccountStateHandler handler)
        {
            if (handler != null && e != null)
                handler(this, e);
        }

        protected virtual void OnOpened(AccountEventArgs e)
        {
            CallEvent(e, Opened);
        }

        protected virtual void OnWithdrawed(AccountEventArgs e)
        {
            CallEvent(e, Withdrawed);
        }

        protected virtual void OnAdded(AccountEventArgs e)
        {
            CallEvent(e, Added);
        }

        protected virtual void OnClosed(AccountEventArgs e)
        {
            CallEvent(e, Closed);
        }

        protected virtual void OnCalculated(AccountEventArgs e)
        {
            CallEvent(e, Calculated);
        }

        public virtual void Put(decimal sum)
        {
            _sum += sum;
            OnAdded(new AccountEventArgs($"На счет поступило {sum}", sum));
        }

        public virtual decimal Withdraw(decimal sum)
        {
            decimal result = 0;
            if (sum <= _sum)
            {
                _sum -= sum;
                result = sum;
                OnWithdrawed(new AccountEventArgs($"Сумма {sum} снята со счета {_id}", sum));
            }
            else
            {
                OnWithdrawed(new AccountEventArgs($"Недостаточно денег на счете  {_id}", 0));
            }
            return result;
        }

        protected internal virtual void Open()
        {
            OnOpened(new AccountEventArgs($"Открыт новый счет! Id счета: {_id}", this._sum));
        }

        protected internal virtual void Close()
        {
            OnClosed(new AccountEventArgs($"Счет {_id} закрыт. Итоговая сумма: {CurrentSum}", CurrentSum));
        }

        protected internal void IncrementDays()
        {
            _days++;
        }

        protected internal virtual void Calculate()
        {
            decimal increment = _sum * _percentage / 100;
            _sum = _sum + increment;
            OnCalculated(new AccountEventArgs($"Начисленны проценты в размере: {increment}", increment));
        }
    }
}
