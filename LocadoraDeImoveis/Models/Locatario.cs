using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("Locatarios")]
    public class Locatario:Pessoa
    {
        public double RendaDisponivel { get; set; }
    }
}
