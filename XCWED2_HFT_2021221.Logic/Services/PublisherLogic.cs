using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_HFT_2021221.Logic.Interfaces;
using XCWED2_HFT_2021221.Logic.Models;
using XCWED2_HFT_2021221.Models.Entities;
using XCWED2_HFT_2021221.Repository.Interfaces;

namespace XCWED2_HFT_2021221.Logic.Services
{
    class PublisherLogic : IPublisherLogic
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
            // TODO check access

            // TODO: validate !!! 

            var result = _publisherRepository.Create(entity);

            // TODO: log

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
            // TODO check access

            // TODO: validate !!!

            // TODO: map only what can be changed

            var result = _publisherRepository.Update(entity);

            // TODO: log

            return result;
        }

        public void Delete(int id)
        {
            // TODO check access

            // TODO: check relations (can I delete)

            _publisherRepository.Delete(id);
        }

        public IEnumerable<AverageModel> GetPublisherAverages()
        {
            var averages = from boardgame in _boardGameRepository.ReadAll()
                           group boardgame by boardgame.Id into grouped
                           select new
                           {
                               PublisherId = grouped.Key,
                               Average = grouped.Average(x => x.PriceHUF)
                           };

            var result = from publisher in _publisherRepository.ReadAll()
                         join average in averages
                         on publisher.Id equals average.PublisherId
                         select new AverageModel()
                         {
                             PublisherName = publisher.Name,
                             Average = average.Average
                         };

            return result.ToList();
        }
    }
}
