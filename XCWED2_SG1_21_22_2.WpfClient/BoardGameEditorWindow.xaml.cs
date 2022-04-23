using System.Windows;
using XCWED2_SG1_21_22_2.WpfClient.Models;
using XCWED2_SG1_21_22_2.WpfClient.ViewModels;

namespace XCWED2_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for BoardGameEditorWindow.xaml
    /// </summary>
    public partial class BoardGameEditorWindow : Window
    {
        public BoardGameModel BoardGame { get; set; }
        bool enableEdit;

        public BoardGameEditorWindow(BoardGameModel boardGame = null, bool enableEdit = true)
        {
            InitializeComponent();
            BoardGame = boardGame == null
                ? new BoardGameModel()
                : new BoardGameModel(boardGame);

            this.enableEdit = enableEdit;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var vm = (BoardGameEditorVM)Resources["VM"];
            vm.CurrentBoardGame = BoardGame;
            vm.EditEnabled = enableEdit;
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            if (enableEdit)
            {
                DialogResult = true;
            }
            else
            {
                Close();
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            if (enableEdit)
            {
                DialogResult = false;
            }
            else
            {
                Close();
            }
        }
    }
}
