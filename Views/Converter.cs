using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyCSV.Views
{
    public class BitmapAssetValueConverter : IValueConverter
    {
        public static BitmapAssetValueConverter Instance = new BitmapAssetValueConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Bitmap(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
