using EntityFrameworkSamples.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityFrameworkSamples.Models
{
    public enum OrderStatus
    {
        Draft,
        Pending_Payment,//przed oplaceniem
        Processing,//po oplaceniu
        Completed,
        Canceled
    }
    public class Order
    {
        public int Id { get; set; }
        public System.DateTime Created { get; set; }

        double TotalCost { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<LineItem> LineItems = new List<LineItem>();

        public User UserId { get; set; }

        public Order(OrderStatus status, DateTime date, User user)
        {
            Status = status;
            Created = date;
            UserId = user;
            foreach (var lineitem in LineItems)
            {
                TotalCost += lineitem.Cost;
            }
        }

        protected Order() { }
    }
}
