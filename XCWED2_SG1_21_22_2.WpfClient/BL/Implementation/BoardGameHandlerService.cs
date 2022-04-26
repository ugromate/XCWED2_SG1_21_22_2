using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.Models.DTOs;
using XCWED2_SG1_21_22_2.Models.Entities;
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
        HttpService httpServiceDesigner;
        HttpService httpServicePublisher;

        public BoardGameHandlerService(IMessenger messenger, IBoardGameEditorService editorService, IBoardGameDisplayService displayService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
            this.displayService = displayService;
            httpService = new HttpService("BoardGame", "http://localhost:48914/api/");
            httpServiceDesigner = new HttpService("Designer", "http://localhost:48914/api/");
            httpServicePublisher = new HttpService("Publisher", "http://localhost:48914/api/");
        }

        public void AddBoardGame(IList<BoardGameModel> collection)
        {
            BoardGameModel boardGameToEdit = null;
            bool operationFinished = false;

            do
            {
                var newBoardGame = editorService.EditBoardGame(boardGameToEdit);

                if (newBoardGame != null)
                {
                    var operationResult = httpService.Create(new BoardGameDTO()
                    {
                        DesignerID = newBoardGame.DesignerID,
                        PublisherID = newBoardGame.PublisherID,
                        Name = newBoardGame.Name,
                        MinPlayer = newBoardGame.MinPlayer,
                        MaxPlayer = newBoardGame.MaxPlayer,
                        MinAge = newBoardGame.MinAge,
                        Rating = newBoardGame.Rating,
                        PriceHUF = newBoardGame.PriceHUF
                    });

                    boardGameToEdit = newBoardGame;
                    operationFinished = operationResult.IsSuccess;

                    if (operationResult.IsSuccess)
                    {
                        RefreshCollectionFromServer(collection);

                        SendMessage("Board game add was successful");
                    }
                    else
                    {
                        SendMessage(operationResult.Messages.ToArray());
                    }
                }
                else
                {
                    SendMessage("Board game add has cancelled");
                    operationFinished = true;
                }
            } while (!operationFinished);
        }

        public void DeleteBoardGame(IList<BoardGameModel> collection, BoardGameModel boardGame)
        {
            if (boardGame == null)
            {
                SendMessage("Please select a boardgame");
                return;
            }

            if (boardGame != null)
            {
                var operationResult = httpService.Delete(boardGame.Id);

                if (operationResult.IsSuccess)
                {
                    RefreshCollectionFromServer(collection);
                    SendMessage("Board Game deletion was successful");
                }
                else
                {
                    SendMessage(operationResult.Messages.ToArray());
                }
            }
            else
            {
                SendMessage("Board Game deletion failed");
            }
        }

        public IList<BoardGameModel> GetAll()
        {
            var boardGames = httpService.GetAll<BoardGame>();

            return boardGames.Select(x => new BoardGameModel(x.Id, x.Name, x.PriceHUF, x.MinPlayer, x.MaxPlayer, x.MinAge, x.Rating, x.DesignerID, x.PublisherID)).ToList();
        }

        public IList<DesignerModel> GetAllDesigner()
        {
            var designers = httpServiceDesigner.GetAll<Designer>();

            return designers.Select(x => new DesignerModel(x.Id,x.Name,x.Nationality)).ToList(); 
        }

        public IList<PublisherModel> GetAllPublisher()
        {
            var publishers = httpServicePublisher.GetAll<Publisher>();

            return publishers.Select(x => new PublisherModel(x.Id, x.Name, x.Country)).ToList();
        }

        public void ModifyBoardGame(IList<BoardGameModel> collection, BoardGameModel boardGame)
        {
            if (boardGame == null)
            {
                SendMessage("Please select a boardgame");
                return;
            }

            BoardGameModel boardGameToEdit = boardGame;
            bool operationFinished = false;

            do
            {
                var editedBoardGame = editorService.EditBoardGame(boardGameToEdit);

                if (editedBoardGame != null)
                {
                    var operationResult = httpService.Update(new BoardGameDTO()
                    {
                        Id = boardGame.Id,
                        DesignerID = editedBoardGame.DesignerID,
                        PublisherID = editedBoardGame.PublisherID,
                        Name = editedBoardGame.Name,
                        MinPlayer = editedBoardGame.MinPlayer,
                        MaxPlayer = editedBoardGame.MaxPlayer,
                        MinAge = editedBoardGame.MinAge,
                        Rating = editedBoardGame.Rating,
                        PriceHUF = editedBoardGame.PriceHUF
                    });

                    boardGameToEdit = editedBoardGame;
                    operationFinished = operationResult.IsSuccess;

                    if (operationResult.IsSuccess)
                    {
                        RefreshCollectionFromServer(collection);

                        SendMessage("Board game modification was successful");
                    }
                    else
                    {
                        SendMessage(operationResult.Messages.ToArray());
                    }
                }
                else
                {
                    SendMessage("Board game modification has cancelled");
                    operationFinished = true;
                }
            } while (!operationFinished);
        }

        public void ViewBoardGame(BoardGameModel boardGame)
        {
            if (boardGame == null)
            {
                SendMessage("Please select a boardgame");
                return;
            }

            displayService.Display(boardGame);

        }

        private void RefreshCollectionFromServer(IList<BoardGameModel> collection)
        {
            collection.Clear();
            var newBoardGames = GetAll();

            foreach (var boardGame in newBoardGames)
            {
                collection.Add(boardGame);
            }
        }

        private void SendMessage(params string[] messages)
        {
            messenger.Send(messages, "BlOperationResult");
        }
    }
}
