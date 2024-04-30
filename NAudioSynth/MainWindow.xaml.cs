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

namespace NAudioSynth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float D3 = 150;
        

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

        private ISampleProvider GenNote(float gain, float frequency, float time) 
        {
            return new SignalGenerator()
            {
                Gain = gain,
                Frequency = frequency,
            }.Take(TimeSpan.FromSeconds(.2));
        }

        private ISampleProvider GenSilence()
        {
            return new SilenceProvider(new WaveFormat()).ToSampleProvider().Take(TimeSpan.FromSeconds(.2));
        }

        private ISampleProvider CreateMetronome(int length, float gain, float frequency, float time)
        {
            ISampleProvider[] metronomeConcat = new ISampleProvider[length*2];
            //ISampleProvider myNote = GenD3();            
            for (int i = 0; i < length; i++)
            {
                metronomeConcat[i*2] = GenNote(gain,frequency,time);
                //OffsetSampleProvider
                metronomeConcat[(i*2)+1] = GenSilence();
            }

            ISampleProvider metronome = new ConcatenatingSampleProvider(metronomeConcat);
            return metronome;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var DLow = new SignalGenerator()
            {
                Gain = 0.2,
                Frequency = 150,
                Type = SignalGeneratorType.Sin

            }.Take(TimeSpan.FromSeconds(.2));

            var silence = new SilenceProvider(new WaveFormat()).ToSampleProvider().Take(TimeSpan.FromSeconds(.2));
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

            var concat = CreateMetronome(5, 0.2f,D3,0.2f);
        //https://stackoverflow.com/questions/65726394/playing-waveform-with-naudio-lower-for-each-turn
        //https://github.com/naudio/NAudio/issues/373

            using (var wo = new WaveOutEvent())
            {
                wo.Init(concat);
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
        }
    }
}
