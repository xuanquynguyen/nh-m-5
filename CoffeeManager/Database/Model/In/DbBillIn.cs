using System;

namespace CoffeeManager
{
    public class DbBillIn
    {
        public long Id;
        public long IdTable;
        public DateTime Date;
        public double TotalMoney;
        public bool Status;
        public string Description;
        public long IdUser;
        public long IdCustomer;
    }
}
