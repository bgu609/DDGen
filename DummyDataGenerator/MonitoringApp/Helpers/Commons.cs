using System.Globalization;
using System.Windows.Controls;

namespace MonitoringApp.Helpers
{
    public class Commons
    {
        public static string BROKER_HOST { get; set; }
        public static string PUBLISH_TOPIC { get; set; }
        public static string BROKER_CLIENT { get; set; }
        public static string CONNECT_STRING { get; set; }
        public static bool IS_CONNECTED { get; set; }

        public static readonly string CONSTR = "Data Source=localhost; Port=3306; database=bookrentalshop; Uid=root; Password=epfls+358471;";
    }

    public class NOT_Empty_Validation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {


            return ValidationResult.ValidResult;
        }
    }
}
