using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Data;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Media.Imaging;

namespace WpfEventViewer.Converters
{
    public class EventTypeToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte number = 0;
            if (!byte.TryParse(value?.ToString(), out number))
                return this.IconToImage(SystemIcons.Information);

            // ちょっと冗長か？
            var dic = new Dictionary<byte, Icon>()
            {
                { 1, SystemIcons.Error },
                { 2, SystemIcons.Warning },
                { 3, SystemIcons.Information },
            };

            if (dic.ContainsKey(number))
                return this.IconToImage(dic[number]);
            else
                return this.IconToImage(SystemIcons.Information);
            
        }

        private BitmapImage IconToImage(Icon icon)
        {
            var stream = new MemoryStream();
            icon.Save(stream);

            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = stream;
            bmp.EndInit();
            return bmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
