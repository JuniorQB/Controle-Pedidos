using ControlePedidos_v2.Entities;
using ControlePedidos_v2.Entities.Enums;

namespace ControlePedidos
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter order data:");
            Console.Write("Status [PendingPayment/Processing/Shipped/Delivered]:");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.WriteLine("How many items to this order?");
            int qtdeItems = int.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Order order = new Order(DateTime.Now, status, client);

            for (int i = 0; i < qtdeItems; i++)
            {
                Console.WriteLine($"Enter {i} item data:");
                Console.Write("Product Name: ");
                string productName = Console.ReadLine();
                Console.Write("Product Price: ");
                double productPrice = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);

                OrderItem orderItem = new OrderItem(quantity, productPrice, product);
                order.AddItem(orderItem);
                

            }

            Console.WriteLine(order);



        }
    }
}