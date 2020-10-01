using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("Imoveis")]
    public class Imovel:BaseModel
    {
        private string Descricao { get; set; }
        private bool Locado { get; set; }
        private int TipoImovel { get; set; }
        private string Cidade { get; set; }
        private string UF { get; set; }
        private double ValorAluguel { get; set; }
        private double Area { get; set; }
        private int Corretor { get; set; }

    }
}
