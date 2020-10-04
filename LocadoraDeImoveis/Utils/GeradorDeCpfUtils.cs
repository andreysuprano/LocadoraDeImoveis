using IronPdf;
using LocadoraDeImoveis.Models;
using System.IO;
using System.Reflection;

namespace LocadoraDeImoveis.Utils
{
    class GeradorDeCpfUtils
    { 

        public static void GetPdf(Contrato contrato, Corretor corretor, Imovel imovel, Locatario locatario)
        {
            var PathDestino = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var Renderer = new HtmlToPdf();
            Renderer.RenderHtmlAsPdf("<h1>Contrato de locação residencial</h1>" +
                                     "<br><h4>Locatario: "+locatario.Nome+"</h4>"+
                                     "<br><h4>Corretor: " + corretor.Nome + "</h4>"+
                                     "<br><h4>Endereço do Imóvel: " + imovel.Endereco+','+imovel.Cidade+','+imovel.UF+"</h4>"+
                                     "<br><h4>Valor do Aluguel: " +imovel.ValorAluguel+"</h4>"+
                                     "<br><br><br><br><br><br><h4>Assinaturas </h4>"+
                                     "<br><h4>"+locatario.Nome+":______________________________"+
                                     "<br><h4>"+corretor.Nome+":______________________________")
                .SaveAs(PathDestino.ToString()+$"..\\..\\..\\..\\ContratosPDF\\{contrato.Id+locatario.Nome}.pdf");
        }
    }
}
