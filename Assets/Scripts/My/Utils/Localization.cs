using System.Collections.Generic;

namespace My.Utils
{
    public static class Localization
    {
        public static string CURRENT_LANGUAGE = "en";
        public static string[] LANGUAGES = { "en", "ru" };

        public static Dictionary<string, Dictionary<string, string>> TABLE = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "en", new Dictionary<string, string>
                {
                    { "loading", "Loading..." },
                    { "language", "English" },
                }
            },
            {
                "ru", new Dictionary<string, string>
                {
                    { "loading", "Загрузка..." },
                    { "language", "Русский" },
                }
            }
        };
    }
}