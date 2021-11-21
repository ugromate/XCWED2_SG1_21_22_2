using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_HFT_2021221.Logic.Interfaces;
using XCWED2_HFT_2021221.Models.Entities;
using XCWED2_HFT_2021221.Models.Models;
using XCWED2_HFT_2021221.Repository.Interfaces;

namespace XCWED2_HFT_2021221.Logic.Services
{
    public class DesignerLogic : IDesignerLogic
    {
        IBoardGameRepository _boardGameRepository;
        IPublisherRepository _publisherRepository;
        IDesignerRepository _designerRepository;

        public DesignerLogic(IBoardGameRepository boardGameRepository, IPublisherRepository publisherRepository, IDesignerRepository designerRepository)
        {
            _boardGameRepository = boardGameRepository;
            _publisherRepository = publisherRepository;
            _designerRepository = designerRepository;
        }

        public Designer Create(Designer entity)
        {
            // TODO check access

            // TODO: validate !!! 

            var result = _designerRepository.Create(entity);

            // TODO: log

            return result;
        }
        public Designer Read(int id)
        {
            return _designerRepository.Read(id);
        }

        public IList<Designer> ReadAll()
        {
            return _designerRepository.ReadAll().ToList();
        }

        public Designer Update(Designer entity)
        {
            // TODO check access

            // TODO: validate !!!

            // TODO: map only what can be changed

            var result = _designerRepository.Update(entity);

            // TODO: log

            return result;
        }
        public void Delete(int id)
        {
            // TODO check access

            // TODO: check relations (can I delete)

            _designerRepository.Delete(id);
        }

        public string MostPopularDesigner()
        {
            var averages = from boardgame in _boardGameRepository.ReadAll()
                           group boardgame by boardgame.DesignerID into grouped
                           select new
                           {
                               DesignerID = grouped.Key,
                               Average = grouped.Average(x => x.Rating)
                           };
            var result = from designer in _designerRepository.ReadAll()
                         join average in averages
                         on designer.Id equals average.DesignerID
                         select new AverageDesigner()
                         {
                             DesignerName = designer.Name,
                             AverageRating = average.Average
                         };

            var designerList = result.OrderByDescending(x => x.AverageRating);
            var mostpopularDesigner = designerList.FirstOrDefault();

            return mostpopularDesigner.ToString();
        }

        public void GamesByNationality()
        {
            var games = from boardgame in _boardGameRepository.ReadAll()
                        group boardgame by boardgame.DesignerID into grouped
                        select new
                        {
                            DesignerID = grouped.Key,
                            Count = grouped.Count()
                        };

            var countryList = from designer in _designerRepository.ReadAll()
                              join game in games
                              on designer.Id equals game.DesignerID
                              select new
                              {
                                  Nationality = designer.Nationality,
                                  Count = game.Count
                              };

            var list = countryList.ToList();

            var gameNumber = games.Count();

            Console.WriteLine("There are " + gameNumber + " games in the database");

            foreach (var item in list)
            {
                Console.WriteLine(item.Nationality + " - " + item.Count);
            }
        }
    }
}
