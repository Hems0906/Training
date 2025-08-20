using System;

namespace ElectricityBillingSystem
{
    public class BillValidator
    {
        public void ValidateUnitsConsumed(int units)
        {
            if (units < 0)
                throw new ArgumentException("Units cannot be negative");
            if (units > 10000)
                throw new ArgumentException("Units consumed seems unusually high");
        }

        public void ValidateConsumerNumber(string consumerNo)
        {
            if (string.IsNullOrWhiteSpace(consumerNo))
                throw new ArgumentException("Consumer Number is required");

            if (consumerNo.Length < 5)
                throw new ArgumentException("Consumer Number must be at least 5 characters long");
        }

        public void ValidateConsumerName(string consumerName)
        {
            if (string.IsNullOrWhiteSpace(consumerName))
                throw new ArgumentException("Consumer Name is required");

            if (consumerName.Length < 3)
                throw new ArgumentException("Consumer Name must be at least 3 characters long");
        }
    }
}
