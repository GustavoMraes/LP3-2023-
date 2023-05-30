namespace Aula10DB.Models;

class Cliente 
{
    public int ClienteID { get; set; }
    public string Endereco { get; set; }
    public string Cidade { get; set; }
    public string Regiao { get; set; }
    public string Codigopostal { get; set; }
    public string Pais { get; set; }
    public string Telefone { get; set; }    


    public Cliente(int clienteid, string endereco, string cidade, string regiao, string codigopostal, string pais, string telefone)
    {
        ClienteID = clienteid;
        Endereco = endereco;
        Cidade = cidade;
        Regiao = regiao;
        Codigopostal = codigopostal;
        Pais = pais;
        Telefone = telefone;      
    }  
}