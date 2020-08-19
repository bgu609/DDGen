using System;

namespace BogusTestApp
{
    public class Order
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public Decimal OrderValue { get; set; }
        public bool Shipped { get; set; }
    }
}
