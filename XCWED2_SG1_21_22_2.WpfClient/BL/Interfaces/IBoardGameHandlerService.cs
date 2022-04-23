using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.WpfClient.Models;

namespace XCWED2_SG1_21_22_2.WpfClient.BL.Interfaces
{
   public interface IBoardGameHandlerService
    {
        void AddBoardGame(IList<BoardGameModel> collection);

        void ModifyBoardGame(IList<BoardGameModel> collection, BoardGameModel boardGame);

        void DeleteBoardGame(IList<BoardGameModel> collection, BoardGameModel boardGame);

        void ViewBoardGame(BoardGameModel boardGame);

        IList<BoardGameModel> GetAll();

        IList<DesignerModel> GetAllDesigner();

        IList<PublisherModel> GetAllPublisher();
    }
}
