
namespace LocadoraDeImoveis.Models
{
    public class Pessoa:BaseModel
    {
        private string Nome { get; set; }
        private string Cpf { get; set; }
        private string Email { get; set; }
        private string Telefone { get; set; }
        private string Cidade { get; set; }
        private string UF { get; set; }

    }
}
