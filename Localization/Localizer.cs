using System;
using System.Globalization;
using System.Resources;

namespace TshirtFormMockup.Localization
{
    public static class Localizer
    {
        private static ResourceManager _resourceManager = new ResourceManager("TshirtFormMockup.Resources.Strings", typeof(Localizer).Assembly);
        public static string GetString(string key)
        {
            var culture = CultureInfo.CurrentUICulture;
            Console.WriteLine($"Localizer: CurrentUICulture = {culture.Name}");
            var value = _resourceManager.GetString(key, culture);
            Console.WriteLine($"Localizer: Key = {key}, Value = {value}");
            return value ?? key;
        }
        public static void SetCulture(string cultureName)
        {
            CultureInfo.CurrentUICulture = new CultureInfo(cultureName);
        }
    }
}
