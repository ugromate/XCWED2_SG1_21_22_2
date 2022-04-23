using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.WpfClient.BL.Interfaces;
using XCWED2_SG1_21_22_2.WpfClient.Infrastructure;
using XCWED2_SG1_21_22_2.WpfClient.Models;

namespace XCWED2_SG1_21_22_2.WpfClient.BL.Implementation
{
    public class BoardGameHandlerService : IBoardGameHandlerService
    {
        readonly IMessenger messenger;
        readonly IBoardGameEditorService editorService;
        readonly IBoardGameDisplayService displayService;
        HttpService httpService;

        public BoardGameHandlerService(IMessenger messenger, IBoardGameEditorService editorService, IBoardGameDisplayService displayService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
            this.displayService = displayService;
            httpService = new HttpService("BoardGame", "http://localhost:48914/api/");
        }

        public void AddBoardGame(IList<BoardGameModel> collection)
        {
            throw new NotImplementedException();
        }

        public void DeleteBoardGame(IList<BoardGameModel> collection, BoardGameModel boardGame)
        {
            throw new NotImplementedException();
        }

        public IList<BoardGameModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<DesignerModel> GetAllDesigner()
        {
            throw new NotImplementedException();
        }

        public IList<PublisherModel> GetAllPublisher()
        {
            throw new NotImplementedException();
        }

        public void ModifyBoardGame(IList<BoardGameModel> collection, BoardGameModel boardGame)
        {
            throw new NotImplementedException();
        }

        public void ViewBoardGame(BoardGameModel boardGame)
        {
            throw new NotImplementedException();
        }
    }
}
