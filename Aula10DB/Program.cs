using Microsoft.Data.Sqlite;
using Aula10DB.Database;
using Aula10DB.Repositories;
using Aula10DB.Models;


var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);
var pedidoRepository = new PedidoRepository(databaseConfig);
var clienteRepository = new ClienteRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];


if(modelName == "Cliente")
{
    if(modelAction == "Listar")
    {
        Console.WriteLine("Cliente Listado!");
        foreach (var cliente in clienteRepository.GetAll())
        {
            Console.WriteLine($"{cliente.ClienteID}, {cliente.Endereco}, {cliente.Cidade}, {cliente.Regiao}, {cliente.Codigopostal}, {cliente.Pais} ,{cliente.Telefone}");
        }
    }

    if(modelAction == "Inserir")
    {
        Console.WriteLine("Cliente Inserido!");

        var clienteID = Convert.ToInt32(args[2]);   
        string endereco  = args[3];
        string cidade  = args[4];
        string regiao  = args[5];
        string codigoPostal  = args[6];
        string pais  = args[7];
        string telefone  = args[8];
       
        var cliente = new Cliente(clienteID, endereco, cidade, regiao, codigoPostal, pais, telefone);
        clienteRepository.Save(cliente);
    }


    if(modelAction == "Apresentar")
    {
        Console.WriteLine("Apresentar Cliente");
	    Console.Write("Digite o id do cliente : ");
        var clienteid = Convert.ToInt32(Console.ReadLine());
       
        if(clienteRepository.ExitsById(clienteid))
        {
            var cliente = clienteRepository.GetById(clienteid);
            Console.WriteLine($"{cliente.ClienteID}, {cliente.Endereco}, {cliente.Cidade}, {cliente.Regiao}, {cliente.Codigopostal}, {cliente.Pais}, {cliente.Telefone}");
        } 
        else 
        {
            Console.WriteLine($"O cliente com Id {clienteid} não existe.");
        }
    }
}


 



if(modelName == "Pedido")
{
    if(modelAction == "Listar")
    {
        Console.WriteLine("Pedido Listado!");
        foreach (var pedido in pedidoRepository.GetAll())
        {
            Console.WriteLine($"{pedido.PedidoID}, {pedido.EmpregadoID}, {pedido.DataPedido}, {pedido.Peso}, {pedido.CodTransportadora}, {pedido.PedidoClienteID}");
        }
    }

    if(modelAction == "Inserir")
    {
        Console.WriteLine("Pedido Inserido!");
        var pedidoId = Convert.ToInt32(args[2]);
        var empregadoID = Convert.ToInt32(args[3]);
        string dataPedido = args[4];
        string peso = args[5];
        var codTransportadora = Convert.ToInt32(args[6]);
        var pedidoClienteID = Convert.ToInt32(args[7]);
        var pedido = new Pedido(pedidoId, empregadoID, dataPedido, peso, codTransportadora, pedidoClienteID);
        pedidoRepository.Save(pedido);
    }

    if(modelAction == "Apresentar")
    {
        Console.WriteLine("Apresentar Pedido");
	    Console.Write("Digite o id do pedido : ");
        var pedidoid = Convert.ToInt32(Console.ReadLine());
       
        if(pedidoRepository.ExitsById(pedidoid))
        {
            var pedido = pedidoRepository.GetById(pedidoid);
            Console.WriteLine($"{pedido.PedidoID}, {pedido.EmpregadoID}, {pedido.DataPedido}, {pedido.Peso}, {pedido.CodTransportadora}, {pedido.PedidoClienteID}");
        } 
        else 
        {
            Console.WriteLine($"O cliente com Id {pedidoid} não existe.");
        }
    }
 
   if(modelAction == "MostrarPedidosCliente")
    {
        Console.WriteLine("Mostrar Pedidos do Cliente");
	    Console.Write("Digite o id do cliente : ");
        var clienteid = Convert.ToInt32(Console.ReadLine());
       
        if(clienteRepository.ExitsById(clienteid))
        {
          foreach (var pedido in pedidoRepository.GetAll()){
            if(pedido.PedidoClienteID == clienteid){
            Console.WriteLine($"{pedido.PedidoID}, {pedido.EmpregadoID}, {pedido.DataPedido}, {pedido.Peso}, {pedido.CodTransportadora}, {pedido.PedidoClienteID}");
            }
          }
        } 
        else 
        {
            Console.WriteLine($"O cliente com Id {clienteid} não existe.");
        }
    }
}
