﻿using System;
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
                if(viewModel.NoSongPlaying) viewModel.NotePressed(srcButton);
            }
        }
    }
}
