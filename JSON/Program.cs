using JSON.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SerializeObject
            Product laptop = new Product { Id = 1, Name = "Asus Zephyrus G14", Price = 3500 };
            Product headphones = new Product { Id = 2, Name = "JBL Giannis", Price = 350 };
            Product ssd = new Product { Id = 3, Name = "A400 SATA SSD", Price = 55 };
            OrderItem item1 = new OrderItem { Id = 1, Product = laptop, Count = 1, TotalPrice = laptop.Price * 1 };
            OrderItem item2 = new OrderItem { Id = 2, Product = ssd, Count = 4, TotalPrice = ssd.Price * 4 };
            OrderItem item3 = new OrderItem { Id = 3, Product = headphones, Count = 2, TotalPrice = headphones.Price * 2 };
            OrderItem item4 = new OrderItem { Id = 4, Product = laptop, Count = 1, TotalPrice = laptop.Price * 1 };
            List<OrderItem> orderItems1 = new List<OrderItem>();
            orderItems1.Add(item1);
            orderItems1.Add(item4);
            List<OrderItem> orderItems2 = new List<OrderItem>();
            orderItems2.Add(item3);
            orderItems2.Add(item2);
            Order order1 = new Order { Id = 1, orderItems = orderItems1 };
            Order order2 = new Order { Id = 1, orderItems = orderItems2 };
            var jsonObj = JsonConvert.SerializeObject(order1);
            using (StreamWriter sw = new StreamWriter(@"C:\Users\admin\OneDrive\İş masası\JSON\JSON\Files\json1.json"))
            {
                sw.WriteLine(jsonObj);
            }
            #endregion
            #region DeserializeObject
            string temp;
            using (StreamReader sr = new StreamReader(@"C:\Users\admin\OneDrive\İş masası\JSON\JSON\Files\json1.json"))
            {
                temp = sr.ReadToEnd();
            }
            Order order = JsonConvert.DeserializeObject<Order>(temp);
            Console.WriteLine(order.orderItems[0].Product.Id);
            Console.WriteLine(order.orderItems[0].Product.Name);
            Console.WriteLine(order.orderItems[1].Product.Id);
            Console.WriteLine(order.orderItems[1].Product.Name);
            #endregion
        }
    }
}
