using ControlePedidos_v2.Entities.Enums;

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
    }
}
