namespace Hmwk8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bid
    {
        [Display(Name = "Bid ID")]
        public int ID { get; set; }

        [Display(Name = "Item ID")]
        public int ItemID { get; set; }

        [Display(Name = "Buyer ID")]
        public int BuyerID { get; set; }

        [Display(Name = "Price of Bid")]
        public decimal BidPRICE { get; set; }

        [Display(Name = "Bid Submit Time")]
        public DateTime BidTIMESTAMP { get; set; }

        public virtual Item Item { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
