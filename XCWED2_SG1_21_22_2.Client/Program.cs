using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using XCWED2_SG1_21_22_2.Models.Entities;
using XCWED2_SG1_21_22_2.Models.Models;
using XCWED2_SG1_21_22_2.Repository.DbContexts;

namespace XCWED2_SG1_21_22_2.Client
{
    class Program
    {
        static HttpService httpSeviceBoardgame = new HttpService("BoardGame", "http://localhost:48914/api/");
        static HttpService httpSevicePublisher = new HttpService("Publisher", "http://localhost:48914/api/");
        static HttpService httpSeviceDesigner = new HttpService("Designer", "http://localhost:48914/api/");

        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for server");
            Console.ReadLine();


            #region httpService
            //GetAll
            var allboardGames = httpSeviceBoardgame.GetAll<BoardGame>();
            var allPublisher = httpSevicePublisher.GetAll<Publisher>();
            var allDesigner = httpSeviceDesigner.GetAll<Designer>();


            //Get one
            var getOneBoardGame = httpSeviceBoardgame.Get<BoardGame, int>(allboardGames.First().Id);
            var getOnePublisher = httpSevicePublisher.Get<Publisher, int>(allPublisher.First().Id);
            var getOneDesigner = httpSeviceDesigner.Get<Designer, int>(allDesigner.First().Id);


            //Create objects
            var newboardGame = new BoardGame()
            {
                Name = "Domain",
                DesignerID = 2,
                PublisherID = 2,
                MinPlayer = 2,
                MaxPlayer = 4,
                MinAge = 12,
                Rating = 7,
                PriceHUF = 11000
            };
            var newDesigner = new Designer()
            {
                Name = "Mate Ugro",
                Nationality = "Hungarian"

            };
            var newPublisher = new Publisher()
            {
                Name = "The Ugro Factory",
                Country = "Hungarian"
            };

            //Menu

            new ConsoleMenu()
            .Add("Display all board games", () => DisplayBoardGames())
            .Add("Display all publishers", () => DisplayPublishers())
            .Add("Display all designers", () => DisplayDesigner())
            .Add("Display one board game", () => DisplayOne(getOneBoardGame))
            .Add("Display one publisher", () => DisplayOne(getOnePublisher))
            .Add("Display one designer", () => DisplayOne(getOneDesigner))
            .Add("Create new board game", () => CreateBoardGame(newboardGame))
            .Add("Create new publisher", () => CreatePublisher(newPublisher))
            .Add("Create new designer", () => CreateDesigner(newDesigner))
            .Add("Update last board game", () => UpdateBoardGame())
            .Add("Update last publisher", () => UpdatePublisher())
            .Add("Update last designer", () => UpdateDesigner())
            .Add("Delete last board game", () => DeleteBoardGame())
            .Add("Delete last publisher", () => DeletePublisher())
            .Add("Delete last designer", () => DeleteDesigner())
            .Add("How many games can play 2 child who are 10 years old", () => 
            {
                Console.WriteLine($"2 child who is 10 years old can play with: {httpSeviceBoardgame.Get<int>("TwoKidGameCount")} games");
                MenuCall();
            })
            .Add("Best game what can be played alone", () =>
            {
                BoardGame bestalone =  httpSeviceBoardgame.Get<BoardGame>("BestAlonePlayable");
                Console.WriteLine($"Best game what can be played alone: {bestalone.Name} - {bestalone.Rating}");
                MenuCall();
            })
            .Add("Games By Designer Nationality", () =>
            {
                Console.WriteLine($"Number of games by nationality ");
                DisplayNationality();
                MenuCall();
            })
            .Add("Average Publisher Prices", () => { 
                Console.WriteLine($"Average price of games by publisher\n");
                DisplayPublisherAverage();
                MenuCall();
            })
            .Add("Most Popular Designer", () => { 
                Console.WriteLine($"Most popular designer by game rating ");
                Console.WriteLine(  httpSeviceDesigner.Get<AverageDesigner>("MostPopularDesigner").ToString()) ;
                MenuCall();
            })
            .Add("Close", ConsoleMenu.Close)
            .Configure(config => { config.Selector = "--> "; })
            .Show();

            Console.ReadLine();
            #endregion

        }

        private static void DisplayBoardGames()
        {
            var allboardGames = httpSeviceBoardgame.GetAll<BoardGame>();
            foreach (var boardGame in allboardGames)
            {
                Console.WriteLine(boardGame.ToString());
            }
            MenuCall();
        }

        private static void DisplayDesigner()
        {
            var allDesigner = httpSeviceDesigner.GetAll<Designer>();
            foreach (var designer in allDesigner)
            {
                Console.WriteLine(designer.ToString());
            }
            MenuCall();
        }

        private static void DisplayPublishers()
        {
            var allPublisher = httpSevicePublisher.GetAll<Publisher>();
            foreach (var publisher in allPublisher)
            {
                Console.WriteLine(publisher.ToString());
            }
            MenuCall();
        }

        private static void DisplayOne(object item)
        {
            Console.WriteLine(item.ToString());
            MenuCall();
        }

        private static void CreateBoardGame(BoardGame newboardGame)
        {
            var result = httpSeviceBoardgame.Create(newboardGame);
            if (result.IsSuccess)
            {
                Console.WriteLine("Creation was succesfull");
            }
            MenuCall();
        }

        private static void CreateDesigner(Designer newDesigner)
        {
            var result = httpSeviceDesigner.Create(newDesigner);
            if (result.IsSuccess)
            {
                Console.WriteLine("Creation was succesfull");
            }
            MenuCall();
        }

        private static void CreatePublisher(Publisher newPublisher)
        {
            var result = httpSevicePublisher.Create(newPublisher);
            if (result.IsSuccess)
            {
                Console.WriteLine("Creation was succesfull");
            }
            MenuCall();
        }

        private static void UpdateBoardGame()
        {
            var updateBoardGame = httpSeviceBoardgame.GetAll<BoardGame>().Last();
            updateBoardGame.MinAge = 200;
            updateBoardGame.PriceHUF = 5000000;

            var result = httpSeviceBoardgame.Update(updateBoardGame);
            if (result.IsSuccess)
            {
                Console.WriteLine("Update was succesfull");
            }
            MenuCall();
        }

        private static void UpdateDesigner()
        {
            var updateDesigner = httpSeviceDesigner.GetAll<Designer>().Last();
            updateDesigner.Nationality = "Italian";

            var result = httpSeviceDesigner.Update(updateDesigner);
            if (result.IsSuccess)
            {
                Console.WriteLine("Update was succesfull");
            }
            MenuCall();
        }

        private static void UpdatePublisher()
        {
            var updatePublisher = httpSevicePublisher.GetAll<Publisher>().Last();
            updatePublisher.Country = "Spain";

            var result = httpSevicePublisher.Update(updatePublisher);
            if (result.IsSuccess)
            {
                Console.WriteLine("Update was succesfull");
            }
            MenuCall();
        }

        private static void DeleteBoardGame()
        {
            var updateBoardGame = httpSeviceBoardgame.GetAll<BoardGame>().Last();

            var result = httpSeviceBoardgame.Delete(updateBoardGame.Id);
            if (result.IsSuccess)
            {
                Console.WriteLine("Delete was succesfull");
            }
            MenuCall();
        }

        private static void DeleteDesigner()
        {
            var updateDesigner = httpSeviceDesigner.GetAll<Designer>().Last();

            var result = httpSeviceDesigner.Delete(updateDesigner.Id);
            if (result.IsSuccess)
            {
                Console.WriteLine("Delete was succesfull");
            }
            MenuCall();
        }

        private static void DeletePublisher()
        {
            var updatePublisher = httpSevicePublisher.GetAll<Publisher>().Last();

            var result = httpSevicePublisher.Delete(updatePublisher.Id);
            if (result.IsSuccess)
            {
                Console.WriteLine("Delete was succesfull");
            }
            MenuCall();
        }

        private static void DisplayPublisherAverage()
        {
            var publisherAverages = httpSevicePublisher.GetAll<AveragePublisher>("GetPublisherAverages");

            foreach (var publisherAverage in publisherAverages)
            {
                Console.WriteLine(publisherAverage);
            }
        }

        private static void DisplayNationality()
        {
            var publisherAverages = httpSeviceBoardgame.GetAll<NationalityCount>("GamesByDesignerNationality");

            foreach (var publisherAverage in publisherAverages)
            {
                Console.WriteLine(publisherAverage);
            }
        }

        private static void MenuCall()
        {
            Console.WriteLine("Press a button to go back to the menu");
            Console.ReadLine();
        }
    }
}
