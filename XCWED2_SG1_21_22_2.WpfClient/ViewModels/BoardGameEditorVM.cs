using CommonServiceLocator;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.WpfClient.BL.Interfaces;
using XCWED2_SG1_21_22_2.WpfClient.Models;

namespace XCWED2_SG1_21_22_2.WpfClient.ViewModels
{
    public class BoardGameEditorVM : ViewModelBase
    {
        private BoardGameModel currentBoardGame;

        public BoardGameModel CurrentBoardGame
        {
            get { return currentBoardGame; }
            set
            {
                Set(ref currentBoardGame, value);
                SelectedDesigner = AvailableDesigners?.SingleOrDefault(x => x.ID == currentBoardGame.DesignerID);
                SelectedPublisher = AvailablePublishers?.SingleOrDefault(x => x.ID == currentBoardGame.PublisherID);
            }
        }

        private DesignerModel selectedDesigner;

        public DesignerModel SelectedDesigner
        {
            get { return selectedDesigner; }
            set { Set(ref selectedDesigner, value);
                currentBoardGame.DesignerID = selectedDesigner?.ID ?? 0;
            }
        }

        public IList<DesignerModel> AvailableDesigners { get; private set; }


        private PublisherModel selectedPublisher;

        public PublisherModel SelectedPublisher
        {
            get { return selectedPublisher; }
            set
            {
                Set(ref selectedPublisher, value);
                currentBoardGame.PublisherID = selectedPublisher?.ID ?? 0;
            }
        }

        public IList<PublisherModel> AvailablePublishers { get; private set; }

        private bool editEnabled;

        public bool EditEnabled
        {
            get { return editEnabled; }
            set { Set(ref editEnabled, value);
                RaisePropertyChanged(nameof(CancelButtonVisibility));
            }
        }
        public System.Windows.Visibility CancelButtonVisibility => EditEnabled ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

        public BoardGameEditorVM(IBoardGameHandlerService boardGameHandlerService)
        {
            CurrentBoardGame = new BoardGameModel();

            if (IsInDesignMode)
            {
                AvailableDesigners = new List<DesignerModel>()
                {
                    new DesignerModel(1, "Matt Leacock", "US" ),
                    new DesignerModel(2, "Klaus Teuber", "German" ),
                    new DesignerModel(2, "Seiji Kanai", "Japan" )
                };

                AvailablePublishers = new List<PublisherModel>()
                {
                    new PublisherModel(1, "Z - Man Games", "US" ),
                    new PublisherModel(2, "KOSMOS", "German" ),
                    new PublisherModel(2, "SFantasy Flight Games", "US" )
                };

                selectedDesigner = AvailableDesigners[2];
                selectedPublisher = AvailablePublishers[2];

                currentBoardGame.Name = "Hanamikoji";
                currentBoardGame.MinPlayer = 2;
                currentBoardGame.MaxPlayer = 2;
                currentBoardGame.MinAge = 10;
                currentBoardGame.Rating = 7.5;
                currentBoardGame.PriceHUF = 4000;
            }
            else
            {
                AvailableDesigners = boardGameHandlerService.GetAllDesigner();
                AvailablePublishers = boardGameHandlerService.GetAllPublisher();
            }
        }
        public BoardGameEditorVM() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IBoardGameHandlerService>())
        {
        }
    }
}
