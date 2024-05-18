using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace NAudioSynth.ViewModel
{
    
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }
    }
}
