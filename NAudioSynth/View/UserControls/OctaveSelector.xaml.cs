using NAudioSynth.ViewModel;
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

namespace NAudioSynth.View.UserControls
{
    /// <summary>
    /// Interaction logic for OctaveSelector.xaml
    /// </summary>
    public partial class OctaveSelector : UserControl
    {
        ViewModel.MainWindowViewModel viewModel;

        public OctaveSelector()
        {
            InitializeComponent();
            viewModel = MainWindow.getViewModel();
            DataContext = viewModel;
        }

        private void Select_Octave(object sender, RoutedEventArgs e)
        {
            Button? srcButton = e.Source as Button;
            if (srcButton != null)
            {
                viewModel.SelectOctave(srcButton);
            }
        }
    }
}
