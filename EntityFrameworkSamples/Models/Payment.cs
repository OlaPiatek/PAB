using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSamples.Models
{
    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer,
        CashOnDelivery,
        GiftCard
    }
    public class Payment
    {

            public int Id { get; set; }
            public Order OrderId { get; set; }
            public int Amount { get; set; }

            public System.DateTime Created { get; set; }

            public PaymentMethod Method { get; set; }
    }
}
