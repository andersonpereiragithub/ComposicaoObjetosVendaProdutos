using System;
using OrdemDePedidosExercicio.Entities;
using OrdemDePedidosExercicio.Entities.Enums;

namespace OrdemDePedidosExercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            //Client client = new Client();
            Console.WriteLine("Entre com inforamções sobre o Cliente:");
            Console.Write("Nome: ");
            //client.Name = Console.ReadLine();
            string clienteName = Console.ReadLine();

            Console.Write("E-mail: ");
            //client.Email = Console.ReadLine();
            string Email = Console.ReadLine();

            Console.Write("Data de Nascimento (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Insira os dados do pedido: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(clienteName, Email, birthDate);
            
            Order pedido = new Order(DateTime.Now, status, client);
                        
            Console.Write("Quantos itens há neste pedido: ");
            int qntde = int.Parse(Console.ReadLine());

            for (int i = 1; i <= qntde; i++)
            {
                Console.WriteLine($"Inserir os dados do item #{i}: ");
                Console.Write("Nome do Produto: ");
                string nameProduct = Console.ReadLine();

                Console.Write("Preço: ");
                double preco = double.Parse(Console.ReadLine());

                Console.Write("Quantidade: ");
                int unidades = int.Parse(Console.ReadLine());

                Product newProduct = new Product(nameProduct, preco);

                OrderItem orderItem = new OrderItem(unidades, preco, newProduct);

                pedido.AddItem(orderItem);
            }
            Console.WriteLine();
            Console.WriteLine("Resumo do pedido:");
            Console.WriteLine(pedido);
        }
    }
}
