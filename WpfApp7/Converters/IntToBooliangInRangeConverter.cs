using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp7.Converters
{
    class IntToBooliangInReangeConverter : IValueConverter
    {
        public int Max {  get; set; } = int.MaxValue;
        public int Min {  get; set; } = int.MinValue;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int rating)
                return rating >= Min && rating <= Max;
            return false;
        }
        // Не делаем
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
