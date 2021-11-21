using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_HFT_2021221.Logic.Interfaces;
using XCWED2_HFT_2021221.Models.Entities;
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
    }
}
