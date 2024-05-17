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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NAudioSynth.Model.NoteGrid;
using NAudioSynth;
using NAudioSynth.ViewModel;
using System.Windows.Controls.Primitives;

namespace NAudioSynth.View.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SoundBar : UserControl
    {

        ViewModel.MainWindowViewModel viewModel;
        public SoundBar()
        {
            InitializeComponent();
            viewModel = MainWindow.getViewModel();
            DataContext = viewModel;
        }

        private void Note_Click(object sender, RoutedEventArgs e)
        {
            Button? srcButton = e.Source as Button;
            if (srcButton != null)
            {
                if (viewModel.NoSongPlaying) viewModel.NotePressed(srcButton);
            }
        }

        private void MenuItem_Checked(object sender, RoutedEventArgs e)
        {
            MenuItem? item = sender as MenuItem;
            if (item != null)
            {
                ContextMenu? contextMenu = item.Parent as ContextMenu;
                if (contextMenu != null)
                {
                    Popup? popup = contextMenu.Parent as Popup;
                    if (popup != null)
                    {
                        Button? button = popup.PlacementTarget as Button;
                        if (button != null)
                        {
                            if (viewModel.NoSongPlaying) viewModel.ConnectedPressed(button);
                        }
                    }
                }
            }
        }
    }
}
