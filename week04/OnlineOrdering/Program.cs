using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Jordan Lee", address1);

        List<Product> products1 = new List<Product>();
        products1.Add(new Product("Wireless Mouse", "A100", 25.00, 2));
        products1.Add(new Product("Keyboard", "A101", 45.00, 1));
        products1.Add(new Product("USB Cable", "A102", 8.50, 3));

        Order order1 = new Order(products1, customer1);

        Address address2 = new Address("45 King Street", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Priya Sharma", address2);

        List<Product> products2 = new List<Product>();
        products2.Add(new Product("Desk Lamp", "B200", 30.00, 1));
        products2.Add(new Product("Notebook", "B201", 4.00, 5));

        Order order2 = new Order(products2, customer2);

        List<Order> orders = new List<Order>();
        orders.Add(order1);
        orders.Add(order2);

        foreach (Order order in orders)
        {
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());

            Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
            Console.WriteLine();
        }
    }
}
