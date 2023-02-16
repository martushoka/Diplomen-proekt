using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Domain
{
    public class Order
    {
        public int Id { get; set; }
        [Required]

        public DateTime OrderDate { get; set; }

        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        [Required]

        [Range(0, 500)]

        public int Quantity { get; set; }
        [Required]

        [Range(0, 1000)]

        public decimal Price { get; set;  }

        public decimal TotalPrice
        {
            get
            {
                return Quantity * Price;
            }
        }

    }
}
