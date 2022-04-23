using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using XCWED2_SG1_21_22_2.WpfClient.Models;

namespace XCWED2_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for BoardGameEditorWindow.xaml
    /// </summary>
    public partial class BoardGameEditorWindow : Window
    {
        public BoardGameModel BoardGame { get; set; }
        bool enableEdit;

        public BoardGameEditorWindow()
        {
            InitializeComponent();
        }
    }
}
