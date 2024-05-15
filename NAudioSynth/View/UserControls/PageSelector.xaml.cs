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
using NAudioSynth.ViewModel;

namespace NAudioSynth.View.UserControls
{
    /// <summary>
    /// Interaction logic for PageSelector.xaml
    /// </summary>
    public partial class PageSelector : UserControl
    {
        ViewModel.MainWindowViewModel viewModel;
        public PageSelector()
        {
            InitializeComponent();
            viewModel = MainWindow.getViewModel();
            //DataContext = viewModel;
        }

        private void Select_Page(object sender, RoutedEventArgs e)
        {
            Button? srcButton = e.Source as Button;
            if (srcButton != null)
            {
                viewModel.SelectPage(srcButton);
            }
        }
    }
}
