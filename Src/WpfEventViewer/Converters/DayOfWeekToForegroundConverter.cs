using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;
using WpfEventViewer.Models;

namespace WpfEventViewer.Converters
{
    // DateTime 型を元に、文字色を返却するコンバーター
    // 日曜日・・・赤
    // 土曜日・・・青
    // 平日・・・黒
    // 先月または翌月・・・グレー
    // 例外・・・黒
    public class DayOfWeekToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value != null && value is DateObject))
                return Brushes.Black;

            var dt = (DateObject)value;
            if (!dt.ThisMonthMember) return Brushes.Gray;
            if (dt.Date.DayOfWeek == DayOfWeek.Sunday) return Brushes.Red;
            if (dt.Date.DayOfWeek == DayOfWeek.Saturday) return Brushes.Blue;
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
