using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("Imoveis")]
    class Imovel:BaseModel
    {
        public string Endereco { get; set; }
        public bool Locado { get; set; }
        public TipoImovel TipoImovel { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public double ValorAluguel { get; set; }
        public double Area { get; set; }       

    }
}
