using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Series.src;
public class SerieRepository : IRepository<Serie>
{
    private List<Serie> listSerie = new List<Serie>();
  public void Delete(int id)
  {
      listSerie[id].Delete();
  }

  public Serie getById(int id)
  {
      return listSerie[id];
  }

  public List<Serie> ListAll()
  {
      return listSerie;
  }

  public int NextId()
  {
      return listSerie.Count;
  }

  public void Insert(Serie serie)
  {
      listSerie.Add(serie);
  }

  public void Update(int id, Serie serie)
  {
      listSerie[id] = serie;
  }
}
