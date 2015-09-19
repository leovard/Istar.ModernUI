using System;
using System.Windows;

namespace IstarWindows.Shared
{
	/// <summary>
	/// Логика взаимодействия для TwittsLoader.xaml
	/// </summary>
	public partial class TwittsLoader
	{

		public TwittsLoader()
		{
			InitializeComponent();
			Loaded += TwittsLoaded;
			Unloaded += TwittsUnloaded;

		}

		private void TwittsLoaded(object sender, RoutedEventArgs e)
		{
			TwittsBrowser.Source = new Uri("http://twitter.com");
			Application.Current.MainWindow.Width = 1015;
		}

		private static void TwittsUnloaded(object sender, RoutedEventArgs e)
		{
			Application.Current.MainWindow.Width = 960;
		}

	}
}
