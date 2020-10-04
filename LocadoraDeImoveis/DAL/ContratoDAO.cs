using LocadoraDeImoveis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocadoraDeImoveis.DAL
{
    class ContratoDAO
    {
        private static Context _context = SingletonContext.GetInstance();       
        public static Contrato BuscarPorId(int id) =>
            _context.Contratos.Find(id);

        public static bool Cadastrar(Contrato Contrato)
        {
            if (BuscarPorId(Contrato.Id) == null)
            {
                _context.Contratos.Add(Contrato);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Atualizar(Contrato Contrato)
        {
            if (BuscarPorId(Contrato.Id) != null)
            {
                _context.Contratos.Update(Contrato);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static bool Remover(Contrato Contrato)
        {
            var Corretor = BuscarPorId(Contrato.Id);
            var c = _context.Contratos.Remove(Contrato);
            _context.SaveChanges();

            if (c == null)
            {
                return false;
            }
            return true;
        }
        public static List<Corretor> FiltrarPorParteNome(string parteNome) =>
            _context.Corretores.Where(x => x.Nome.Contains(parteNome)).ToList();
        public static List<Contrato> Listar() => _context.Contratos.ToList();
    }
}
