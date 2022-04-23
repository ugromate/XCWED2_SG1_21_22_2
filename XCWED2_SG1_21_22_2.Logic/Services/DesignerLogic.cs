using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.Logic.Interfaces;
using XCWED2_SG1_21_22_2.Models.Entities;
using XCWED2_SG1_21_22_2.Models.Models;
using XCWED2_SG1_21_22_2.Repository.Interfaces;

namespace XCWED2_SG1_21_22_2.Logic.Services
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

            if (entity == null)
            {
                throw new Exception();
            }

            var result = _designerRepository.Create(entity);

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

            if (entity == null)
            {
                throw new Exception();
            }

            var result = _designerRepository.Update(entity);

            return result;
        }
        public void Delete(int id)
        {
            _designerRepository.Delete(id);
        }

        public AverageDesigner MostPopularDesigner()
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

            if (mostpopularDesigner == null)
            {
                return null;
            }
            else
            {
            return mostpopularDesigner;
            }
        }

    }
}
