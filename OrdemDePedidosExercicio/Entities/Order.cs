using OrdemDePedidosExercicio.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OrdemDePedidosExercicio.Entities
{
    class Order
    {
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> OrdemItems { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order(DateTime date, OrderStatus status, Client client)
        {
            Date = date;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem product)
        {
            OrdemItems.Add(product);
        }
        public void RemoveItem(OrderItem product)
        {
            OrdemItems.Remove(product);
        }
        public double Total()
        {
            double sum = 0.0;
            foreach (var prod in OrdemItems)
            {
                sum += prod.SubTotal();
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Momento do Pedido: " + Date.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Status do Pedido: " + Status);//ERRO aqui.
            sb.AppendLine("Cliente: " + Client);
            sb.AppendLine("Itens do pedido:");

            foreach (OrderItem item in OrdemItems)
            { //ERRO aqui.
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Preço Total: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
