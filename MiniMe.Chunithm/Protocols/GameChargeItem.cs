using System;

namespace MiniMe.Chunithm.Protocols
{
    public class GameChargeItem
    {
        public int OrderId { get; set; }

        public int ChargeId { get; set; }

        public int Price { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public int SalePrice { get; set; }

        public DateTimeOffset SaleStartDate { get; set; }

        public DateTimeOffset SaleEndDate { get; set; }
    }
}
