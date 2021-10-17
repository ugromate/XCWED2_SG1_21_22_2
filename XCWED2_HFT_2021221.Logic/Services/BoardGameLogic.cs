using System.Collections.Generic;
using System.Linq;
using XCWED2_HFT_2021221.Logic.Interfaces;
using XCWED2_HFT_2021221.Logic.Models;
using XCWED2_HFT_2021221.Models.Entities;
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
            // TODO check access

            // TODO: validate !!! 

            var result = _boardGameRepository.Create(entity);

            // TODO: log

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
            // TODO check access

            // TODO: validate !!!

            // TODO: map only what can be changed

            var result = _boardGameRepository.Update(entity);

            // TODO: log

            return result;
        }
        public void Delete(int id)
        {
            // TODO check access

            // TODO: check relations (can I delete)

            _boardGameRepository.Delete(id);
        }

    }
}
