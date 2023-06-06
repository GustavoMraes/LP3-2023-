namespace Aula10DB.Models;

class Pedido    
{
    public int PedidoID { get; set; }
    public int EmpregadoID { get; set; }
    public string DataPedido { get; set; }
    public string Peso { get; set; }
    public int CodTransportadora { get; set; }
    public int PedidoClienteID { get; set; }   


    public Pedido(int pedidoID, int empregadoID, string dataPedido, string peso, int codTransportadora, int pedidoCliente)
    {
        PedidoID = pedidoID;
        EmpregadoID = empregadoID;
        DataPedido = dataPedido;
        Peso = peso;
        CodTransportadora = codTransportadora;
        PedidoClienteID = pedidoCliente;          
    }  
}
