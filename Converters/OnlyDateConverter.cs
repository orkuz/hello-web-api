using Newtonsoft.Json.Converters;

namespace hello_web_api.Converters
{
    public class OnlyDateConverter : IsoDateTimeConverter
    {
        public OnlyDateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
