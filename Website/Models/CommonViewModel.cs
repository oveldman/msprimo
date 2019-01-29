using System.Globalization;

namespace Website.Models
{
    public class CommonViewModel
    {
        public CommonViewModel()
        {
            CultureInfo dutchCulture = new CultureInfo("nl-NL");
            CultureFormat = dutchCulture.DateTimeFormat;
        }
        
        public string Warning { get; set; }
        public DateTimeFormatInfo CultureFormat { get; set; }
    }
}