using System;

class Program
{
    static void Main(string[] args)
    {
        // ---- ADDRESS 1 ----
        Address address1 = new Address(
            "106 Elm Street",
            "Dallas",
            "Texas",
            "USA"
        );

        Customer customer1 = new Customer("Maria Silva", address1);

        Product p1 = new Product("Laptop", "A100", 1200, 1);
        Product p2 = new Product("Mouse", "M200", 25, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        Console.WriteLine("ORDER 1 PACKING LABEL");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("ORDER 1 SHIPPING LABEL");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"ORDER 1 TOTAL PRICE: ${order1.GetTotalPrice()}\n");


        // ---- ADDRESS 2 ----
        Address address2 = new Address(
            "56 Avenida Paulista",
            "São Paulo",
            "SP",
            "Brazil"
        );

        Customer customer2 = new Customer("João Pereira", address2);

        Product p3 = new Product("Headphones", "H300", 80, 1);
        Product p4 = new Product("Keyboard", "K150", 50, 1);

        Order order2 = new Order(customer2);
        order2.AddProduct(p3);
        order2.AddProduct(p4);

        Console.WriteLine("ORDER 2 PACKING LABEL");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("ORDER 2 SHIPPING LABEL");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"ORDER 2 TOTAL PRICE: ${order2.GetTotalPrice()}");
    }
}
