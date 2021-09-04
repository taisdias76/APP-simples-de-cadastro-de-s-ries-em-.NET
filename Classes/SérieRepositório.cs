using System;
using System.Collections.Generic;
using series.Interfaces;

namespace series
{
    public class SerieRepositorio : IRepositorio<serie>
    {
        private List<serie> listaSerie = new List<serie>();
        public void Atualiza(int id, serie objeto)
        {
            listaSerie[id] =  objeto;
            throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public serie RertonarPorId(int id)
        {
           return listaSerie[id];
        }

        internal void Exclui(object indiceSerie)
        {
            throw new NotImplementedException();
        }
    }
}