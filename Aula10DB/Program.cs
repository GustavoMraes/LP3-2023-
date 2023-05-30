    using Microsoft.Data.Sqlite;
using Aula10DB.Database;
using Aula10DB.Repositories;
using Aula10DB.Models;


var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);

var clienteRepository = new ClienteRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];


if(modelName == "Cliente")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Cliente Listar");
        foreach (var cliente in clienteRepository.GetAll())
        {
            Console.WriteLine($"{cliente.ClienteID}, {cliente.Endereco}, {cliente.Cidade}, {cliente.Regiao}, {cliente.CodigoPostal}, {cliente.Pais} ,{cliente.Telefone}");
        }
    }

    if(modelAction == "New")
    {
        Console.WriteLine("Cliente Inserir");



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
    
}
