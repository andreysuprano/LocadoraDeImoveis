﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraDeImoveis.Models
{
    [Table("Corretores")]
    class Corretor:Pessoa
    {
        public string Cofeci { get; set; }
        public string Sobrenome { get; set; }
        public string RG { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}
