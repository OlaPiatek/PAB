using EntityFrameworkSamples.Persistance;
using EntityFrameworkSamples.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        var sqliteConnectionString = "Data Source=EntityFrameworkSamples.db";
        var options = new DbContextOptionsBuilder<KioskDbContext>()
        .UseSqlite(sqliteConnectionString)
        .Options;
        using (var dbContext = new KioskDbContext(options))
        {

            var u1 = new User()
            {
                FirstName = "Ola",
                LastName = "Nowak",
                Email = "test@onet.pl"
            };
            var u2 = new User()
            {
                FirstName = "Basia",
                LastName = "Kowalska",
                Email = "test@wp.pl"
            };
            var c1 = new Category()
            {
                Name = CategoryName.TShirt
            };
            var c2 = new Category()
            {
                Name = CategoryName.Trousers
            };
            var c3 = new Category()
            {
                Name = CategoryName.Others
            };
            var p1 = new Product()
            {
                Name = "bluzka",
                UnitPrice = 30,
                Description="krotki rekaw",
                Category=c1
            };
            
            var p2 = new Product()
            {
                Name = "spodnie",
                UnitPrice = 50,
                Description = "czarne do kolan",
                Category=c2
            };
            
            var p3 = new Product()
            {
                Name = "apaszka",
                UnitPrice = 17,
                Description = "fioletowa",
                Category=c3
            };

            
            dbContext.Users.Add(u1);
            dbContext.Users.Add(u2);
            dbContext.Products.Add(p1);
            dbContext.Products.Add(p2);
            dbContext.Products.Add(p3);
            dbContext.Categories.Add(c1);
            dbContext.Categories.Add(c2);
            dbContext.Categories.Add(c3);

            var l1 = new LineItem(1, 0, p1);

            var l2 = new LineItem(2, 0, p2);
          
            var l3 = new LineItem(1, 0, p3);
  
            var z1 = new Order(OrderStatus.Draft,new DateTime(2024, 5, 8, 10, 20, 30),u1);


            z1.LineItems.Add(l1);
            z1.LineItems.Add(l2);

            var z2 = new Order(OrderStatus.Draft, new DateTime(2024, 03, 17, 13, 55, 30),u2);
            z2.LineItems.Add(l3);

            dbContext.Orders.Add(z1);
            dbContext.Orders.Add(z2);

            z1.Status = OrderStatus.Pending_Payment;

            var payment1 = new Payment()
            {
                //OrderId=z1,
                Amount=130,
                Method=PaymentMethod.BankTransfer

            };

            z1.Status=OrderStatus.Processing;
            //dbContext.SaveChanges();

            var list = dbContext.Orders.Where (s => s.Status == OrderStatus.Processing).ToList();
            
            foreach( var item in list)
            {
                Console.WriteLine("Zamówienia ze statusem „Processing”\n" + "Zamowienie nr. "+ item.Id+"\t"+item.Status+"\t"+item.Created);
            }
             
                
            var list2=dbContext.Orders.Where(s => s.Status == OrderStatus.Draft).ToList();

            foreach (var item in list2)
            {
                item.Status = OrderStatus.Pending_Payment;
            }

           // dbContext.Remove(z1);
            dbContext.SaveChanges();
        }
    }

}
