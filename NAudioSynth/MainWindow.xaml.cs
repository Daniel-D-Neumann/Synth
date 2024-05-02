using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.DirectoryServices.ActiveDirectory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

//https://plus.maths.org/content/magical-mathematics-music
//https://gomixing.com/mixing/note-to-frequency-chart-mixing-in-key/

namespace NAudioSynth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Anything below 2 should be used for bass only
        float C0 = 16.35f, C1 = 32.7f, C2 = 65.41f, C3 = 130.81f, C4 = 261.63f, C5 = 523.25f;
        float C0S = 17.32f, C1S = 34.65f, C2S = 69.30f, C3S = 138.59f, C4S = 277.18f, C5S = 554.37f;
        float D0 = 18.35f, D1 = 36.71f, D2 = 73.42f, D3 = 146.83f, D4 = 293.67f, D5 = 587.33f;
        float D0S = 19.45f, D1S = 38.89f, D2S = 77.78f, D3S = 155.56f, D4S = 311.13f, D5S = 622.25f;
        float E0 = 20.60f, E1 = 41.2f, E2 = 82.41f, E3 = 164.81f, E4 = 329.63f, E5 = 659.26f;
        float F0 = 21.83f, F1 = 43.65f, F2 = 87.31f, F3 = 174.61f, F4 = 349.23f, F5 = 698.46f;
        float F0S = 23.12f, F1S = 46.25f, F2S = 92.50f, F3S = 185f, F4S = 369.99f, F5S = 739.99f;
        float G0 = 24.5f, G1 = 49f, G2 = 98f, G3 = 196f, G4 = 392f, G5 = 783.99f;
        float G0S = 25.96f, G1S = 51.91f, G2S = 103.83f, G3S = 207.65f, G4S = 415.31f, G5S = 830.61f;
        float A0 = 27.5f, A1 = 55f, A2 = 110f, A3 = 220f, A4 = 440f, A5 = 880f;
        float A0S = 29.14f, A1S = 58.27f, A2S = 116.54f, A3S = 233.08f, A4S = 466.16f, A5S = 923.33f;
        float B0 = 30.87f , B1 = 61.74f, B2 = 123.47f, B3 = 246.94f, B4 = 493.88f, B5 = 987.77f;

        

        public MainWindow()
        {
            InitializeComponent();
        }

        private ISampleProvider GenD3()
        {
            return new SignalGenerator()
            {
                Gain = 30,
                Frequency = 150,
                Type = SignalGeneratorType.Sin
            }
            .Take(TimeSpan.FromSeconds(.2));
        }

        private ISampleProvider GenNote(float gain, float frequency, float time, SignalGeneratorType type) 
        {
            ISampleProvider note = new SignalGenerator()
            {
                Gain = gain,
                Frequency = frequency,
                Type = type
            }.Take(TimeSpan.FromSeconds(time));

            return new AdsrSampleProvider(note.ToMono())
            {
                AttackSeconds = 0.3f,
                ReleaseSeconds = 0.3f
            };
        }

        private ISampleProvider GenSilence(float time)
        {
            return new SilenceProvider(new WaveFormat()).ToSampleProvider().Take(TimeSpan.FromSeconds(time));
        }

        private ISampleProvider CreateMetronome(int length, float gain, float frequency, float time)
        {
            ISampleProvider[] metronomeConcat = new ISampleProvider[length*2];
            //ISampleProvider myNote = GenD3();            
            for (int i = 0; i < length; i++)
            {
                metronomeConcat[i*2] = GenNote(gain,frequency,time, SignalGeneratorType.Sin);
                //OffsetSampleProvider
                metronomeConcat[(i*2)+1] = /*GenNote(gain,frequency,time)*/ GenSilence(.2f);
            }

            ISampleProvider metronome = new ConcatenatingSampleProvider(metronomeConcat);
            return metronome;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var DLow = new SignalGenerator()
            //{
            //    Gain = 0.2,
            //    Frequency = 150,
            //    Type = SignalGeneratorType.Sin

            //}.Take(TimeSpan.FromSeconds(.2));

            //var silence = new SilenceProvider(new WaveFormat()).ToSampleProvider().Take(TimeSpan.FromSeconds(.2));
            //var A = new SignalGenerator()
            //{
            //    Gain = 0.2,
            //    Frequency = 440,
            //    Type = SignalGeneratorType.Sin
            //}
            //.Take(TimeSpan.FromSeconds(.2));
            //var GSharp = new SignalGenerator()
            //{
            //    Gain = 0.2,
            //    Frequency = 400,
            //    Type = SignalGeneratorType.Sin
            //}
            //.Take(TimeSpan.FromSeconds(.2));
            //var C = new SignalGenerator()
            //{
            //    Gain = 0.2,
            //    Frequency = 280,
            //    Type = SignalGeneratorType.Sin
            //}
            //.Take(TimeSpan.FromSeconds(.2));
            //var D = new SignalGenerator()
            //{
            //    Gain = 0.2,
            //    Frequency = 300,
            //    Type = SignalGeneratorType.Sin
            //}
            //.Take(TimeSpan.FromSeconds(.2));
            //var playlist = new ConcatenatingSampleProvider(new[] { DLow,silence, GSharp, silence, D, silence, A, silence, GSharp});

            //var concat = DLow.FollowedBy(silence).FollowedBy(DLow);
            //concat.AddMixerInput(CreateMetronome(5,0.1f,C4,1.5f));
            ISampleProvider E = GenNote(0.1f, E4, 1.5f, SignalGeneratorType.Sin);
            //var Eenveloped = new AdsrSampleProvider(E.ToMono())
            //{
            //    AttackSeconds = 0.3f,
            //    ReleaseSeconds = 0.3f
            //};
            ISampleProvider C = GenNote(0.1f, C4, 1.5f, SignalGeneratorType.Sin);
            //var Cenveloped = new AdsrSampleProvider(C.ToMono())
            //{
            //    AttackSeconds = 0.3f,
            //    ReleaseSeconds = 0.3f
            //};
            ISampleProvider G = GenNote(0.1f, G4, 1.5f, SignalGeneratorType.Sin);
            //var Genveloped = new AdsrSampleProvider(G.ToMono())
            //{
            //    AttackSeconds = 0.3f,
            //    ReleaseSeconds = 0.3f
            //};
            MixingSampleProvider concat = new MixingSampleProvider(E.WaveFormat);
            concat.AddMixerInput(E);
            concat.AddMixerInput(C);
            concat.AddMixerInput(G);

            ISampleProvider E2 = GenNote(0.1f, E4, 1.5f, SignalGeneratorType.Sin);
            ISampleProvider C2 = GenNote(0.1f, C3, 1.5f, SignalGeneratorType.Sin);
            ISampleProvider G2 = GenNote(0.1f, G4, 1.5f, SignalGeneratorType.Sin);

            MixingSampleProvider concat2 = new MixingSampleProvider(E.WaveFormat);
            concat2.AddMixerInput(E2);
            concat2.AddMixerInput(C2);
            concat2.AddMixerInput(G2);

            var playlist = new ConcatenatingSampleProvider(new[] { concat,concat2 });
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
                //wo.Init(D);
                //wo.Play();
                //while (wo.PlaybackState == PlaybackState.Playing)
                //{
                //    Thread.Sleep(100);
                //}
            }
            //var wout = new WaveOutEvent();
            //wout.Init(concat);
            //string tempFile = "C:\\Users\\m015290m\\Documents\\GitHub\\Synth\\NAudioSynth\\Output\\out.wav";
            //WaveFormat waveFormat = concat.WaveFormat;
            //WaveFileWriter.CreateWaveFile(tempFile, concat.ToWaveProvider());
        }
    }
}
