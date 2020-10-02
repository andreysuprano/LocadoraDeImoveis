using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("TipoImovel")]
    class TipoImovel:BaseModel
    {
        public int Comissao { get; set; }
        public string Descricao { get; set; }
    }
}
