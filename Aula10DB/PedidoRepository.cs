
using Aula10DB.Database;
using Aula10DB.Models;
using Microsoft.Data.Sqlite;
namespace Aula10DB.Repositories;
class PedidoRepository
{
private readonly DatabaseConfig _databaseConfig;

public PedidoRepository (DatabaseConfig databaseConfig)
{
_databaseConfig = databaseConfig;
}

public List<Pedido> GetAll() 
{
    
var pedidos = new List<Pedido>();


var connection = new SqliteConnection(_databaseConfig.ConnectionString);
connection.Open();

var command = connection.CreateCommand();
command.CommandText = "SELECT * FROM Pedido";

var reader = command.ExecuteReader();

while(reader.Read())
{
var PedidoID = reader.GetInt32(0);
var EmpregadoID = reader.GetString(1);
var DataPedido = reader.GetString(2);
var Peso = reader.GetInt32(3);
var CodTransportadora = reader.GetString(4);
var PedidoClienteId = reader.GetString(5);


var pedido = ReaderToPedido(reader);


pedidos.Add(pedido);
}

connection.Close();

return pedidos;
}

public Pedido Save(Pedido pedido)
{
var connection = new SqliteConnection(_databaseConfig.ConnectionString);
connection.Open();

var command = connection.CreateCommand();


command.CommandText = "INSERT INTO Pedido VALUES($PedidoID, $EmpregadoID, $DataPedido, $Peso, $CodTransportadora, $PedidoClienteID)";
command.Parameters.AddWithValue("$PedidoID", pedido.PedidoID);
command.Parameters.AddWithValue("$EmpregadoID", pedido.EmpregadoID);
command.Parameters.AddWithValue("$DataPedido", pedido.DataPedido);
command.Parameters.AddWithValue("$Peso", pedido.Peso);
command.Parameters.AddWithValue("$CodTransportadora", pedido.CodTransportadora);
command.Parameters.AddWithValue("$PedidoClienteID", pedido.PedidoClienteID);
command.ExecuteNonQuery();
connection.Close();

return pedido;
}
public Pedido GetById(int id)
{
var connection = new SqliteConnection(_databaseConfig.ConnectionString);
connection.Open();

var command = connection.CreateCommand();
command.CommandText = "SELECT * FROM Pedido WHERE (id = $id)";
command.Parameters.AddWithValue("$id", id);

var reader = command.ExecuteReader();
reader.Read();

var pedido = ReaderToPedido(reader);

connection.Close();

return pedido;
}

public bool ExitsById(int id)
{
var connection = new SqliteConnection(_databaseConfig.ConnectionString);
connection.Open();

var command = connection.CreateCommand();
command.CommandText = "SELECT count(id) FROM Pedido WHERE (id = $id)";
command.Parameters.AddWithValue("$id", id);
var reader = command.ExecuteReader();
reader.Read();
var result = reader.GetBoolean(0);

return result;
}


private Pedido ReaderToPedido(SqliteDataReader reader)
{
var pedido = new Pedido(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));
return pedido;
}
}
