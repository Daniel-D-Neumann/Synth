using NAudio.Wave;
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
using System.IO;
using System.Text.RegularExpressions;

namespace NAudioSynth.ViewModel
{
    public class ButtonDetails
    {
        SolidColorBrush backgroundColor;
        public SolidColorBrush BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                MainWindow.getViewModel().OnPropertyChanged();
            }
        }
        bool connected;

        public bool Connected
        {
            get { return connected; }
            set
            {
                connected = value;
                MainWindow.getViewModel().OnPropertyChanged();
            }
        }
        public ButtonDetails(SolidColorBrush color, bool isConnected)
        {
            backgroundColor = color;
            connected = isConnected;
        }
    }

    public class MainWindowViewModel : ViewModel
    {
        public int pageNo = 0;
        public int octaveNo = 0;

        public int[] selectedButtonData = new int[2];

        NoteGrid noteGrid = new NoteGrid();
        public RelayCommand PlayCommand => new RelayCommand(execute => PlaySelected(), canExecute => noteGrid.GetCurrentSong() != null);
        public RelayCommand PlayChordsCommand => new RelayCommand(execute => PlayChords(), canExecute=> noSongPlaying);

        public RelayCommand GenerateSelectedCommand => new RelayCommand(execute => GenSelected());

        public RelayCommand ExportCommand => new RelayCommand(execute => ExportWAV());

        public int buttonPressedRow;
        public int buttonPressedColumn;
        public List<List<ButtonDetails>> buttonDetails;

        private string filePathRegex = @"^[\w\-. ]+$";

        #region ButtonProperties
        private ButtonDetails b00 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B00
        {
            get { return b00; }
            set
            {
                b00 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b01 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B01
        {
            get { return b01; }
            set
            {
                b01 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b02 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B02
        {
            get { return b02; }
            set
            {
                b02 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b03 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B03
        {
            get { return b03; }
            set
            {
                b03 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b04 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B04
        {
            get { return b04; }
            set
            {
                b04 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b05 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B05
        {
            get { return b05; }
            set
            {
                b05 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b06 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B06
        {
            get { return b06; }
            set
            {
                b06 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b07 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B07
        {
            get { return b07; }
            set
            {
                b07 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b10 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B10
        {
            get { return b10; }
            set
            {
                b10 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b11 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B11
        {
            get { return b11; }
            set
            {
                b11 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b12 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B12
        {
            get { return b12; }
            set
            {
                b12 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b13 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B13
        {
            get { return b13; }
            set
            {
                b13 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b14 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B14
        {
            get { return b14; }
            set
            {
                b14 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b15 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B15
        {
            get { return b15; }
            set
            {
                b15 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b16 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B16
        {
            get { return b16; }
            set
            {
                b16 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b17 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B17
        {
            get { return b17; }
            set
            {
                b17 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b20 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B20
        {
            get { return b20; }
            set
            {
                b20 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b21 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B21
        {
            get { return b21; }
            set
            {
                b21 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b22 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B22
        {
            get { return b22; }
            set
            {
                b22 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b23 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B23
        {
            get { return b23; }
            set
            {
                b23 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b24 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B24
        {
            get { return b24; }
            set
            {
                b04 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b25 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B25
        {
            get { return b25; }
            set
            {
                b25 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b26 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B26
        {
            get { return b26; }
            set
            {
                b26 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b27 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B27
        {
            get { return b27; }
            set
            {
                b27 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b30 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B30
        {
            get { return b30; }
            set
            {
                b30 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b31 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B31
        {
            get { return b31; }
            set
            {
                b31 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b32 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B32
        {
            get { return b32; }
            set
            {
                b32 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b33 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B33
        {
            get { return b33; }
            set
            {
                b33 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b34 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B34
        {
            get { return b34; }
            set
            {
                b34 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b35 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B35
        {
            get { return b35; }
            set
            {
                b35 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b36 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B36
        {
            get { return b36; }
            set
            {
                b36 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b37 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B37
        {
            get { return b37; }
            set
            {
                b37 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b40 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B40
        {
            get { return b40; }
            set
            {
                b40 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b41 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B41
        {
            get { return b41; }
            set
            {
                b41 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b42 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B42
        {
            get { return b42; }
            set
            {
                b42 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b43 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B43
        {
            get { return b43; }
            set
            {
                b43 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b44 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B44
        {
            get { return b44; }
            set
            {
                b44 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b45 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B45
        {
            get { return b45; }
            set
            {
                b45 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b46 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B46
        {
            get { return b46; }
            set
            {
                b46 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b47 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B47
        {
            get { return b47; }
            set
            {
                b47 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b50 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B50
        {
            get { return b50; }
            set
            {
                b50 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b51 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B51
        {
            get { return b51; }
            set
            {
                b51 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b52 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B52
        {
            get { return b52; }
            set
            {
                b52 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b53 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B53
        {
            get { return b53; }
            set
            {
                b53 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b54 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B54
        {
            get { return b54; }
            set
            {
                b54 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b55 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B55
        {
            get { return b55; }
            set
            {
                b55 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b56 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B56
        {
            get { return b56; }
            set
            {
                b56 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b57 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B57
        {
            get { return b57; }
            set
            {
                b57 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b60 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B60
        {
            get { return b60; }
            set
            {
                b60 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b61 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B61
        {
            get { return b61; }
            set
            {
                b61 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b62 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B62
        {
            get { return b62; }
            set
            {
                b62 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b63 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B63
        {
            get { return b63; }
            set
            {
                b63 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b64 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B64
        {
            get { return b64; }
            set
            {
                b64 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b65 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B65
        {
            get { return b65; }
            set
            {
                b65 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b66 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B66
        {
            get { return b66; }
            set
            {
                b66 = value;
                OnPropertyChanged();
            }
        }
        private ButtonDetails b67 = new ButtonDetails(new SolidColorBrush(Colors.Red), false);

        public ButtonDetails B67
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
            buttonDetails = new List<List<ButtonDetails>>
            {
                new List<ButtonDetails>() {B00,B01,B02,B03,B04,B05,B06,B07},
                new List<ButtonDetails>() {B10,B11,B12,B13,B14,B15,B16,B17},
                new List<ButtonDetails>() {B20,B21,B22,B23,B24,B25,B26,B27},
                new List<ButtonDetails>() {B30,B31,B32,B33,B34,B35,B36,B37},
                new List<ButtonDetails>() {B40,B41,B42,B43,B44,B45,B46,B47},
                new List<ButtonDetails>() {B50,B51,B52,B53,B54,B55,B56,B57},
                new List<ButtonDetails>() {B60,B61,B62,B63,B64,B65,B66,B67},
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

        private bool songAvailable;

        public bool SongAvailable
        {
            get { return songAvailable; }
            set 
            { 
                songAvailable = value;
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

        private bool buttonSelected = false;

        public bool ButtonSelected
        {
            get { return buttonSelected; }
            set 
            { 
                buttonSelected = value;
                OnPropertyChanged();
            }
        }


        private string selectedButton = "Selected Button:";

        public string SelectedButton
        {
            get { return selectedButton; }
            set 
            { 
                selectedButton = value; 
                OnPropertyChanged();
            }
        }

        private bool selectedButtonActive;

        public bool SelectedButtonActive
        {
            get { return selectedButtonActive; }
            set 
            { 
                selectedButtonActive = value;
                int octavePosition = GetOctavePosition();
                int notePosition = GetNotePosition();
                if (selectedButtonActive)
                {
                    buttonDetails[selectedButtonData[0]][selectedButtonData[1]].BackgroundColor.Color = Colors.Green;
                }
                else
                {
                    buttonDetails[selectedButtonData[0]][selectedButtonData[1]].BackgroundColor.Color = Colors.Red;
                }
                noteGrid.UpdateButtonsPressed(octavePosition, notePosition, selectedButtonActive, GetActiveTab());

                OnPropertyChanged();
            }
        }

        private bool selectedButtonConnected;

        public bool SelectedButtonConnected
        {
            get { return selectedButtonConnected; }
            set 
            { 
                selectedButtonConnected = value;
                int octavePosition = GetOctavePosition();
                int notePosition = GetNotePosition();
                noteGrid.UpdateButtonConnected(octavePosition, notePosition, SelectedButtonConnected, GetActiveTab());
                OnPropertyChanged();
            }
        }

        private float selectedButtonVolume;

        public float SelectedButtonVolume
        {
            get { return selectedButtonVolume; }
            set 
            {
                selectedButtonVolume = value;
                int octavePosition = GetOctavePosition();
                int notePosition = GetNotePosition();
                noteGrid.SetVolume(octavePosition, notePosition, selectedButtonVolume*0.01f, GetActiveTab());
                OnPropertyChanged();
            }
        }

        private string exportFilePath;

        public string ExportFilePath
        {
            get { return exportFilePath; }
            set 
            { 
                exportFilePath = value; 
                OnPropertyChanged();
            }
        }

        private string exportError;
        public string ExportError
        {
            get { return exportError; }
            set 
            {
                exportError = value;
                OnPropertyChanged();
            }
        }

        private int GetOctavePosition()
        {
            return selectedButtonData[0] + (NoteGrid.availableNoteTypes * octaveNo);
        }
        private int GetNotePosition()
        {
            return selectedButtonData[1] + (NoteGrid.availableNoteButtons * pageNo);
        }

        private void UpdateActiveButtons()
        {
            //TODO MAKE FUNCTION REFRESH CONNECTED ATTRIBUTE
            ButtonSelected = false;
            SelectedButton = "Selected Button:";
            for (int i = 0; i < NoteGrid.availableNoteTypes; i++)
            {
                for(int j = 0; j < NoteGrid.availableNoteButtons; j++)
                {
                    bool buttonPressed = false;
                    bool connectedPressed = false;
                    if(SinSelected)
                    {
                        buttonPressed = noteGrid.QueryButtonsPressed(i+(octaveNo*NoteGrid.availableNoteTypes), j+(pageNo*NoteGrid.availableNoteButtons), GetActiveTab());
                        connectedPressed = noteGrid.QueryConnected(i + (octaveNo * NoteGrid.availableNoteTypes), j + (pageNo * NoteGrid.availableNoteButtons), GetActiveTab());
                    }
                    else if (sawSelected)
                    {
                        buttonPressed = noteGrid.QueryButtonsPressed(i + (octaveNo * NoteGrid.availableNoteTypes), j + (pageNo * NoteGrid.availableNoteButtons), GetActiveTab());
                        connectedPressed = noteGrid.QueryConnected(i + (octaveNo * NoteGrid.availableNoteTypes), j + (pageNo * NoteGrid.availableNoteButtons), GetActiveTab());
                    }
                    if (buttonPressed)
                    {
                        buttonDetails[i][j].BackgroundColor.Color = Colors.Green;
                    }
                    else
                    {
                        buttonDetails[i][j].BackgroundColor.Color = Colors.Red;
                    }

                    if(connectedPressed)
                    {
                        buttonDetails[i][j].Connected = true;
                    }
                    else
                    {
                        buttonDetails[i][j].Connected = false;
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

        public void VolumeChanged(float newVol)
        {
            SelectedButtonVolume = newVol;
        }

        public void NotePressed(Button srcButton)
        {
            if (srcButton != null)
            {
                int row = Grid.GetRow(srcButton);
                int column = Grid.GetColumn(srcButton);

                selectedButtonData[0] = row;
                selectedButtonData[1] = column;
                if (!ButtonSelected) ButtonSelected = true;

                SelectedButton = "Selected Button: ("+row+","+column+")";

                int OctavePosition = row + (NoteGrid.availableNoteTypes * octaveNo);
                int NotePosition = column + (NoteGrid.availableNoteButtons * pageNo);

                //bool isActive = noteGrid.QueryButtonsPressed(OctavePosition, NotePosition, GetActiveTab());
                //if(isActive) SelectedButtonActive = false;
                //else SelectedButtonActive = true;
                SelectedButtonConnected = noteGrid.QueryConnected(OctavePosition, NotePosition, GetActiveTab());
                SelectedButtonActive = !noteGrid.QueryButtonsPressed(OctavePosition, NotePosition, GetActiveTab());
                SelectedButtonVolume = noteGrid.QueryVolume(OctavePosition,NotePosition,GetActiveTab()) *100;
            }
        }

        public void ConnectedPressed(Button srcButton)
        {
            int row = Grid.GetRow(srcButton);
            int column = Grid.GetColumn(srcButton);

            int OctavePosition = row + (NoteGrid.availableNoteTypes * octaveNo);
            int NotePosition = column + (NoteGrid.availableNoteButtons * pageNo);

            noteGrid.SwitchConnectedProperty(OctavePosition,NotePosition, GetActiveTab());
            buttonDetails[row][column].Connected = !buttonDetails[row][column].Connected;
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
            SongAvailable = false;
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

        private NoteDetails FormNote(float gain, int noteType, int notePosition, SignalGeneratorType signalType)
        {
            switch (noteType)
            {
                case (0):
                    return new NoteDetails(gain, noteGrid.Notes["C" + notePosition], NoteGrid.timePerNote, signalType);
                case (1):
                    return new NoteDetails(gain, noteGrid.Notes["D" + notePosition], NoteGrid.timePerNote, signalType);
                case (2):
                    return new NoteDetails(gain, noteGrid.Notes["E" + notePosition], NoteGrid.timePerNote, signalType);
                case (3):
                    return new NoteDetails(gain, noteGrid.Notes["F" + notePosition], NoteGrid.timePerNote, signalType);
                case (4):
                    return new NoteDetails(gain, noteGrid.Notes["G" + notePosition], NoteGrid.timePerNote, signalType);
                case (5):
                    return new NoteDetails(gain, noteGrid.Notes["A" + notePosition], NoteGrid.timePerNote, signalType);
                case (6):
                    return new NoteDetails(gain, noteGrid.Notes["B" + notePosition], NoteGrid.timePerNote, signalType);
                default:
                    return new NoteDetails();
            }
        }
        //instead of searching down create long concatenation of columns
        //then mix the longs together

        private void GenSelected()
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

            List<ISampleProvider> tracksToCombine = new List<ISampleProvider>();
            foreach (KeyValuePair<string,SignalGeneratorType> generatorType in noteGrid.generatorTypes)
            {
                //loop through available note types C-B octaves 0-5
                for (int i = 0; i < NoteGrid.totalNoteTypes; i++)
                {
                    //Create a track for each note type
                    List<ISampleProvider> notesToPlay = new List<ISampleProvider>(); ;

                    //loop through available note positions until the last note to be played is reached
                    for (int j = 0; j < latestNote + 1; j++)
                    {

                        //determine which note and at what octave it should be played at
                        int noteType = i % NoteGrid.availableNoteTypes;
                        int noteOctave = i / NoteGrid.availableNoteTypes;
                        //check if note needs to be played
                        if (noteGrid.QueryButtonsPressed(i, j, generatorType.Key))
                        {
                            //generate the note details
                            NoteDetails note = FormNote(noteGrid.QueryVolume(i,j,generatorType.Key),noteType, noteOctave, generatorType.Value);

                            //check if the note should be held or tapped
                            bool noteHeld = noteGrid.QueryConnected(i, j, generatorType.Key);
                            //keep incrementing along until reaching a note that shouldn't be connected
                            while (noteHeld && j < NoteGrid.totalNotes)
                            {
                                j++;
                                //extend the current note
                                note.time += NoteGrid.timePerNote;
                                noteHeld = noteGrid.QueryConnected(i, j, generatorType.Key);
                                //if the next note shouldn't be connected we still need to perform the other logic on it so decrement the loop counter
                                if (!noteHeld) j--;
                            }

                            //add note to track
                            notesToPlay.Add(noteGrid.GenNote(note));
                        }
                        else
                        {
                            //add silence to track
                            notesToPlay.Add(noteGrid.GenSilence(NoteGrid.timePerNote));
                        }
                    }
                    //combine notes into track
                    if (notesToPlay.Count > 0)
                    {
                        tracksToCombine.Add(noteGrid.ConcatenateNotes(notesToPlay));
                    }
                }
            }

            //add to song
            if (tracksToCombine.Count > 0)
            {
                noteGrid.SetCurrentSong(noteGrid.CombineTracks(tracksToCombine));
                SongAvailable = true;
            }
            
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        //private void GenerateSelected()
        //{
        //    int latestNote = 0;
        //    for (int rows = 0; rows < NoteGrid.totalNoteTypes; rows++)
        //    {
        //        for (int cols = (NoteGrid.totalNotes) - 1; cols >= latestNote; cols--)
        //        {
        //            if (noteGrid.QueryButtonsPressed(rows, cols, "Sin") || noteGrid.QueryButtonsPressed(rows, cols, "Saw"))
        //            {
        //                latestNote = cols;
        //                break;
        //            }
        //        }
        //    }

        //    List<ISampleProvider> song = new List<ISampleProvider>();

        //    bool lastSinConnected = false;
        //    bool lastSawConnected = false;
        //    for (int i = 0; i < latestNote+1; i++)
        //    {
        //        List<NoteDetails> notesToPlay = new List<NoteDetails>();

        //        for (int j = 0; j < NoteGrid.totalNoteTypes; j++)
        //        {
        //            int noteType = j % NoteGrid.availableNoteTypes;
        //            int notePosition = j / NoteGrid.availableNoteTypes;
        //            if (noteGrid.QueryButtonsPressed(j, i, "Sin"))
        //            {
        //                if(lastSinConnected)
        //                {
        //                    lastSinConnected = noteGrid.QueryConnected(j, i-1, "Sin");
        //                }
        //                else
        //                {
        //                    NoteDetails note = FormNote(0.2f,noteType, notePosition, SignalGeneratorType.Sin);
        //                    bool nextConnected = noteGrid.QueryConnected(j, i, "Sin");
        //                    if(nextConnected)
        //                    {
        //                        lastSinConnected= true;
        //                        int inc = 1;
        //                        while (nextConnected)
        //                        {
        //                            note.time += 0.2f;
        //                            nextConnected = noteGrid.QueryConnected(j, i + inc, "Sin");
        //                            inc++;
        //                        }
        //                    }

        //                    notesToPlay.Add(note);
        //                }

        //            }
        //            if(noteGrid.QueryButtonsPressed(j,i,"Saw"))
        //            {
        //                notesToPlay.Add(FormNote(0.2f,noteType, notePosition, SignalGeneratorType.SawTooth));
        //            }
        //        }
        //        if (notesToPlay.Count > 0)
        //        {
        //            //NoteDetails[] notesToPlayArr = notesToPlay.ToArray();
        //            song.Add(noteGrid.CombineNotes(notesToPlay));
        //        }
        //        else
        //        {
        //            song.Add(noteGrid.GenSilence(.2f));
        //        }
        //    }
        //    noteGrid.SetCurrentSong(new ConcatenatingSampleProvider(song));
        //}

        private void ExportWAV()
        {
            if(!string.IsNullOrEmpty(exportFilePath))
            {
                var wout = new WaveOutEvent();
                wout.Init(noteGrid.GetCurrentSong());
                string filePath = AppDomain.CurrentDomain.BaseDirectory;
                filePath = filePath.Remove(filePath.Length - 25);
                filePath += "Output\\" + exportFilePath + ".wav";

                Regex re = new Regex(filePathRegex);

                //ensure file path is valid
                if(re.IsMatch(exportFilePath))
                {
                    //ensure file does not already exist
                    if (!File.Exists(filePath))
                    {
                        WaveFormat waveFormat = noteGrid.GetCurrentSong().WaveFormat;
                        WaveFileWriter.CreateWaveFile(filePath, noteGrid.GetCurrentSong().ToWaveProvider());
                        SongAvailable = false;
                        ExportError = "File created";
                    }
                    else
                    {
                        ExportError = "File exists";
                    }
                }
                else
                {
                    ExportError = "Invalid characters";
                }
            }
            else
            {
                ExportError = "No file name";
            }
            
            
        }
    }
}
