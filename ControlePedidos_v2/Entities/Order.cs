using ControlePedidos_v2.Entities.Enums;
using System.Text;

namespace ControlePedidos_v2.Entities
{
     class Order
    {

        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }

        public List<OrderItem> Itens { get; set; } = new List<OrderItem>();

        public Client Client { get; set; }

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem (OrderItem item)
        {
            Itens.Add(item);
        }

        public void RemoveItem (OrderItem item)
        {
            Itens.Remove(item);
        }

        public double Total()
        {
            double total = 0;
            
            foreach (OrderItem item in Itens)
            {
                total += item.SubTotal();
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("ORDER SUMARY");
            stringBuilder.Append("Order moment: "+ Moment.ToString("dd/mm/yyyy HH:mm:ss"));
            stringBuilder.AppendLine("Order status: "+ Status);
            stringBuilder.AppendLine("Client: "+ Client);
            stringBuilder.AppendLine("Order items: ");
            
            foreach (OrderItem item in Itens)
            {
                stringBuilder.AppendLine(item.ToString());
              
               
            }

            stringBuilder.AppendLine("Total price: $"+Total());
           
            return stringBuilder.ToString();
        }
    }
}
