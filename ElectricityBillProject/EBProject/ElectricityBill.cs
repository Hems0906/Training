using System;

namespace ElectricityBillingSystem
{
    public class ElectricityBill
    {
        public int BillNo { get; set; }
        public string ConsumerNumber { get; set; }
        public string ConsumerName { get; set; }
        public int UnitsConsumed { get; set; }
        public double BillAmount { get; set; }
        public DateTime BillDate { get; set; }

    }
}
