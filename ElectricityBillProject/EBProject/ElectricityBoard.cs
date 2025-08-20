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
            double amount = 0;

            if (units <= 100)

            {

                amount = 0;

            }

            else if (units <= 300)

            {

                amount = (units - 100) * 1.5;

            }

            else if (units <= 600)

            {

                amount = (200 * 1.5) + (units - 300) * 3.5;

            }

            else if (units <= 1000)

            {

                amount = (200 * 1.5) + (300 * 3.5) + (units - 600) * 5.5;

            }

            else

            {

                amount = (200 * 1.5) + (300 * 3.5) + (400 * 5.5) + (units - 1000) * 7.5;

            }


            bill.BillAmount = amount;
            bill.BillDate = System.DateTime.Now;
        }
    }
}
