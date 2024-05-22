using System.Windows;
using System.Windows.Controls;

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

    }
}
