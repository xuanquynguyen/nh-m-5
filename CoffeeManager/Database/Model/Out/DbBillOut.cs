using System;

namespace CoffeeManager
{
    public class DbBillOut
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
