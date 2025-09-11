using System;
using System.Collections.Generic;

namespace BTCPayTranslator.Models;

public record TranslationRequest(
    string Key,
    string SourceText,
    string TargetLanguage,
    string? Context = null
);

public record TranslationResponse(
    string Key,
    string TranslatedText,
    bool Success,
    string? Error = null
);

public record BatchTranslationRequest(
    List<TranslationRequest> Items,
    string TargetLanguage,
    string TargetLanguageNative
);

public record BatchTranslationResponse(
    List<TranslationResponse> Results,
    int SuccessCount,
    int FailureCount,
    TimeSpan Duration
);

public class TranslationFile
{
    public string Code { get; set; } = string.Empty;
    public string CurrentLanguage { get; set; } = string.Empty;
    public Dictionary<string, string> Translations { get; set; } = new();
}

public class CheckoutTranslationFile
{
    public string NoticeWarn { get; set; } = "THIS CODE HAS BEEN AUTOMATICALLY GENERATED FROM TRANSIFEX, IF YOU WISH TO HELP TRANSLATION COME ON THE SLACK https://chat.btcpayserver.org/ TO REQUEST PERMISSION TO https://www.transifex.com/btcpayserver/btcpayserver/";
    public string Code { get; set; } = string.Empty;
    public string CurrentLanguage { get; set; } = string.Empty;
    public Dictionary<string, string> Translations { get; set; } = new();
}
