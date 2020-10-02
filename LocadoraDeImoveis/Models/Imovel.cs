﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("Imoveis")]
    public class Imovel:BaseModel
    {
        public string Descricao { get; set; }
        public bool Locado { get; set; }
        public int TipoImovel { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public double ValorAluguel { get; set; }
        public double Area { get; set; }
        public int Corretor { get; set; }

    }
}
