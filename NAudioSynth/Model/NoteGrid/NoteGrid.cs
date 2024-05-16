using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudioSynth.Model.NoteGrid
{
    public struct NoteDetails
    {
        public float gain;
        public float frequency;
        public float time;
        public SignalGeneratorType generatorType;

        public NoteDetails(float gain, float frequency, float time, SignalGeneratorType generatorType)
        {
            this.gain = gain;
            this.frequency = frequency;
            this.time = time;
            this.generatorType = generatorType;
        }
    }
    internal class NoteGrid
    {
        public const int availableNoteTypes = 7;
        public const int availableNoteButtons = 8;
        public const int availablePages = 15;
        public const int availableOctaves = 6;
        public bool songPlaying = false;
        ISampleProvider? currentSong;
        public ISampleProvider GetCurrentSong() { return currentSong; }
        public void SetCurrentSong(ISampleProvider song) { currentSong = song; }
        public void ReleaseCurrentSong() { currentSong = null; }
        public Dictionary<string, float> Notes = new Dictionary<string, float>()
        {
        //Anything below 2 should be used for bass only
         {"C0",16.35f},   {"C1", 32.7f},   {"C2", 65.41f},   {"C3" , 130.81f},  {"C4" , 261.63f}, {"C5" , 523.25f},
         {"C0S", 17.32f}, {"C1S", 34.65f}, {"C2S", 69.30f},  {"C3S",  138.59f}, {"C4S", 277.18f}, {"C5S",  554.37f},
         {"D0", 18.35f},  {"D1", 36.71f},  {"D2", 73.42f},   {"D3", 146.83f},   {"D4", 293.67f},  {"D5", 587.33f},
         {"D0S", 19.45f}, {"D1S", 38.89f}, {"D2S", 77.78f},  {"D3S",  155.56f}, {"D4S", 311.13f}, {"D5S",  622.25f},
         {"E0", 20.60f},  {"E1", 41.20f},  {"E2", 82.41f},   {"E3", 164.81f},   {"E4", 329.63f},  {"E5", 659.26f},
         {"F0", 21.83f},  {"F1", 43.65f},  {"F2", 87.31f},   {"F3", 174.61f},   {"F4", 349.23f},  {"F5", 698.46f},
         {"F0S", 23.12f}, {"F1S", 46.25f}, {"F2S", 92.50f},  {"F3S",  185.00f}, {"F4S", 369.99f}, {"F5S",  739.99f},
         {"G0", 24.50f},  {"G1", 49.00f},  {"G2", 98.00f},   {"G3", 196.00f},   {"G4", 392.00f},  {"G5", 783.99f},
         {"G0S", 25.96f}, {"G1S", 51.91f}, {"G2S", 103.83f}, {"G3S",  207.65f}, {"G4S", 415.31f}, {"G5S",  830.61f},
         {"A0", 27.50f},  {"A1", 55.00f},  {"A2", 110.0f},   {"A3", 220.00f},   {"A4", 440.00f},  {"A5", 880.00f},
         {"A0S", 29.14f}, {"A1S", 58.27f}, {"A2S", 116.54f}, {"A3S",  233.08f}, {"A4S", 466.16f}, {"A5S",  923.33f},
         {"B0", 30.87f},  {"B1", 61.74f},  {"B2", 123.47f},  {"B3", 246.94f},   {"B4", 493.88f},  {"B5", 987.77f },
        };

        bool[ , ] buttonsPressedSin = new bool[availableNoteTypes * availableOctaves,availableNoteButtons * availablePages];

        bool[,] buttonsPressedSaw = new bool[availableNoteTypes * availableOctaves, availableNoteButtons * availablePages];

        public void UpdateButtonsPressed(int row, int column, bool changeTo, string type)
        {
            if(type == "Sin") buttonsPressedSin[row,column] = changeTo;
            else if (type == "Saw") buttonsPressedSaw[row,column] = changeTo;
        }
        public void SwitchButtonsPressed(int row, int column, string type)
        {
            if (type == "Sin") buttonsPressedSin[row,column] = !buttonsPressedSin[row,column];
            else if (type =="Saw") buttonsPressedSaw[row,column] = !buttonsPressedSaw[row, column];
        }

        public bool QueryButtonsPressed(int row, int column, string type)
        {
            if (type == "Sin") return buttonsPressedSin[row,column];
            else if (type == "Saw") return buttonsPressedSaw[row,column];
            return false;
        }


        public ISampleProvider GenNote(float gain, float frequency, float time, SignalGeneratorType type)
        {
            ISampleProvider note = new SignalGenerator(44100, 1)
            {
                Gain = gain,
                Frequency = frequency,
                Type = type
            }.Take(TimeSpan.FromSeconds(time));

            return new AdsrSampleProvider(note)
            {
                AttackSeconds = 0.3f,
                ReleaseSeconds = 0.3f
            };
        }

        public ISampleProvider GenNote(NoteDetails noteDetails)
        {
            ISampleProvider note = new SignalGenerator(44100, 1)
            {
                Gain = noteDetails.gain,
                Frequency = noteDetails.frequency,
                Type = noteDetails.generatorType
            }.Take(TimeSpan.FromSeconds(noteDetails.time));

            return new AdsrSampleProvider(note)
            {
                AttackSeconds = 0.3f,
                ReleaseSeconds = 0.3f
            };
        }

        public ISampleProvider GenSilence(float time)
        {
            return new SilenceProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1)).ToSampleProvider().Take(TimeSpan.FromSeconds(time));
        }

        public ISampleProvider CreateMetronome(int length, float gain, float frequency, float time)
        {
            ISampleProvider[] metronomeConcat = new ISampleProvider[length * 2];
            //ISampleProvider myNote = GenD3();            
            for (int i = 0; i < length; i++)
            {
                metronomeConcat[i * 2] = GenNote(gain, frequency, time, SignalGeneratorType.Sin);
                //OffsetSampleProvider
                metronomeConcat[(i * 2) + 1] = /*GenNote(gain,frequency,time)*/ GenSilence(time);
            }

            ISampleProvider metronome = new ConcatenatingSampleProvider(metronomeConcat);
            return metronome;
        }

        public ISampleProvider CombineNotes(NoteDetails[] notes)
        {
            MixingSampleProvider combiner = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
            foreach (NoteDetails note in notes)
            {
                combiner.AddMixerInput(GenNote(note));
            }
            return combiner;
        }

        public ISampleProvider CombineNotes(List<NoteDetails> notes)
        {
            MixingSampleProvider combiner = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
            foreach (NoteDetails note in notes)
            {
                combiner.AddMixerInput(GenNote(note));
            }
            return combiner;
        }
    }
}
