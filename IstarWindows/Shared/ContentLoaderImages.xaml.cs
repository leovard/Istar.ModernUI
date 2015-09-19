using System;
using System.Linq;
using System.Windows;
using Istar.ModernUI.Windows.Controls;
using IstarWindows.Code;

namespace IstarWindows.Shared
{
    /// <summary>
    /// Логика взаимодействия для ContentLoaderImages.xaml
    /// </summary>
    public partial class ContentLoaderImages
    {
        public ContentLoaderImages()
        {
            InitializeComponent();

            LoadImageLinks();
        }

        private async void LoadImageLinks()
        {
            var loader = (FlickrImageLoader)Tab.ContentLoader;

            try
            {
                // load image links and assign to tab list
                Tab.Links = await loader.GetInterestingnessListAsync();

                // select first link
                Tab.SelectedSource = Tab.Links.Select(l => l.Source).FirstOrDefault();
            }
            catch (Exception e)
            {
                ModernDialog.ShowMessage(e.Message, "Failure", MessageBoxButton.OK);
            }
        }
    }
}
