using System;
using XCWED2_HFT_2021221.Repository.DbContexts;

namespace XCWED2_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");
            var context = new XCWED2_HFT_2021221DbContext();
            Console.WriteLine("Connected");


            //foreach (var boargame in context.BoardGames)
            //{
            //    Console.WriteLine(boargame.Name);
            //}

            Console.WriteLine();

            foreach (var boardgame in context.BoardGames)
            {
                Console.WriteLine($"Id: {boardgame.Id}, Publisher: {boardgame.Publisher.Name} - Title: {boardgame.Name} - Designer: {boardgame.Designer.Name}");
            }

            Console.ReadLine();

        }
    }
}
