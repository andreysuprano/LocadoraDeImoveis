using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("Locatarios")]
    public class Locatario:Pessoa
    {
        private double RendaDisponivel { get; set; }
    }
}
