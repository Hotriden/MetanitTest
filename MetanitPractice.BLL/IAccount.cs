using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPractice.BLL
{
    interface IAccount
    {
        void Put(decimal sum);

        decimal Withdraw(decimal sum);
    }
}
