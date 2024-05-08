using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSamples.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public System.DateTime Sent { get; set; }
        public int TrackingNumber { get; set; }
        public Order OrderId { get; set; }

    }
}
