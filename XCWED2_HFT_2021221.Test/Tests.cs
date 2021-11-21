using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_HFT_2021221.Logic.Services;
using XCWED2_HFT_2021221.Models.Entities;
using XCWED2_HFT_2021221.Models.Models;
using XCWED2_HFT_2021221.Repository.Interfaces;

namespace XCWED2_HFT_2021221.Test
{
    [TestFixture]
    class Tests
    {
        List<Publisher> publishers = new List<Publisher>() {
        new Publisher() { Id = 1, Name = "Z - Man Games", Country = "US" },
        new Publisher() { Id = 2, Name = "KOSMOS", Country = "Germany" }
        };

        List<BoardGame> boardGames = new List<BoardGame>() {
        new BoardGame() { Id = 1, Name = "Pandemic", DesignerID = 1, PublisherID = 1, MinPlayer = 2, MaxPlayer = 4, MinAge = 8, Rating = 7.6, PriceHUF = 10000 },
        new BoardGame() { Id = 2, Name = "Carcassone", DesignerID = 3, PublisherID = 1, MinPlayer = 2, MaxPlayer = 5, MinAge = 7, Rating = 7.4, PriceHUF = 7300 }
        };

        [Test]
        public void PublisherCreate()
        {
            // Arrange
            var boardGameRepo = new Mock<IBoardGameRepository>();
            var publisherRepo = new Mock<IPublisherRepository>();
            var designerRepo = new Mock<IDesignerRepository>();
            var logic = new PublisherLogic(boardGameRepo.Object, publisherRepo.Object, designerRepo.Object);

            Publisher publisher = new Publisher();
            publisherRepo.Setup(x => x.Create(publisher)).Returns(publisher);


            // Act
          Publisher  result = logic.Create(publisher);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void PublisherCreateWithNull()
        {
            // Arrange
            var boardGameRepo = new Mock<IBoardGameRepository>();
            var publisherRepo = new Mock<IPublisherRepository>();
            var designerRepo = new Mock<IDesignerRepository>();
            var logic = new PublisherLogic(boardGameRepo.Object, publisherRepo.Object, designerRepo.Object);



            // Act
            var exception = Assert.Throws(typeof(Exception), () => logic.Create(null));

            // Assert
            Assert.That(exception, Is.Not.Null);
        }

        [Test]
        public void BoardGameCreate()
        {
            // Arrange
            var boardGameRepo = new Mock<IBoardGameRepository>();
            var publisherRepo = new Mock<IPublisherRepository>();
            var designerRepo = new Mock<IDesignerRepository>();
            var logic = new BoardGameLogic(boardGameRepo.Object, publisherRepo.Object, designerRepo.Object);

            BoardGame boardGame = new BoardGame();
            boardGameRepo.Setup(x => x.Create(boardGame)).Returns(boardGame);


            // Act
            BoardGame result = logic.Create(boardGame);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        public void BoardGameCreateWithNull()
        {
            // Arrange
            var boardGameRepo = new Mock<IBoardGameRepository>();
            var publisherRepo = new Mock<IPublisherRepository>();
            var designerRepo = new Mock<IDesignerRepository>();
            var logic = new BoardGameLogic(boardGameRepo.Object, publisherRepo.Object, designerRepo.Object);


            // Act
            var exception = Assert.Throws(typeof(Exception), () => logic.Create(null));

            // Assert
            Assert.That(exception, Is.Not.Null);
        }

        [Test]
        public void DesignerCreate()
        {
            // Arrange
            var boardGameRepo = new Mock<IBoardGameRepository>();
            var publisherRepo = new Mock<IPublisherRepository>();
            var designerRepo = new Mock<IDesignerRepository>();
            var logic = new DesignerLogic(boardGameRepo.Object, publisherRepo.Object, designerRepo.Object);

            Designer designer = new Designer();
            designerRepo.Setup(x => x.Create(designer)).Returns(designer);


            // Act
            Designer result = logic.Create(designer);

            // Assert
            Assert.That(result, Is.Not.Null);

        }

        public void DesignerCreateWithNull()
        {
            //Assert
            var boardGameRepo = new Mock<IBoardGameRepository>();
            var publisherRepo = new Mock<IPublisherRepository>();
            var designerRepo = new Mock<IDesignerRepository>();
            var logic = new DesignerLogic(boardGameRepo.Object, publisherRepo.Object, designerRepo.Object);


            // Act
            var exception = Assert.Throws(typeof(Exception), () => logic.Create(null));

            // Assert
            Assert.That(exception, Is.Not.Null);
        }



        [Test]
        public void AveragePublisherWithOneBoardGameOnePublisher()
        {
            //arrange
            var boardGameRepo = new Mock<IBoardGameRepository>();
            var publisherRepo = new Mock<IPublisherRepository>();
            var designerRepo = new Mock<IDesignerRepository>();
            var logic = new PublisherLogic(boardGameRepo.Object, publisherRepo.Object, designerRepo.Object);

            publisherRepo.Setup(x => x.ReadAll()).Returns(publishers.AsQueryable());
            boardGameRepo.Setup(x => x.ReadAll()).Returns(boardGames.AsQueryable());


            //act
            IEnumerable<AveragePublisher> averages = logic.GetPublisherAverages();
            AveragePublisher result = null;
            foreach (var item in averages)
            {
                if (item.PublisherName == "Z - Man Games")
                {
                    result = item;
                }
            }


            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Average, Is.EqualTo(8650));
        }

        [Test]
        public void AveragePublisherWithoutBoardGame()
        {

            //arrange
            var boardGameRepo = new Mock<IBoardGameRepository>();
            var publisherRepo = new Mock<IPublisherRepository>();
            var designerRepo = new Mock<IDesignerRepository>();
            var logic = new PublisherLogic(boardGameRepo.Object, publisherRepo.Object, designerRepo.Object);

            publisherRepo.Setup(x => x.ReadAll()).Returns(publishers.AsQueryable());
            boardGameRepo.Setup(x => x.ReadAll()).Returns(boardGames.AsQueryable());


            //act
            IEnumerable<AveragePublisher> averages = logic.GetPublisherAverages();
            AveragePublisher result = null;
            foreach (var item in averages)
            {
                if (item.PublisherName == "KOSMOS")
                {
                    result = item;
                }
            }

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void AveragePublisherWithManyPublisheAndBoardGame()
        {
            //arrange
            List<Publisher> publishers = new List<Publisher>() {
        new Publisher() { Id = 1, Name = "Z - Man Games", Country = "US" },
        new Publisher() { Id = 2, Name = "KOSMOS", Country = "Germany" }
        };

            List<BoardGame> boardGames = new List<BoardGame>() {
        new BoardGame() { Id = 1, Name = "Pandemic", DesignerID = 1, PublisherID = 1, MinPlayer = 2, MaxPlayer = 4, MinAge = 8, Rating = 7.6, PriceHUF = 10000 },
        new BoardGame() { Id = 2, Name = "Carcassone", DesignerID = 3, PublisherID = 1, MinPlayer = 2, MaxPlayer = 5, MinAge = 7, Rating = 7.4, PriceHUF = 7300 },
        new BoardGame() { Id = 8, Name = "Settlers of Catan", DesignerID = 2, PublisherID = 2, MinPlayer = 3, MaxPlayer = 4, MinAge = 10, Rating = 7.1, PriceHUF = 9000 },
        new BoardGame() { Id = 9, Name = "Anno 1503", DesignerID = 2, PublisherID = 2, MinPlayer = 2, MaxPlayer = 4, MinAge = 10, Rating = 6.2, PriceHUF = 10000 }
        };

            var boardGameRepo = new Mock<IBoardGameRepository>();
            var publisherRepo = new Mock<IPublisherRepository>();
            var designerRepo = new Mock<IDesignerRepository>();
            var logic = new PublisherLogic(boardGameRepo.Object, publisherRepo.Object, designerRepo.Object);

            publisherRepo.Setup(x => x.ReadAll()).Returns(publishers.AsQueryable());
            boardGameRepo.Setup(x => x.ReadAll()).Returns(boardGames.AsQueryable());

            //act
            List<AveragePublisher> averages = logic.GetPublisherAverages().ToList();
            averages.OrderBy(x => x.Average);


            //assert
            Assert.That(averages[0].Average, Is.EqualTo(8650));
            Assert.That(averages[1].Average, Is.EqualTo(9500));


        }

        [Test]
        public void MostSuccessfullDesignerWithoutDesigner()
        {
            //arrange

            var boardGameRepo = new Mock<IBoardGameRepository>();
            var publisherRepo = new Mock<IPublisherRepository>();
            var designerRepo = new Mock<IDesignerRepository>();
            var logic = new DesignerLogic(boardGameRepo.Object, publisherRepo.Object, designerRepo.Object);

            //act
            string result = logic.MostPopularDesigner();

            //assert
            Assert.That(result, Is.Null);

        }

        [Test]
        public void MostSuccessfullDesignerWithMany()
        {

            //arrange
            List<BoardGame> boardGames = new List<BoardGame>() {
        new BoardGame() { Id = 1, Name = "Pandemic", DesignerID = 1, PublisherID = 1, MinPlayer = 2, MaxPlayer = 4, MinAge = 8, Rating = 7.6, PriceHUF = 10000 },
        new BoardGame() { Id = 2, Name = "Carcassone", DesignerID = 1, PublisherID = 1, MinPlayer = 2, MaxPlayer = 5, MinAge = 7, Rating = 7.4, PriceHUF = 7300 },
        new BoardGame() { Id = 8, Name = "Settlers of Catan", DesignerID = 2, PublisherID = 2, MinPlayer = 3, MaxPlayer = 4, MinAge = 10, Rating = 7.1, PriceHUF = 9000 },
        new BoardGame() { Id = 9, Name = "Anno 1503", DesignerID = 2, PublisherID = 2, MinPlayer = 2, MaxPlayer = 4, MinAge = 10, Rating = 6.2, PriceHUF = 10000 }

        };
            List<Designer> designers = new List<Designer>() {
          new Designer() { Id = 1, Name = "Matt Leacock", Nationality = "US" },
          new Designer() { Id = 2, Name = "Klaus Teuber", Nationality = "German" }
        };

            var boardGameRepo = new Mock<IBoardGameRepository>();
            var publisherRepo = new Mock<IPublisherRepository>();
            var designerRepo = new Mock<IDesignerRepository>();
            var logic = new DesignerLogic(boardGameRepo.Object, publisherRepo.Object, designerRepo.Object);

            designerRepo.Setup(x => x.ReadAll()).Returns(designers.AsQueryable());
            boardGameRepo.Setup(x => x.ReadAll()).Returns(boardGames.AsQueryable());


            //Act
            string mostPopular = logic.MostPopularDesigner();

            //Assert
            Assert.That(mostPopular, Is.EqualTo("Matt Leacock - 7.5"));
        }

        [Test]
        public void TwoTenYearsOldNoGameToPlay()
        {
            //Assert
            List<BoardGame> boardGames = new List<BoardGame>() {
        new BoardGame() { Id = 1, Name = "Pandemic", DesignerID = 1, PublisherID = 1, MinPlayer = 2, MaxPlayer = 4, MinAge = 12, Rating = 7.6, PriceHUF = 10000 },
        new BoardGame() { Id = 2, Name = "Carcassone", DesignerID = 1, PublisherID = 1, MinPlayer = 2, MaxPlayer = 5, MinAge = 12, Rating = 7.4, PriceHUF = 7300 },
        new BoardGame() { Id = 8, Name = "Settlers of Catan", DesignerID = 2, PublisherID = 2, MinPlayer = 3, MaxPlayer = 4, MinAge = 10, Rating = 7.1, PriceHUF = 9000 },
        new BoardGame() { Id = 9, Name = "Anno 1503", DesignerID = 2, PublisherID = 2, MinPlayer = 3, MaxPlayer = 4, MinAge = 10, Rating = 6.2, PriceHUF = 10000 }
            };

            var boardGameRepo = new Mock<IBoardGameRepository>();
            var publisherRepo = new Mock<IPublisherRepository>();
            var designerRepo = new Mock<IDesignerRepository>();
            var logic = new PublisherLogic(boardGameRepo.Object, publisherRepo.Object, designerRepo.Object);

            boardGameRepo.Setup(x => x.ReadAll()).Returns(boardGames.AsQueryable());

            //Act
            int gameCount = logic.TwoKidGameCount();

            //Assert
            Assert.That(gameCount, Is.EqualTo(0));
        }

        [Test]
        public void TwoTenYearsOldManyGamesToPlay()
        {
            //Assert
            List<BoardGame> boardGames = new List<BoardGame>() {
        new BoardGame() { Id = 1, Name = "Pandemic", DesignerID = 1, PublisherID = 1, MinPlayer = 2, MaxPlayer = 4, MinAge = 8, Rating = 7.6, PriceHUF = 10000 },
        new BoardGame() { Id = 2, Name = "Carcassone", DesignerID = 1, PublisherID = 1, MinPlayer = 2, MaxPlayer = 5, MinAge = 8, Rating = 7.4, PriceHUF = 7300 },
        new BoardGame() { Id = 8, Name = "Settlers of Catan", DesignerID = 2, PublisherID = 2, MinPlayer = 3, MaxPlayer = 4, MinAge = 10, Rating = 7.1, PriceHUF = 9000 },
        new BoardGame() { Id = 9, Name = "Anno 1503", DesignerID = 2, PublisherID = 2, MinPlayer = 3, MaxPlayer = 4, MinAge = 10, Rating = 6.2, PriceHUF = 10000 }
            };

            var boardGameRepo = new Mock<IBoardGameRepository>();
            var publisherRepo = new Mock<IPublisherRepository>();
            var designerRepo = new Mock<IDesignerRepository>();
            var logic = new PublisherLogic(boardGameRepo.Object, publisherRepo.Object, designerRepo.Object);

            boardGameRepo.Setup(x => x.ReadAll()).Returns(boardGames.AsQueryable());

            //Act
            int gameCount = logic.TwoKidGameCount();

            //Assert
            Assert.That(gameCount, Is.EqualTo(2));
        }

    }
}
