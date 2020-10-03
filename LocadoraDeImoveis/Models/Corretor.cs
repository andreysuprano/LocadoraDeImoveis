using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("Corretores")]
    class Corretor:Pessoa
    {
        public string Cofeci { get; set; }
    }
}
