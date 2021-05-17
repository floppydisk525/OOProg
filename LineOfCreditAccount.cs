using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProgramming
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initalBalance, decimal creditLimit) : base(name, initalBalance, -creditLimit)
        {
        }

        public override void PerformMonthEndTransactions()
        {
            //base.PerformMonthEndTransactions();
            if(Balance < 0)
            {
                var interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }

        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
            isOverdrawn
            ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
            : default;

    }
}
