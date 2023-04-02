using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCBarcelonaApp.Models.Order
{
    public class OrderIndexVM
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.Identuty)]
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public string UserId { get; set; }
        public string User { get; set; }
        public int GameId { get; set; }
        public DateTime DateOfGame { get; set; }

        public string Game  { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
      
        public decimal TotalPrice { get; set; }
    }
}
