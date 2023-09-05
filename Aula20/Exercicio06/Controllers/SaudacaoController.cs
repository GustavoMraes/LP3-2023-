using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
namespace Exercicio06.Controllers;

public class SaudacaoController : Controller
{
public IActionResult Index(){
    return View();
}

    public IActionResult Saudacao01(string SEU_NOME)
    {
        ViewData["Message"] = ($"{SEU_NOME}, seja bem vindo(a) ao IFSP");
        return View();
    }

    public IActionResult Saudacao02(string SEU_NOME)
    {
        ViewData["Message"] = ($"Olá {SEU_NOME}, você deverá desenvolver 6 atividades ao longo do semestre");
        return View();
    }

    public IActionResult Saudacao03(string Nome, string Periodo)
    {
        if (Periodo == "Matutino")
        {
            ViewData["Message"] = ($"SEDCITEC - 18 a 22 de Setembro - Ola {Nome}, como voce esta no periodo {Periodo}, devera participar da SEDCITEC no periodo das 07h:00m as 11h:45m");
        }
        else if(Periodo == "Verspertino"){
            ViewData["Message"] = ($"SEDCITEC - 18 a 22 de Setembro - Ola {Nome}, como voce esta no periodo {Periodo}, devera participar da SEDCITEC no periodo das 13h:15m as 18h:00m");
        }
        else{
            ViewData["Message"] = ("Periodo Invalido");
        }
        return View();
    }
}