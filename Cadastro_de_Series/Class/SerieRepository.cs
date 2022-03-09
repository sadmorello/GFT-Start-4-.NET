using Cadastro_de_Series.Interface;

namespace Cadastro_de_Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();

        public void Insert(Serie entity)
        {
            listSerie.Add(entity);
        }
        public void Delete(int id)
        {
            listSerie[id].Delete();
        }
        public void Update(int id, Serie entity)
        {
            listSerie[id] = entity;
        }

        public List<Serie> List()
        {
            return listSerie;
        }
        public int NextId()
        {
            return listSerie.Count;
        }

        public Serie ReturnById(int id)
        {
            return listSerie[id];
        }
    }
}