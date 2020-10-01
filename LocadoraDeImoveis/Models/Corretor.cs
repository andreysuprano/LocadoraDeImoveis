using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("Corretores")]
    public class Corretor:Pessoa
    {
        private string Cofeci { get; set; }
    }
}
