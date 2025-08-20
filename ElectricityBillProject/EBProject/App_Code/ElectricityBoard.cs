using System.Collections.Generic;

namespace ElectricityBillingSystem
{
    public class ElectricityBoard
    {
        private readonly DBHandler db = new DBHandler();

        public void AddBill(ElectricityBill bill)
        {
            db.AddBill(bill);
        }

        public List<ElectricityBill> Generate_N_BillDetails(int n)
        {
            return db.GetLastNBills(n);
        }

        public void CalculateBill(ElectricityBill bill)
        {
            int units = bill.UnitsConsumed;
            decimal amount = 0;

            if (units <= 100) amount = units * 1.0m;
            else if (units <= 300) amount = (100 * 1.0m) + ((units - 100) * 2.0m);
            else amount = (100 * 1.0m) + (200 * 2.0m) + ((units - 300) * 3.0m);

            bill.BillAmount = amount;
            bill.BillDate = System.DateTime.Now;
        }
    }
}
