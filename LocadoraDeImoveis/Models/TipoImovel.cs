using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("TipoImovel")]
    class TipoImovel:BaseModel
    {
        private int Comissao { get; set; }
        private string Descricao { get; set; }
    }
}
