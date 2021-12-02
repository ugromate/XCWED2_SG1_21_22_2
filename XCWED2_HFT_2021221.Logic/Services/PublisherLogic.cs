using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_HFT_2021221.Logic.Interfaces;
using XCWED2_HFT_2021221.Models.Entities;
using XCWED2_HFT_2021221.Repository.Interfaces;
using XCWED2_HFT_2021221.Models.Models;

namespace XCWED2_HFT_2021221.Logic.Services
{
  public  class PublisherLogic : IPublisherLogic
    {
        IBoardGameRepository _boardGameRepository;
        IPublisherRepository _publisherRepository;
        IDesignerRepository _designerRepository;

        public PublisherLogic(IBoardGameRepository boardGameRepository, IPublisherRepository publisherRepository, IDesignerRepository designerRepository)
        {
            _boardGameRepository = boardGameRepository;
            _publisherRepository = publisherRepository;
            _designerRepository = designerRepository;
        }

        public Publisher Create(Publisher entity)
        {

            if (entity == null)
            {
                throw new Exception();
            } 

            var result = _publisherRepository.Create(entity);

            return result;
        }
        public Publisher Read(int id)
        {
            return _publisherRepository.Read(id);
        }

        public IList<Publisher> ReadAll()
        {
            return _publisherRepository.ReadAll().ToList();
        }
        public Publisher Update(Publisher entity)
        {

            if (entity == null)
            {
                throw new Exception();
            }

            var result = _publisherRepository.Update(entity);

            // TODO: log

            return result;
        }

        public void Delete(int id)
        {
            _publisherRepository.Delete(id);
        }

        public IEnumerable<AveragePublisher> GetPublisherAverages()
        {
            var averages = from boardgame in _boardGameRepository.ReadAll()
                           group boardgame by boardgame.PublisherID into grouped
                           select new
                           {
                               PublisherId = grouped.Key,
                               Average = grouped.Average((x => x.PriceHUF))
                           };

            var result = from publisher in _publisherRepository.ReadAll()
                         join average in averages
                         on publisher.Id equals average.PublisherId
                         select new AveragePublisher()
                         {
                             PublisherName = publisher.Name,
                             Average = Math.Round(average.Average)
                         };

            return result.ToList();
        }
    }
}
