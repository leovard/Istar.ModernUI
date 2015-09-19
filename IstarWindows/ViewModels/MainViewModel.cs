using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Istar.ModernUI.Presentation;
using Istar.ModernUI.Windows.Controls;
using IstarWindows.Code;
using IstarWindows.Models;

namespace IstarWindows.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private static IstarLogic _context;
        public static Window MainWin;
        public static ModernDialog AboutWin;
        public Link SettingsLink { get; set; }
        public static Link AboutLink { get; set; }
        public static Link SchemaLink { get; set; }
        public static Link ScriptLink { get; set; }
        public static Link SoundLink { get; set; }
        public static Link ExitLink { get; set; }
        public LinkCollection TitleLinks { get; set; }

        public static bool CanExecuteSchema => _context.GetJobs().Count == 1 && _context.GetJobs().First().Jobtext.StartsWith("Перед");
        public static bool CanExecuteScript => _context.GetCompanies().Count == 0;

        public static ICommand AboutCommand => new ActionCommand(GetAbout);

        private static void GetAbout(object obj)
        {
            AboutWin = new AboutWindow();
            SpeechConverter.GetJobVoice("О программе.");
            AboutWin.ShowDialog();
        }

        public static ICommand GoSchemaCommand => new ActionCommand(c => GoSchema(), c => CanExecuteSchema);

        private static void GoSchema()
        {
            var script = Properties.Resources.Schema;
            script = script.Replace("GO", "");
            var conn = new SqlConnection("Server = (local); Database = IstarRealEstate; Integrated Security = true");
            var command = new SqlCommand(script, conn);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            SpeechConverter.GetJobVoice("База  данных  обновлена.");
            var dialogResult = ModernDialog.ShowMessage("База  данных  обновлена." + Environment.NewLine + "Перезапуск приложения.", "Внимание!", MessageBoxButton.OK);
            if (dialogResult != MessageBoxResult.OK) return;
            System.Windows.Forms.Application.Restart();
            Process.GetCurrentProcess().Kill();
        }

        public static ICommand GoScriptCommand => new ActionCommand(c => GoScript(), c => CanExecuteScript);

        private static void GoScript()
        {
            var script = Properties.Resources.Script;
            script = script.Replace("GO", "");
            var conn = new SqlConnection("Server = (local); Database = IstarRealEstate; Integrated Security = true");
            var command = new SqlCommand(script, conn);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            SpeechConverter.GetJobVoice("База  данных  обновлена.");
            var dialogResult = ModernDialog.ShowMessage("База  данных  обновлена." + Environment.NewLine + "Перезапуск приложения.", "Внимание!", MessageBoxButton.OK);
            if (dialogResult != MessageBoxResult.OK) return;
            System.Windows.Forms.Application.Restart();
            Process.GetCurrentProcess().Kill();
        }

        public static ICommand GoSoundCommand => new ActionCommand(c => GoSound());

        private static void GoSound()
        {
            if (SoundLink.DisplayName == "Выключить звук")
            {
                SpeechConverter.GetJobVoice("Звук выключен");
                SoundLink.DisplayName = "Включить звук";
            }
            else
            {
                SoundLink.DisplayName = "Выключить звук";
                SpeechConverter.GetJobVoice("Звук включен");
            }
        }

        public static ICommand GoExitCommand => new ActionCommand(c => GoExit());

        private static void GoExit()
        {
            SpeechConverter.GetJobVoice("Сохранить результаты работы?");
            var dialogResult = ModernDialog.ShowMessage("Сохранить результаты работы?", "Внимание!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                const string connectionString = "Server = (local); Database = IstarRealEstate; Integrated Security = true";
                const string backupFolder = "D:\\OneDrive\\Документы\\Programs\\DataBases\\";
                var backupFileName =
                    $"{backupFolder}{new SqlConnectionStringBuilder(connectionString).InitialCatalog}-{DateTime.Today.ToString("dd.MM.yyyy")}.bak";
                if (File.Exists(backupFileName))
                {
                    File.Delete(backupFileName);
                }
                using (var connection = new SqlConnection(new SqlConnectionStringBuilder(connectionString).ConnectionString))
                {
                    var query =
                        $"BACKUP DATABASE {new SqlConnectionStringBuilder(connectionString).InitialCatalog} TO DISK='{backupFileName}' WITH {"INIT"}";
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                SpeechConverter.GetJobVoice("Результаты работы сохранены.");
                ModernDialog.ShowMessage("Результаты работы сохранены.", "Внимание!", MessageBoxButton.OK);
            }
            else
            {
                SpeechConverter.GetJobVoice("Выход из программы без сохранения.");
                ModernDialog.ShowMessage("Выход из программы без сохранения.", "Внимание!", MessageBoxButton.OK);
            }
            Process.GetCurrentProcess().Kill();
        }

        public MainViewModel(IstarLogic context)
        {
            _context = context;
            if (_context.GetJobs().Count == 0)
            {
                _context.AddNewJob(new Job { Jobdate = DateTime.Today, Jobtitle = "ВНИМАНИЕ! Необходимо обновить базу данных.", Jobtext = "Перед началом работы с программой требуется выполнить скрипт для обновления базы данных.", Ismonthly = true, Iscomplete = false });
            }
            TitleLinks = new LinkCollection();
            SettingsLink = new Link { DisplayName = "Настройки", Source = new Uri("/Shared/Settings.xaml", UriKind.Relative) };
            AboutLink = new Link { DisplayName = "О программе", Source = new Uri("cmd://AboutThis", UriKind.Absolute) };
            SchemaLink = new Link { DisplayName = "Подготовить базу", Source = new Uri("cmd://GoSchema", UriKind.Absolute) };
            ScriptLink = new Link { DisplayName = "Заполнить базу", Source = new Uri("cmd://GoScript", UriKind.Absolute) };
            SoundLink = new Link { DisplayName = "Выключить звук", Source = new Uri("cmd://GoSound", UriKind.Absolute) };
            ExitLink = new Link { DisplayName = "Выход", Source = new Uri("cmd://GoExit", UriKind.Absolute) };
            TitleLinks.Add(SettingsLink);
            TitleLinks.Add(AboutLink);
            if (CanExecuteSchema)
            {
                TitleLinks.Add(SchemaLink);
            }
            else
            {
                if (CanExecuteScript)
                {
                    TitleLinks.Add(ScriptLink);
                }
            }
            TitleLinks.Add(SoundLink);
            TitleLinks.Add(ExitLink);
            MainWin = Application.Current.MainWindow;
            MainWin.Closing += (sender, cancelEventArgs) => GoExit();
        }
    }
}