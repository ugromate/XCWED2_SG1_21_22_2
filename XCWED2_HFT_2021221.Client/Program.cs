using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using XCWED2_HFT_2021221.Models.Entities;
using XCWED2_HFT_2021221.Repository.DbContexts;

namespace XCWED2_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for server");
            Console.ReadLine();

            //foreach (var boardgame in context.BoardGames)
            //{
            //    Console.WriteLine($"Id: {boardgame.Id}, Publisher: {boardgame.Publisher.Name} - Title: {boardgame.Name} - Designer: {boardgame.Designer.Name}");
            //}

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:48914/api/");

                var response = client.GetAsync("BoardGame").GetAwaiter().GetResult();
                Console.WriteLine(response);

                var stringResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var boardGames = JsonSerializer.Deserialize<List<BoardGame>>(stringResult, new JsonSerializerOptions(JsonSerializerDefaults.Web));

                DisplayBoardGames(boardGames);

            }

            Console.ReadLine();

        }

        private static void DisplayBoardGames(List<BoardGame> boardGames)
        {
            foreach (var boardGame in boardGames)
            {
                Console.WriteLine(boardGame.ToString());
            }
        }
    }
}
