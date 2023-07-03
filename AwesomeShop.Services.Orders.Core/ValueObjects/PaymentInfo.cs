using System;

namespace AwesomeShop.Services.Orders.Core.ValueObjects
{
    public class PaymentInfo
    {
        public string CardNumber { get; private set; }
        public string FullName { get; private set; }
        public string Expiration { get; private set; }
        public string CVV { get; private set; }

        public PaymentInfo(string cardNumber, string fullName, string expiration, string cVV)
        {
            CardNumber = cardNumber;
            FullName = fullName;
            Expiration = expiration;
            CVV = cVV;
        }

        public override bool Equals(object obj)
        {
            return obj is PaymentInfo info &&
                   CardNumber == info.CardNumber &&
                   FullName == info.FullName &&
                   Expiration == info.Expiration &&
                   CVV == info.CVV;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CardNumber, FullName, Expiration, CVV);
        }
    }
}
