
using Demo_WebAPI.BLL.Models;

namespace Demo_WebAPI.BLL.Interfaces
{
    // Note: Un service ne possede pas obligatoirement toutes les méthodes d'un CRUD
    //       Il doit avoir le necessaire pour le business ;)
    public interface IBeerService
    {
        IEnumerable<Beer> GetAll();

        Beer? GetById(int id);

        IEnumerable<Beer> GetByVariety(string variety);

        int? Add(Beer data);

        bool Update(int id, Beer data);

        bool Delete(int id);
    }
}
