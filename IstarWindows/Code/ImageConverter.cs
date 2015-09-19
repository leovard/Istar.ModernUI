using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace IstarWindows.Code
{	public class ImageConverter: IValueConverter
	{
		object IValueConverter.Convert(object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			if (!(value is byte[])) return null;
			var bytes = (byte[]) value;

			var stream = new MemoryStream(bytes);

			var image = new BitmapImage();
			image.BeginInit();
			image.StreamSource = stream;
			image.EndInit();

			return image;
		}

		object IValueConverter.ConvertBack(object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			return null;
		}

	}
}
