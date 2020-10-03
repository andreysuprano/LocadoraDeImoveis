using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("Locatarios")]
    class Locatario:Pessoa
    {
        public double RendaDisponivel { get; set; }
    }
}
