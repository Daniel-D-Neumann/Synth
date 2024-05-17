﻿using NAudio.Wave;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using NAudioSynth.Model.NoteGrid;
using NAudio.Wave.SampleProviders;
using System.Windows;
using System;
using System.Collections.Generic;
//using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data.Common;

namespace NAudioSynth.ViewModel
{
    public class MainWindowViewModel : ViewModel
    {
        public int pageNo = 0;
        public int octaveNo = 0;

        NoteGrid noteGrid = new NoteGrid();
        public RelayCommand PlayCommand => new RelayCommand(execute => PlaySelected(), canExecute => noteGrid.GetCurrentSong() != null);
        public RelayCommand PlayChordsCommand => new RelayCommand(execute => PlayChords(), canExecute=> noSongPlaying);

        public RelayCommand GenerateSelectedCommand => new RelayCommand(execute => GenerateSelceted());

        public int buttonPressedRow;
        public int buttonPressedColumn;
        public List<List<SolidColorBrush>> buttonColors;

        #region ButtonBackgroundProperties
        private SolidColorBrush b00 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B00
        {
            get { return b00; }
            set
            {
                b00 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b01 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B01
        {
            get { return b01; }
            set
            {
                b01 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b02 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B02
        {
            get { return b02; }
            set
            {
                b02 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b03 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B03
        {
            get { return b03; }
            set
            {
                b03 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b04 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B04
        {
            get { return b04; }
            set
            {
                b04 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b05 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B05
        {
            get { return b05; }
            set
            {
                b05 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b06 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B06
        {
            get { return b06; }
            set
            {
                b06 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b07 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B07
        {
            get { return b07; }
            set
            {
                b07 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b10 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B10
        {
            get { return b10; }
            set
            {
                b10 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b11 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B11
        {
            get { return b11; }
            set
            {
                b11 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b12 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B12
        {
            get { return b12; }
            set
            {
                b12 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b13 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B13
        {
            get { return b13; }
            set
            {
                b13 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b14 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B14
        {
            get { return b14; }
            set
            {
                b14 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b15 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B15
        {
            get { return b15; }
            set
            {
                b15 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b16 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B16
        {
            get { return b16; }
            set
            {
                b16 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b17 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B17
        {
            get { return b17; }
            set
            {
                b17 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b20 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B20
        {
            get { return b20; }
            set
            {
                b20 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b21 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B21
        {
            get { return b21; }
            set
            {
                b21 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b22 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B22
        {
            get { return b22; }
            set
            {
                b22 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b23 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B23
        {
            get { return b23; }
            set
            {
                b23 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b24 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B24
        {
            get { return b24; }
            set
            {
                b04 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b25 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B25
        {
            get { return b25; }
            set
            {
                b25 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b26 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B26
        {
            get { return b26; }
            set
            {
                b26 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b27 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B27
        {
            get { return b27; }
            set
            {
                b27 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b30 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B30
        {
            get { return b30; }
            set
            {
                b30 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b31 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B31
        {
            get { return b31; }
            set
            {
                b31 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b32 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B32
        {
            get { return b32; }
            set
            {
                b32 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b33 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B33
        {
            get { return b33; }
            set
            {
                b33 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b34 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B34
        {
            get { return b34; }
            set
            {
                b34 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b35 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B35
        {
            get { return b35; }
            set
            {
                b35 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b36 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B36
        {
            get { return b36; }
            set
            {
                b36 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b37 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B37
        {
            get { return b37; }
            set
            {
                b37 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b40 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B40
        {
            get { return b40; }
            set
            {
                b40 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b41 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B41
        {
            get { return b41; }
            set
            {
                b41 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b42 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B42
        {
            get { return b42; }
            set
            {
                b42 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b43 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B43
        {
            get { return b43; }
            set
            {
                b43 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b44 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B44
        {
            get { return b44; }
            set
            {
                b44 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b45 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B45
        {
            get { return b45; }
            set
            {
                b45 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b46 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B46
        {
            get { return b46; }
            set
            {
                b46 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b47 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B47
        {
            get { return b47; }
            set
            {
                b47 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b50 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B50
        {
            get { return b50; }
            set
            {
                b50 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b51 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B51
        {
            get { return b51; }
            set
            {
                b51 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b52 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B52
        {
            get { return b52; }
            set
            {
                b52 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b53 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B53
        {
            get { return b53; }
            set
            {
                b53 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b54 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B54
        {
            get { return b54; }
            set
            {
                b54 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b55 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B55
        {
            get { return b55; }
            set
            {
                b55 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b56 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B56
        {
            get { return b56; }
            set
            {
                b56 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b57 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B57
        {
            get { return b57; }
            set
            {
                b57 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b60 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B60
        {
            get { return b60; }
            set
            {
                b60 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b61 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B61
        {
            get { return b61; }
            set
            {
                b61 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b62 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B62
        {
            get { return b62; }
            set
            {
                b62 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b63 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B63
        {
            get { return b63; }
            set
            {
                b63 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b64 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B64
        {
            get { return b64; }
            set
            {
                b64 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b65 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B65
        {
            get { return b65; }
            set
            {
                b65 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b66 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B66
        {
            get { return b66; }
            set
            {
                b66 = value;
                OnPropertyChanged();
            }
        }
        private SolidColorBrush b67 = new SolidColorBrush(Colors.Red);

        public SolidColorBrush B67
        {
            get { return b67; }
            set
            {
                b67 = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            buttonColors = new List<List<SolidColorBrush>>
            {
                new List<SolidColorBrush>() {B00,B01,B02,B03,B04,B05,B06,B07},
                new List<SolidColorBrush>() {B10,B11,B12,B13,B14,B15,B16,B17},
                new List<SolidColorBrush>() {B20,B21,B22,B23,B24,B25,B26,B27},
                new List<SolidColorBrush>() {B30,B31,B32,B33,B34,B35,B36,B37},
                new List<SolidColorBrush>() {B40,B41,B42,B43,B44,B45,B46,B47},
                new List<SolidColorBrush>() {B50,B51,B52,B53,B54,B55,B56,B57},
                new List<SolidColorBrush>() {B60,B61,B62,B63,B64,B65,B66,B67},
            };
        }

        private string currentPageNo = "Page: 1";

        public string CurrentPageNo
        {
            get { return currentPageNo; }
            set 
            { 
                currentPageNo = value + (pageNo+1);
                OnPropertyChanged();
            }
        }

        private string currentOctaveNo = "Octave: 1";

        public string CurrentOctaveNo
        {
            get { return currentOctaveNo; }
            set 
            { 
                currentOctaveNo = value + (octaveNo+1); 
                OnPropertyChanged();
            }
        }

        private bool noSongPlaying = true;

        public bool NoSongPlaying
        {
            get { return noSongPlaying; }
            set 
            {
                noSongPlaying = value; 
                OnPropertyChanged();
            }
        }


        private bool sinSelected = true;
        public bool SinSelected
        {
            get { return sinSelected; }
            set 
            { 
                sinSelected = value;
                sawSelected = !sinSelected;
                OnPropertyChanged();
                UpdateActiveButtons();
            }
        }

        private bool sawSelected;
        public bool SawSelected
        {
            get { return sawSelected; }
            set
            {

                sawSelected = value;
                sinSelected = !sawSelected;
                OnPropertyChanged();
                UpdateActiveButtons();
            }
        }

        private void UpdateActiveButtons()
        {
            for (int i = 0; i < NoteGrid.availableNoteTypes; i++)
            {
                for(int j = 0; j < NoteGrid.availableNoteButtons; j++)
                {
                    bool buttonPressed = false;
                    if(SinSelected)
                    {
                        buttonPressed = noteGrid.QueryButtonsPressed(i+(octaveNo*NoteGrid.availableNoteTypes), j+(pageNo*NoteGrid.availableNoteButtons), GetActiveTab());
                    }
                    else if (sawSelected)
                    {
                        buttonPressed = noteGrid.QueryButtonsPressed(i + (octaveNo * NoteGrid.availableNoteTypes), j + (pageNo * NoteGrid.availableNoteButtons), GetActiveTab());
                    }

                    if(buttonPressed)
                    {
                        buttonColors[i][j].Color = Colors.Green;
                    }
                    else
                    {
                        buttonColors[i][j].Color = Colors.Red;
                    }
                }
            }

        }
        private string GetActiveTab()
        {
            if (sinSelected) return "Sin";
            else if (sawSelected) return "Saw";
            return "None";
        }

        public void NotePressed(Button srcButton)
        {
            if (srcButton != null)
            {
                int row = Grid.GetRow(srcButton);
                int column = Grid.GetColumn(srcButton);

                int OctavePosition = row + (NoteGrid.availableNoteTypes * octaveNo);
                int NotePosition = column + (NoteGrid.availableNoteButtons * pageNo);

                if (noteGrid.QueryButtonsPressed(OctavePosition, NotePosition, GetActiveTab()))
                {
                    buttonColors[row][column].Color = Colors.Red;
                }
                else
                {
                    buttonColors[row][column].Color = Colors.Green;
                }
                noteGrid.SwitchButtonsPressed(OctavePosition, NotePosition, GetActiveTab());
            }
        }

        public void SelectPage(Button srcButton)
        {
            int row = Grid.GetRow(srcButton);
            int col = Grid.GetColumn(srcButton);
            pageNo = (3*row) + col;
            CurrentPageNo = "Page: ";
            UpdateActiveButtons();
            //refresh buttons
            //make button background a Binding
            //when changing page number query the grid for the page and position
            //and change those bindings based on the queries
        }

        public void SelectOctave(Button srcButton)
        {
            int row = Grid.GetRow(srcButton);
            int col = Grid.GetColumn(srcButton);
            octaveNo = (2*row) + col;
            CurrentOctaveNo = "Octave: ";
            UpdateActiveButtons();

        }
        private void PlaySelected()
        {
            NoSongPlaying = false;
            Thread songThread = new Thread(new ThreadStart(PlaySongOnThread));
            songThread.Start();
        }

        private void PlaySongOnThread()
        {
            if (noteGrid.GetCurrentSong() != null)
            {
                using (var wo = new WaveOutEvent())
                {
                    wo.Init(noteGrid.GetCurrentSong());
                    noteGrid.ReleaseCurrentSong();
                    wo.Play();
                    while (wo.PlaybackState == PlaybackState.Playing)
                    {

                        Thread.Sleep(100);
                    }
                }
            }
            NoSongPlaying = true;
        }

        private void PlayChords()
        {
            NoteDetails myC = new NoteDetails(0.1f, noteGrid.Notes["C4"], 1.5f, SignalGeneratorType.Sin);
            NoteDetails myE = new NoteDetails(0.1f, noteGrid.Notes["E4"], 1.5f, SignalGeneratorType.Sin);
            NoteDetails myE3 = new NoteDetails(0.1f, noteGrid.Notes["E3"], 1.5f, SignalGeneratorType.Sin);
            NoteDetails myG = new NoteDetails(0.1f, noteGrid.Notes["G4"], 1.5f, SignalGeneratorType.Sin);
            var concat = noteGrid.CombineNotes(new NoteDetails[] { myC, myE, myG });
            var concat2 = noteGrid.CombineNotes(new NoteDetails[] { myC, myE3, myG });

            var silence = new SilenceProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1)).ToSampleProvider().Take(TimeSpan.FromSeconds(0.5));

            var playlist = new ConcatenatingSampleProvider(new[] { concat, silence, concat2 });
            //var concat = CreateMetronome(5, 0.1f,D3,0.2f);
            //https://stackoverflow.com/questions/65726394/playing-waveform-with-naudio-lower-for-each-turn
            //https://github.com/naudio/NAudio/issues/373

            //TRY THIS TO FIX CUT SOUND
            //https://mark-dot-net.blogspot.com/2009/10/playback-of-sine-wave-in-naudio.html

            using (var wo = new WaveOutEvent())
            {
                wo.Init(playlist);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(500);
                }
            }
            //
            //var wout = new WaveOutEvent();
            //wout.Init(playlist);
            //string tempFile = "C:\\Users\\m015290m\\Documents\\GitHub\\Synth\\NAudioSynth\\Output\\out.wav";
            //WaveFormat waveFormat = playlist.WaveFormat;
            //WaveFileWriter.CreateWaveFile(tempFile, playlist.ToWaveProvider());
        }

        private NoteDetails FormNote(int noteType, int notePosition, SignalGeneratorType signalType)
        {
            switch (noteType)
            {
                case (0):
                    return new NoteDetails(0.2f, noteGrid.Notes["C" + notePosition], .2f, SignalGeneratorType.Sin);
                case (1):
                    return new NoteDetails(0.2f, noteGrid.Notes["D" + notePosition], .2f, SignalGeneratorType.Sin);
                case (2):
                    return new NoteDetails(0.2f, noteGrid.Notes["E" + notePosition], .2f, SignalGeneratorType.Sin);
                case (3):
                    return new NoteDetails(0.2f, noteGrid.Notes["F" + notePosition], .2f, SignalGeneratorType.Sin);
                case (4):
                    return new NoteDetails(0.2f, noteGrid.Notes["G" + notePosition], .2f, SignalGeneratorType.Sin);
                case (5):
                    return new NoteDetails(0.2f, noteGrid.Notes["A" + notePosition], .2f, SignalGeneratorType.Sin);
                case (6):
                    return new NoteDetails(0.2f, noteGrid.Notes["B" + notePosition], .2f, SignalGeneratorType.Sin);
                default:
                    return new NoteDetails();
                    break;
            }
        }

        private void GenerateSelceted()
        {
            int latestNote = 0;
            for (int rows = 0; rows < NoteGrid.totalNoteTypes; rows++)
            {
                for (int cols = (NoteGrid.totalNotes) - 1; cols >= latestNote; cols--)
                {
                    if (noteGrid.QueryButtonsPressed(rows, cols, "Sin") || noteGrid.QueryButtonsPressed(rows, cols, "Saw"))
                    {
                        latestNote = cols;
                        break;
                    }
                }
            }

            List<ISampleProvider> song = new List<ISampleProvider>();

            for (int i = 0; i < latestNote+1; i++)
            {
                List<NoteDetails> notesToPlay = new List<NoteDetails>();
                for (int j = 0; j < NoteGrid.totalNoteTypes; j++)
                {
                    int noteType = j % NoteGrid.availableNoteTypes;
                    int notePosition = j / NoteGrid.availableNoteTypes;
                    if (noteGrid.QueryButtonsPressed(j, i, "Sin"))
                    {
                        notesToPlay.Add(FormNote(noteType, notePosition, SignalGeneratorType.Sin));
                    }
                    if(noteGrid.QueryButtonsPressed(j,i,"Saw"))
                    {
                        notesToPlay.Add(FormNote(noteType, notePosition, SignalGeneratorType.SawTooth));
                    }
                }
                if (notesToPlay.Count > 0)
                {
                    //NoteDetails[] notesToPlayArr = notesToPlay.ToArray();
                    song.Add(noteGrid.CombineNotes(notesToPlay));
                }
                else
                {
                    song.Add(noteGrid.GenSilence(.2f));
                }
            }
            noteGrid.SetCurrentSong(new ConcatenatingSampleProvider(song));
        }
    }
}
