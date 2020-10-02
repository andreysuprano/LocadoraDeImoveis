using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("Corretores")]
    public class Corretor:Pessoa
    {
        public string Cofeci { get; set; }
    }
}
