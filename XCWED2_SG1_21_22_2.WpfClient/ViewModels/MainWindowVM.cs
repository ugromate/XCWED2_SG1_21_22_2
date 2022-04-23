using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using XCWED2_SG1_21_22_2.WpfClient.BL.Interfaces;
using XCWED2_SG1_21_22_2.WpfClient.Models;

namespace XCWED2_SG1_21_22_2.WpfClient.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        private BoardGameModel currentBoardGame;

        public BoardGameModel CurrentBoardGame
        {
            get { return currentBoardGame; }
            set { Set(ref currentBoardGame, value); }
        }

        public ObservableCollection<BoardGameModel> BoardGames { get; private set; }

        public ICommand AddCommand { get; private set; }
        public ICommand ModifyCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand ViewCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }

        readonly IBoardGameHandlerService boardGameHandlerService;

        public MainWindowVM(IBoardGameHandlerService boardGameHandlerService)
        {
            this.boardGameHandlerService = boardGameHandlerService;
            BoardGames = new ObservableCollection<BoardGameModel>();

            if (IsInDesignMode)
            {
                BoardGames.Add(new BoardGameModel() { Id = 3, Name = "Love Letter", DesignerID = 4, PublisherID = 1, MinPlayer = 2, MaxPlayer = 4, MinAge = 10, Rating = 7.2, PriceHUF = 4700 });
                BoardGames.Add(new BoardGameModel() { Id = 4, Name = "The Voyages of Marco Polo", DesignerID = 5, PublisherID = 1, MinPlayer = 2, MaxPlayer = 4, MinAge = 12, Rating = 7.9, PriceHUF = 15000 });
                BoardGames.Add(new BoardGameModel() { Id = 5, Name = "Hanamikoji", DesignerID = 6, PublisherID = 3, MinPlayer = 2, MaxPlayer = 2, MinAge = 10, Rating = 7.5, PriceHUF = 4000 });
                BoardGames.Add(new BoardGameModel() { Id = 6, Name = "Forbidden Desert", DesignerID = 1, PublisherID = 3, MinPlayer = 2, MaxPlayer = 5, MinAge = 10, Rating = 7.1, PriceHUF = 8000 });
                BoardGames.Add(new BoardGameModel() { Id = 7, Name = "Forbidden Island", DesignerID = 1, PublisherID = 3, MinPlayer = 2, MaxPlayer = 4, MinAge = 10, Rating = 6.8, PriceHUF = 7000 });
                BoardGames.Add(new BoardGameModel() { Id = 8, Name = "Settlers of Catan", DesignerID = 2, PublisherID = 2, MinPlayer = 3, MaxPlayer = 4, MinAge = 10, Rating = 7.1, PriceHUF = 9000 });
                CurrentBoardGame = BoardGames[0];
            }

            LoadCommand = new RelayCommand(() =>
            {
                var boardGames = this.boardGameHandlerService.GetAll();
                BoardGames.Clear();

                foreach (var boardGame in boardGames)
                {
                    BoardGames.Add(boardGame);
                }
            });

            AddCommand = new RelayCommand(() => this.boardGameHandlerService.AddBoardGame(BoardGames));
            ModifyCommand = new RelayCommand(() => this.boardGameHandlerService.ModifyBoardGame(BoardGames, CurrentBoardGame));
            DeleteCommand = new RelayCommand(() => this.boardGameHandlerService.DeleteBoardGame(BoardGames, CurrentBoardGame));
            ViewCommand = new RelayCommand(() => this.boardGameHandlerService.ViewBoardGame(CurrentBoardGame));
        }

        public MainWindowVM() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IBoardGameHandlerService>())
        {
        }

    }
}
