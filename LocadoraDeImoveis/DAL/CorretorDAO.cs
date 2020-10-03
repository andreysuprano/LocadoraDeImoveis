using LocadoraDeImoveis.Models;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeImoveis.DAL
{
    class CorretorDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static Corretor BuscarPorNome(string nome) =>
            _context.Corretores.FirstOrDefault(x => x.Nome == nome);

        public static bool Cadastrar(Corretor corretor)
        {
            if (BuscarPorNome(corretor.Nome) == null)
            {
                _context.Corretores.Add(corretor);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Atualizar(Corretor corretor)
        {
            if (BuscarPorNome(corretor.Nome) != null)
            {
                _context.Corretores.Update(corretor);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static bool Remover(Corretor corretor)
        {            
            var c = _context.Corretores.Remove(corretor);
            _context.SaveChanges();

            if (c == null)
            {
                return false;
            }
            return true;
        }

        public static List<Corretor> Listar() => _context.Corretores.ToList();        
    }
}
