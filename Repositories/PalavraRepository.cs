using MegaSenhaApi.Database;
using MegaSenhaApi.Helper;
using MegaSenhaApi.Models;
using MegaSenhaApi.Repositories.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaSenhaApi.Repositories
{
    public class PalavraRepository : IPalavraRepository
    {
        private readonly MegaSenhaContext _banco;
        public PalavraRepository(MegaSenhaContext banco)
        {
            _banco = banco;
        }
        public PaginationList<Palavra> ObterPalavras(PalavraUrlQuery query)
        {
            var lista = new PaginationList<Palavra>();
            var item = _banco.Palavras.AsNoTracking().AsQueryable();
            if (query.Data.HasValue)
            {
                item = item.Where(a => a.Criado > query.Data.Value || a.Atualizado > query.Data.Value);
            }
            lista.Results.AddRange(item.ToArray());
            return lista;
        }

        public IEnumerable<Palavra> GetPalavra(PalavraUrlQuery query)
        {
            var item = _banco.Palavras.AsNoTracking().AsQueryable();
            if (query.Data.HasValue)
                item = item.Where(a => a.Criado > query.Data.Value || a.Atualizado > query.Data.Value);

            return item.ToArray();
        }

        public Palavra Obter(int id)
        {
            return _banco.Palavras.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public void Cadastrar(Palavra palavra)
        {
            _banco.Palavras.Add(palavra);
            _banco.SaveChanges();
        }

        public void Atualizar(Palavra palavra)
        {
            _banco.Palavras.Update(palavra);
            _banco.SaveChanges();
        }

        public void Deletar(int id)
        {
            var palavra = Obter(id);
            palavra.Ativo = false;
            _banco.Palavras.Update(palavra);
            _banco.SaveChanges();
        }

    }
}
