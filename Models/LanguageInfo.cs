using System.Collections.Generic;
using System.Linq;

namespace BTCPayTranslator.Models;

public record LanguageInfo(
    string Code,
    string Name,
    string NativeName,
    bool IsRightToLeft = false
);

public static class SupportedLanguages
{
    public static readonly Dictionary<string, LanguageInfo> Languages = new()
    {
        ["hi"] = new("hi", "Hindi", "हिंदी"),
        ["es"] = new("es-ES", "Spanish", "Español"),
        ["fr"] = new("fr-FR", "French", "Français"),
        ["de"] = new("de-DE", "German", "Deutsch"),
        ["it"] = new("it-IT", "Italian", "Italiano"),
        ["pt"] = new("pt-BR", "Portuguese (Brazil)", "Português (Brasil)"),
        ["ru"] = new("ru-RU", "Russian", "Русский"),
        ["ja"] = new("ja-JP", "Japanese", "日本語"),
        ["ko"] = new("ko", "Korean", "한국어"),
        ["zh-cn"] = new("zh-SG", "Chinese (Simplified)", "简体中文"),
        ["zh-tw"] = new("zh-TW", "Chinese (Traditional)", "繁體中文"),
        ["ar"] = new("ar", "Arabic", "العربية", true),
        ["he"] = new("he", "Hebrew", "עברית", true),
        ["fa"] = new("fa", "Persian", "فارسی", true),
        ["tr"] = new("tr", "Turkish", "Türkçe"),
        ["nl"] = new("nl-NL", "Dutch", "Nederlands"),
        ["sv"] = new("sv", "Swedish", "Svenska"),
        ["no"] = new("no", "Norwegian", "Norsk"),
        ["da"] = new("da-DK", "Danish", "Dansk"),
        ["fi"] = new("fi-FI", "Finnish", "Suomi"),
        ["pl"] = new("pl", "Polish", "Polski"),
        ["cs"] = new("cs-CZ", "Czech", "Čeština"),
        ["sk"] = new("sk-SK", "Slovak", "Slovenčina"),
        ["hu"] = new("hu-HU", "Hungarian", "Magyar"),
        ["ro"] = new("ro", "Romanian", "Română"),
        ["bg"] = new("bg-BG", "Bulgarian", "Български"),
        ["hr"] = new("hr-HR", "Croatian", "Hrvatski"),
        ["sr"] = new("sr", "Serbian", "Српски"),
        ["sl"] = new("sl-SI", "Slovenian", "Slovenščina"),
        ["et"] = new("et", "Estonian", "Eesti"),
        ["lv"] = new("lv", "Latvian", "Latviešu"),
        ["lt"] = new("lt", "Lithuanian", "Lietuvių"),
        ["uk"] = new("uk-UA", "Ukrainian", "Українська"),
        ["be"] = new("be", "Belarusian", "Беларуская"),
        ["el"] = new("el-GR", "Greek", "Ελληνικά"),
        ["th"] = new("th-TH", "Thai", "ไทย"),
        ["vi"] = new("vi-VN", "Vietnamese", "Tiếng Việt"),
        ["id"] = new("id", "Indonesian", "Bahasa Indonesia"),
        ["ms"] = new("ms", "Malay", "Bahasa Melayu"),
        ["tl"] = new("tl", "Filipino", "Filipino"),
        ["bn"] = new("bn", "Bengali", "বাংলা"),
        ["ta"] = new("ta", "Tamil", "தமிழ்"),
        ["te"] = new("te", "Telugu", "తెలుగు"),
        ["ml"] = new("ml", "Malayalam", "മലയാളം"),
        ["kn"] = new("kn", "Kannada", "ಕನ್ನಡ"),
        ["gu"] = new("gu", "Gujarati", "ગુજરાતી"),
        ["mr"] = new("mr", "Marathi", "मराठी"),
        ["pa"] = new("pa", "Punjabi", "ਪੰਜਾਬੀ"),
        ["or"] = new("or", "Odia", "ଓଡ଼ିଆ"),
        ["as"] = new("as", "Assamese", "অসমীয়া"),
        ["ur"] = new("ur", "Urdu", "اردو", true),
        ["ne"] = new("np-NP", "Nepali", "नेपाली"),
        ["si"] = new("si", "Sinhala", "සිංහල"),
        ["my"] = new("my", "Myanmar", "မြန်မာ"),
        ["km"] = new("km", "Khmer", "ខ្មែរ"),
        ["lo"] = new("lo", "Lao", "ລາວ"),
        ["ka"] = new("ka", "Georgian", "ქართული"),
        ["hy"] = new("hy", "Armenian", "Հայերեն"),
        ["az"] = new("az", "Azerbaijani", "Azərbaycan"),
        ["kk"] = new("kk-KZ", "Kazakh", "Қазақша"),
        ["ky"] = new("ky", "Kyrgyz", "Кыргызча"),
        ["uz"] = new("uz", "Uzbek", "O'zbek"),
        ["tg"] = new("tg", "Tajik", "Тоҷикӣ"),
        ["mn"] = new("mn", "Mongolian", "Монгол"),
        ["am"] = new("am-ET", "Amharic", "አማርኛ"),
        ["sw"] = new("sw", "Swahili", "Kiswahili"),
        ["zu"] = new("zu", "Zulu", "isiZulu"),
        ["af"] = new("af", "Afrikaans", "Afrikaans"),
        ["is"] = new("is-IS", "Icelandic", "Íslenska"),
        ["fo"] = new("fo", "Faroese", "Føroyskt"),
        ["mt"] = new("mt", "Maltese", "Malti"),
        ["cy"] = new("cy", "Welsh", "Cymraeg"),
        ["ga"] = new("ga", "Irish", "Gaeilge"),
        ["gd"] = new("gd", "Scottish Gaelic", "Gàidhlig"),
        ["eu"] = new("eu", "Basque", "Euskera"),
        ["ca"] = new("ca-ES", "Catalan", "Català"),
        ["gl"] = new("gl", "Galician", "Galego"),
        ["ast"] = new("ast", "Asturian", "Asturianu"),
        ["br"] = new("br", "Breton", "Brezhoneg"),
        ["co"] = new("co", "Corsican", "Corsu"),
        ["sc"] = new("sc", "Sardinian", "Sardu"),
        ["lb"] = new("lb", "Luxembourgish", "Lëtzebuergesch"),
        ["rm"] = new("rm", "Romansh", "Rumantsch"),
        ["fur"] = new("fur", "Friulian", "Furlan"),
        ["vec"] = new("vec", "Venetian", "Vèneto"),
        ["nap"] = new("nap", "Neapolitan", "Napulitano"),
        ["scn"] = new("scn", "Sicilian", "Sicilianu"),
        ["lmo"] = new("lmo", "Lombard", "Lumbaart"),
        ["pms"] = new("pms", "Piedmontese", "Piemontèis"),
        ["lij"] = new("lij", "Ligurian", "Ligure"),
        ["eml"] = new("eml", "Emilian-Romagnol", "Emiliàn"),
        ["bs"] = new("bs-BA", "Bosnian", "Bosanski"),
        ["mk"] = new("mk", "Macedonian", "Македонски"),
        ["sq"] = new("sq", "Albanian", "Shqip"),
        ["cnr"] = new("cnr", "Montenegrin", "Crnogorski")
    };

    public static LanguageInfo? GetLanguageInfo(string code)
    {
        return Languages.TryGetValue(code, out var info) ? info : null;
    }

    public static IEnumerable<LanguageInfo> GetAllLanguages()
    {
        return Languages.Values;
    }
}
