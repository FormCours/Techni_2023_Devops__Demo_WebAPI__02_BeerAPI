using Demo_WebAPI.BLL.Interfaces;
using Demo_WebAPI.BLL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_WebAPI.BLL.Services
{
    public class BeerService : IBeerService
    {
        private static List<Beer> _Beers = new List<Beer>()
        {
            new Beer(1, "Jupiler", "Pils", 1966, 5.6, "Jupiler"),
            new Beer(2, "Chimay Bleue", "Belgian Strong Dark Ale", 1862, 9.0, "Chimay"),
            new Beer(3, "Westmalle Tripel", "Tripel", 1934, 9.5, "Westmalle"),
            new Beer(4, "Orval", "Belgian Pale Ale", 1931, 6.2, "Orval"),
            new Beer(5, "Maes", "Pils", 1946, 5.2, "Maes"),
            new Beer(6, "Rochefort 10", "Quadrupel", null, 11.3, null),
            new Beer(7, "La Chouffe", "Belgian Strong Golden Ale", 1982, 8.0, null),
            new Beer(9, "Hoegaarden Wit", "Belgian White Ale", null, 4.9, "Hoegaarden")
        };
        private static int _LastId = 9;


        public IEnumerable<Beer> GetAll()
        {
            // Renvoi une copie de la liste warp dans une collection en lecture seul
            return _Beers.AsReadOnly();
        }

        public Beer? GetById(int id)
        {
            // Recherche de la biere via son ID (Olschool)
            Beer? beer = null;
            for (int i = 0; (i < _Beers.Count) && (beer is null); i++)
            {
                if (_Beers[i].Id == id)
                {
                    beer = _Beers[i];
                }
            }
            return beer;

            // Recherche de la biere via son ID (LinQ)
            return _Beers.SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Beer> GetByVariety(string variety)
        {
            // Recherche de la biere via sa varieté (Olschool)
            /*
            List<Beer> beersFound = new List<Beer>();
            foreach (Beer beer in _Beers)
            {
                if(beer.Variety.Contains(variety))
                {
                    beersFound.Add(beer);
                }
            }
            return beersFound;
            */

            // Recherche de la biere via sa varieté (Olschool + yield return)
            /*
            foreach (Beer beer in _Beers)
            {
                if (beer.Variety.Contains(variety))
                {
                    // Return "différé"
                    yield return beer;
                }
            }
            */

            // Recherche de la biere via sa varieté (LinQ)
            return _Beers.Where(b => b.Variety.Contains(variety));
        }

        public int? Add(Beer data)
        {
            if(data.Name == "Arnaud")
            {
                return null;
            }

            // Incrémentation de l'id
            _LastId++;

            // Création d'un nouvel object (=> Pour casser la ref mémoire)
            Beer beerAdded = new Beer(
                _LastId,
                data.Name,
                data.Variety,
                data.CreateDate,
                data.Degree,
                data.Brewery
            );

            // Ajout de la nouvelle biere
            _Beers.Add(beerAdded);

            // Envoi de l'id de la biere ajoutée
            return beerAdded.Id;
        }

        public bool Update(int id, Beer data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            int nbRemove = _Beers.RemoveAll(b => b.Id == id);
            return nbRemove == 1;
        }
    }
}
