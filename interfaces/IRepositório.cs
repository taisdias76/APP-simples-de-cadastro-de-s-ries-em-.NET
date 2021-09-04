using System;
using System.Collections.Generic;
using System.Text;

namespace series.Interfaces
{
  public interface IRepositorio<T>
    {
        List<T> Lista();
        T RertonarPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();

    }
}