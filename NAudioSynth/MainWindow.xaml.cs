using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.IO;
using NAudioSynth.ViewModel;
using System.Windows.Controls;
using System.Windows.Media;

//https://plus.maths.org/content/magical-mathematics-music
//https://gomixing.com/mixing/note-to-frequency-chart-mixing-in-key/

namespace NAudioSynth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ISampleProvider currentSong;
        //MemoryStream genSong;

        //TODO ON NEW WINDOW INCREMENT/DECREMENT PAGE NO AND RESET THE BUTTONS
        //CAN'T GO ABOVE A MAX PAGE NO

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    NoteDetails myC = new NoteDetails(0.1f, Notes["C4"], 1.5f, SignalGeneratorType.Sin);
        //    NoteDetails myE = new NoteDetails(0.1f, Notes["E4"], 1.5f, SignalGeneratorType.Sin);
        //    NoteDetails myE3 = new NoteDetails(0.1f, Notes["E3"], 1.5f, SignalGeneratorType.Sin);
        //    NoteDetails myG = new NoteDetails(0.1f, Notes["G4"], 1.5f, SignalGeneratorType.Sin);
        //    var concat = CombineNotes(new NoteDetails[] { myC, myE, myG });
        //    var concat2 = CombineNotes(new NoteDetails[] { myC, myE3, myG });

        //    var silence = new SilenceProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1)).ToSampleProvider().Take(TimeSpan.FromSeconds(0.5));

        //    var playlist = new ConcatenatingSampleProvider(new[] { concat, silence, concat2 });
        //    //var concat = CreateMetronome(5, 0.1f,D3,0.2f);
        //    //https://stackoverflow.com/questions/65726394/playing-waveform-with-naudio-lower-for-each-turn
        //    //https://github.com/naudio/NAudio/issues/373

        //    //TRY THIS TO FIX CUT SOUND
        //    //https://mark-dot-net.blogspot.com/2009/10/playback-of-sine-wave-in-naudio.html

        //    using (var wo = new WaveOutEvent())
        //    {
        //        wo.Init(playlist);
        //        wo.Play();
        //        while (wo.PlaybackState == PlaybackState.Playing)
        //        {
        //            Thread.Sleep(500);
        //        }
        //    }
        //    //
        //    //var wout = new WaveOutEvent();
        //    //wout.Init(playlist);
        //    //string tempFile = "C:\\Users\\m015290m\\Documents\\GitHub\\Synth\\NAudioSynth\\Output\\out.wav";
        //    //WaveFormat waveFormat = playlist.WaveFormat;
        //    //WaveFileWriter.CreateWaveFile(tempFile, playlist.ToWaveProvider());
        //}
        static MainWindowViewModel viewModel = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            //viewModel = new MainWindowViewModel();
            DataContext = viewModel;
        }

        public static MainWindowViewModel getViewModel() { return viewModel; }

        private void UpdateNotePressed(object sender, RoutedEventArgs e)
        {
            Button? srcButton = e.Source as Button;
            if(srcButton != null)
            {
                viewModel.NotePressed(srcButton);
            }
        }

        //private ISampleProvider GenNote(float gain, float frequency, float time, SignalGeneratorType type) 
        //{
        //    ISampleProvider note = new SignalGenerator(44100, 1)
        //    {
        //        Gain = gain,
        //        Frequency = frequency,
        //        Type = type
        //    }.Take(TimeSpan.FromSeconds(time));

        //    return new AdsrSampleProvider(note)
        //    {
        //        AttackSeconds = 0.3f,
        //        ReleaseSeconds = 0.3f
        //    };
        //}

        //private ISampleProvider GenNote(NoteDetails noteDetails)
        //{
        //    ISampleProvider note = new SignalGenerator(44100, 1)
        //    {
        //        Gain = noteDetails.gain,
        //        Frequency = noteDetails.frequency,
        //        Type = noteDetails.generatorType
        //    }.Take(TimeSpan.FromSeconds(noteDetails.time));

        //    return new AdsrSampleProvider(note)
        //    {
        //        AttackSeconds = 0.3f,
        //        ReleaseSeconds = 0.3f
        //    };
        //}

        //private ISampleProvider GenSilence(float time)
        //{
        //    return new SilenceProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100,1)).ToSampleProvider().Take(TimeSpan.FromSeconds(time));
        //}

        //private ISampleProvider CreateMetronome(int length, float gain, float frequency, float time)
        //{
        //    ISampleProvider[] metronomeConcat = new ISampleProvider[length*2];
        //    //ISampleProvider myNote = GenD3();            
        //    for (int i = 0; i < length; i++)
        //    {
        //        metronomeConcat[i*2] = GenNote(gain,frequency,time, SignalGeneratorType.Sin);
        //        //OffsetSampleProvider
        //        metronomeConcat[(i*2)+1] = /*GenNote(gain,frequency,time)*/ GenSilence(time);
        //    }

        //    ISampleProvider metronome = new ConcatenatingSampleProvider(metronomeConcat);
        //    return metronome;
        //}

        //private ISampleProvider CombineNotes(NoteDetails[] notes)
        //{
        //    MixingSampleProvider combiner = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
        //    foreach (NoteDetails note in notes)
        //    {
        //        combiner.AddMixerInput(GenNote(note));
        //    }
        //    return combiner;
        //}

        //private ISampleProvider CombineNotes(List<NoteDetails> notes)
        //{
        //    MixingSampleProvider combiner = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
        //    foreach (NoteDetails note in notes)
        //    {
        //        combiner.AddMixerInput(GenNote(note));
        //    }
        //    return combiner;
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    List<ISampleProvider> song = new List<ISampleProvider>();
        //    //TODO REWRITE LOOP WITH HOW MANY BUTTONS
        //    for (int i = 0; i < availableNoteButtons; i++)
        //    {
        //        List<NoteDetails> notesToPlay = new List<NoteDetails>();
        //        for(int j = 0; j < availableNoteTypes; j++)
        //        {
        //            if (buttonsPressed[j][i])
        //            {
        //                switch (j)
        //                {
        //                    case (0):
        //                        notesToPlay.Add(new NoteDetails(0.2f, Notes["C4"],1.5f,SignalGeneratorType.Sin));
        //                        break;
        //                    case (1):
        //                        notesToPlay.Add(new NoteDetails(0.2f, Notes["D4"], 1.5f, SignalGeneratorType.Sin));
        //                        break;
        //                    case (2):
        //                        notesToPlay.Add(new NoteDetails(0.2f, Notes["E4"], 1.5f, SignalGeneratorType.Sin));
        //                        break;
        //                    case (3):
        //                        notesToPlay.Add(new NoteDetails(0.2f, Notes["F4"], 1.5f, SignalGeneratorType.Sin));
        //                        break;
        //                    case (4):
        //                        notesToPlay.Add(new NoteDetails(0.2f, Notes["G4"], 1.5f, SignalGeneratorType.Sin));
        //                        break;
        //                    case (5):
        //                        notesToPlay.Add(new NoteDetails(0.2f, Notes["A4"], 1.5f, SignalGeneratorType.Sin));
        //                        break;
        //                    case (6):
        //                        notesToPlay.Add(new NoteDetails(0.2f, Notes["B4"], 1.5f, SignalGeneratorType.Sin));
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //        }
        //        if (notesToPlay.Count > 0)
        //        {
        //            //NoteDetails[] notesToPlayArr = notesToPlay.ToArray();
        //            song.Add(CombineNotes(notesToPlay));
        //        }
        //        else
        //        {
        //            song.Add(GenSilence(1.5f));
        //        }
        //    }

        //    currentSong = new ConcatenatingSampleProvider(song);
        //    //genSong = currentSong;
        //}

        //private void Play_Generated(object sender, RoutedEventArgs e)
        //{
        //    using (var wo = new WaveOutEvent())
        //    {
        //        wo.Init(currentSong);
        //        wo.Play();
        //        while (wo.PlaybackState == PlaybackState.Playing)
        //        {
        //            Thread.Sleep(500);
        //        }
        //    }
        //}
    }
}
