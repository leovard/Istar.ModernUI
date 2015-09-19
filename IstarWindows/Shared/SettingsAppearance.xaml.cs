using IstarWindows.Code;
using IstarWindows.ViewModels;

namespace IstarWindows.Shared
{
    /// <summary>
    /// Логика взаимодействия для SettingsAppearance.xaml
    /// </summary>
    public partial class SettingsAppearance
    {
        public SettingsAppearance()
        {
            InitializeComponent();

            // a simple view model for appearance configuration
            DataContext = new SettingsAppearanceViewModel();
            SpeechConverter.GetJobVoice("Настройки.");
        }
    }
}
