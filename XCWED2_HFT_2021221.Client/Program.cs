using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using XCWED2_HFT_2021221.Models.Entities;
using XCWED2_HFT_2021221.Models.Models;
using XCWED2_HFT_2021221.Repository.DbContexts;

namespace XCWED2_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for server");
            Console.ReadLine();
            #region old

            var jsonOption = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            //foreach (var boardgame in context.BoardGames)
            //{
            //    Console.WriteLine($"Id: {boardgame.Id}, Publisher: {boardgame.Publisher.Name} - Title: {boardgame.Name} - Designer: {boardgame.Designer.Name}");
            //}

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:48914/api/");

                //write out boardgames

                WriteOutBoardGames(client, jsonOption);

                // write out designers

                var response = client.GetAsync("Designer").GetAwaiter().GetResult();

                var stringResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var designer = JsonSerializer.Deserialize<List<Designer>>(stringResult, jsonOption);

                DisplayDesigner(designer);


                //Create

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

                var postResponse = client.PostAsJsonAsync<BoardGame>("BoardGame", newboardGame).GetAwaiter().GetResult();

                var apiResult = JsonSerializer.Deserialize<ApiResult>(postResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult(), jsonOption);

                if (apiResult.IsSuccess)
                {
                    Console.WriteLine("Creation was successfull");
                }

                WriteOutBoardGames(client, jsonOption);

                //Delete

                //GetPublisher averages
                var publisherAverages = client; 

            }

            Console.ReadLine();
            #endregion

            #region httpService
            var httpSevice = new HttpService("BoardGame", "http://localhost:48914/api/");

            //GetAll
            var boardGames = httpSevice.GetAll<BoardGame>();
            DisplayBoardGames(boardGames);

            Console.ReadLine();
            #endregion

        }

        private static void WriteOutBoardGames(HttpClient client, JsonSerializerOptions jsonOption)
        {
            var response = client.GetAsync("BoardGame").GetAwaiter().GetResult();
            Console.WriteLine(response);

            var stringResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var boardGames = JsonSerializer.Deserialize<List<BoardGame>>(stringResult, jsonOption);

            DisplayBoardGames(boardGames);
        }

        private static void DisplayBoardGames(List<BoardGame> boardGames)
        {
            foreach (var boardGame in boardGames)
            {
                Console.WriteLine(boardGame.ToString());
            }
        }

        private static void DisplayDesigner(List<Designer> designers)
        {
            foreach (var designer in designers)
            {
                Console.WriteLine(designer.ToString());
            }
        }
    }
}
