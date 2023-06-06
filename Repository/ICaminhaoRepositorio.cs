using CRUDSemana6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDSemana6.Repository
{
    public interface ICaminhaoRepositorio
    {
        CaminhaoModel ListarPorId(int id);
        List<CaminhaoModel> BuscarTodos();
        CaminhaoModel Adicionar(CaminhaoModel caminhao);
        CaminhaoModel Atualizar(CaminhaoModel caminhao);
        bool Apagar(int id);


    }
}
