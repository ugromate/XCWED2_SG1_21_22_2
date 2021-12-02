using System;
using System.Collections.Generic;
using System.Linq;
using XCWED2_HFT_2021221.Logic.Interfaces;
using XCWED2_HFT_2021221.Models.Entities;
using XCWED2_HFT_2021221.Models.Models;
using XCWED2_HFT_2021221.Repository.Interfaces;

namespace XCWED2_HFT_2021221.Logic.Services
{
    public class BoardGameLogic : IBoardGameLogic
    {
        IBoardGameRepository _boardGameRepository;
        IPublisherRepository _publisherRepository;
        IDesignerRepository _designerRepository;

        public BoardGameLogic(IBoardGameRepository boardGameRepository, IPublisherRepository publisherRepository, IDesignerRepository designerRepository)
        {
            _boardGameRepository = boardGameRepository;
            _publisherRepository = publisherRepository;
            _designerRepository = designerRepository;
        }

        public BoardGame Create(BoardGame entity)
        {

            if (entity == null)
            {
                throw new Exception();
            }

            var result = _boardGameRepository.Create(entity);

            return result;
        }
        public BoardGame Read(int id)
        {
            return _boardGameRepository.Read(id);
        }

        public IList<BoardGame> ReadAll()
        {
            return _boardGameRepository.ReadAll().ToList();
        }

        public BoardGame Update(BoardGame entity)
        {

            if (entity == null)
            {
                throw new Exception();
            }

            var result = _boardGameRepository.Update(entity);

            return result;
        }
        public void Delete(int id)
        {
            _boardGameRepository.Delete(id);
        }

        public int TwoKidGameCount()
        {
            var games = from boardgame in _boardGameRepository.ReadAll()
                        where boardgame.MinAge < 11 && boardgame.MinPlayer == 2
                        select new
                        {
                            Name = boardgame.Name
                        };
            return games.Count();
        }

        public BoardGame BestAlonePlayable()
        {
            var games = from boardgame in _boardGameRepository.ReadAll()
                        where boardgame.MinPlayer == 1
                        select boardgame;


            if (games == null)
            {
                throw new NullReferenceException();
            }

            var ordered = games.OrderByDescending(x => x.Rating);

            return (ordered.FirstOrDefault());
        }

        public IEnumerable<NationalityCount> GamesByDesignerNationality()
        {
            //var games = from boardgame in _boardGameRepository.ReadAll()
            //            group boardgame by boardgame.DesignerID into grouped
            //            select new
            //            {
            //                DesignerID = grouped.Key,
            //                Count = grouped.Count()
            //            };

            var countryList = from boardgame in _boardGameRepository.ReadAll()
                              join designer in _designerRepository.ReadAll()
                              on boardgame.DesignerID equals designer.Id
                              group boardgame by designer.Nationality into grouped
                              select new NationalityCount()
                              {
                                  Nationality = grouped.Key,
                                  Count = grouped.Count()
                              };

            var list = countryList.ToList().OrderByDescending(x => x.Count).ThenBy(x => x.Nationality);

            return list.ToList();
        }

    }
}
