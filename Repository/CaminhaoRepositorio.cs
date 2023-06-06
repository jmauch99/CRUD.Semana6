using CRUDSemana6.Data;
using CRUDSemana6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDSemana6.Repository
{
    public class CaminhaoRepositorio : ICaminhaoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public CaminhaoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public CaminhaoModel ListarPorId(int id)
        {
            return _bancoContext.Caminhoes.FirstOrDefault(x => x.Id == id);
        }

        public List<CaminhaoModel> BuscarTodos()
        {
            return _bancoContext.Caminhoes.ToList();
        }

        public CaminhaoModel Adicionar(CaminhaoModel caminhao)
        {
            //Gravar no Banco de Dados
            _bancoContext.Caminhoes.Add(caminhao);
            _bancoContext.SaveChanges();
            return caminhao;
        }

        public CaminhaoModel Atualizar(CaminhaoModel caminhao)
        {
            CaminhaoModel caminhaoDb = ListarPorId(caminhao.Id);

            if (caminhaoDb == null) throw new SystemException("Houve um erro na atualização do Caminhão!");

            caminhaoDb.Nome = caminhao.Nome;
            caminhaoDb.Descricao = caminhao.Descricao;

            _bancoContext.Caminhoes.Update(caminhaoDb);
            _bancoContext.SaveChanges();

            return caminhaoDb;
        }

        public bool Apagar(int id)
        {
            CaminhaoModel caminhaoDb = ListarPorId(id);
            if (caminhaoDb == null) throw new SystemException("Houve um erro na deleção do Caminhão!");

            _bancoContext.Caminhoes.Remove(caminhaoDb);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
