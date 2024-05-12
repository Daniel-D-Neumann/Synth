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

namespace NAudioSynth.ViewModel
{
    internal class MainWindowViewModel : ViewModel
    {
        public const int buttonsInRow = 16;
        public const int availableNoteTypes = 7;
        public const int availableNoteButtons = 2;
        public int pageNo = 0;

        NoteGrid noteGrid = new NoteGrid();
        public RelayCommand PlayCommand => new RelayCommand(execute => PlaySelected(), canExecute => noteGrid.GetCurrentSong()!=null);
        public RelayCommand PlayChordsCommand => new RelayCommand(execute => PlayChords());

        public RelayCommand GenerateSelectedCommand => new RelayCommand(execute =>GenerateSelceted());

        public int buttonPressedRow;
        public int buttonPressedColumn;


        public void NotePressed(Button srcButton)
        {
            int NotePosition = 0;

            if (srcButton != null)
            {
                int row = Grid.GetRow(srcButton);
                int column = Grid.GetColumn(srcButton);

                NotePosition = column + (buttonsInRow * pageNo);

                if (noteGrid.QueryButtonsPressed(row, NotePosition))
                {
                    srcButton.Background = Brushes.Red;
                }
                else
                {
                    srcButton.Background = Brushes.Green;
                }
                noteGrid.SwitchButtonsPressed(row, NotePosition);
            }
        }

        private void PlaySelected()
        {
            if(noteGrid.GetCurrentSong()!=null)
            {
                using (var wo = new WaveOutEvent())
                {
                    wo.Init(noteGrid.GetCurrentSong());
                    noteGrid.ReleaseCurrentSong();
                    wo.Play();
                    while (wo.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(500);
                    }
                }
            }
           
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

        private void GenerateSelceted()
        {
            List<ISampleProvider> song = new List<ISampleProvider>();
            //TODO REWRITE LOOP WITH HOW MANY BUTTONS
            for (int i = 0; i < availableNoteButtons; i++)
            {
                List<NoteDetails> notesToPlay = new List<NoteDetails>();
                for (int j = 0; j < availableNoteTypes; j++)
                {
                    if (noteGrid.QueryButtonsPressed(j, i))
                    {
                        switch (j)
                        {
                            case (0):
                                notesToPlay.Add(new NoteDetails(0.2f, noteGrid.Notes["C4"], 1.5f, SignalGeneratorType.Sin));
                                break;
                            case (1):
                                notesToPlay.Add(new NoteDetails(0.2f, noteGrid.Notes["D4"], 1.5f, SignalGeneratorType.Sin));
                                break;
                            case (2):
                                notesToPlay.Add(new NoteDetails(0.2f, noteGrid.Notes["E4"], 1.5f, SignalGeneratorType.Sin));
                                break;
                            case (3):
                                notesToPlay.Add(new NoteDetails(0.2f, noteGrid.Notes["F4"], 1.5f, SignalGeneratorType.Sin));
                                break;
                            case (4):
                                notesToPlay.Add(new NoteDetails(0.2f, noteGrid.Notes["G4"], 1.5f, SignalGeneratorType.Sin));
                                break;
                            case (5):
                                notesToPlay.Add(new NoteDetails(0.2f, noteGrid.Notes["A4"], 1.5f, SignalGeneratorType.Sin));
                                break;
                            case (6):
                                notesToPlay.Add(new NoteDetails(0.2f, noteGrid.Notes["B4"], 1.5f, SignalGeneratorType.Sin));
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (notesToPlay.Count > 0)
                {
                    //NoteDetails[] notesToPlayArr = notesToPlay.ToArray();
                    song.Add(noteGrid.CombineNotes(notesToPlay));
                }
                else
                {
                    song.Add(noteGrid.GenSilence(1.5f));
                }
                noteGrid.SetCurrentSong(new ConcatenatingSampleProvider(song));
            }
        }
    }
}
