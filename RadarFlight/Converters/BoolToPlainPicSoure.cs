using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace RadarFlight.Converters
{
    public class BoolToPlainPicSoure : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            BitmapImage source = new BitmapImage();
            if (value is bool isDeparture)
            {
                if (isDeparture)
                {
                    source.UriSource = new Uri("ms-appx:///Assets/DeparturePlain.png");
                }
                else
                {
                    source.UriSource = new Uri("ms-appx:///Assets/ArivePlain.png");
                }
            }
            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
