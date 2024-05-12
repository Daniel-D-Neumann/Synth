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

namespace NAudioSynth.View.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        NoteGrid noteGrid = new NoteGrid();
        int pageNo = 0;
        int buttonsInRow = 16;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void Note_Click(object sender, RoutedEventArgs e)
        {
        //    Button? srcButton = e.Source as Button;

        //    int NotePosition = 0;

        //    if (srcButton != null)
        //    {
        //        int row = Grid.GetRow(srcButton);
        //        int column = Grid.GetColumn(srcButton);

        //        NotePosition = column + (buttonsInRow * pageNo);

        //        if (noteGrid.QueryButtonsPressed(row,NotePosition))
        //        {
        //            srcButton.Background = Brushes.Red;
        //        }
        //        else
        //        {
        //            srcButton.Background = Brushes.Green;
        //        }
        //        noteGrid.SwitchButtonsPressed(row,NotePosition);
        //    }
        }
    }
}
