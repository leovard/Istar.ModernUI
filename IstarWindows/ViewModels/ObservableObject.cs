using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IstarWindows.ViewModels
{
    /// <summary>
    /// ObservableObject Class.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName()] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
