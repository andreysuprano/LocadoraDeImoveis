﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeImoveis.Utils
{
    class BuscaCepUtils
    {
        public Cep BuscarCepService(string cep)
        {
            var client = new RestClient("https://viacep.com.br/");
            var request = new RestRequest("ws/{cep}/json/", DataFormat.Json)
                                            .AddUrlSegment("cep", cep);
            var response = client.Execute(request);
            var responseConvertida = JsonConvert.DeserializeObject<Cep>(response.Content);
            return responseConvertida;
        }
    }
    class Cep
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string unidade { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }        
    }
}
