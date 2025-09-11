using System.Threading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using System.Text.Json;
using BTCPayTranslator.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BTCPayTranslator.Services;

public class FileWriter
{
    private readonly ILogger<FileWriter> _logger;
    private readonly JsonSerializerSettings _jsonSettings;

    public FileWriter(ILogger<FileWriter> logger)
    {
        _logger = logger;
        _jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
        };
    }

    public async Task WriteCheckoutTranslationFileAsync(
        string outputPath,
        LanguageInfo languageInfo,
        Dictionary<string, string> translations)
    {
        try
        {
            // Create the translation file structure
            var translationFile = new JObject
            {
                ["NOTICE_WARN"] = "THIS CODE HAS BEEN AUTOMATICALLY GENERATED FROM TRANSIFEX, IF YOU WISH TO HELP TRANSLATION COME ON THE SLACK https://chat.btcpayserver.org/ TO REQUEST PERMISSION TO https://www.transifex.com/btcpayserver/btcpayserver/",
                ["code"] = languageInfo.Code,
                ["currentLanguage"] = languageInfo.NativeName
            };

            // Add all translations
            foreach (var translation in translations.OrderBy(t => t.Key))
            {
                translationFile[translation.Key] = translation.Value;
            }

            // Ensure output directory exists
            var directory = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                _logger.LogInformation("Created directory: {Directory}", directory);
            }

            // Write the file
            var json = translationFile.ToString(Formatting.Indented);
            await File.WriteAllTextAsync(outputPath, json);

            _logger.LogInformation("Successfully wrote {Count} translations to {OutputPath}", 
                translations.Count, outputPath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error writing translation file to {OutputPath}", outputPath);
            throw;
        }
    }

    public async Task WriteBackendTranslationFileAsync(
        string outputPath,
        LanguageInfo languageInfo,
        Dictionary<string, string> translations)
    {
        try
        {
            // Create the backend translation file structure (simple JSON)
            var translationFile = new JObject();

            // Add all translations
            foreach (var translation in translations.OrderBy(t => t.Key))
            {
                translationFile[translation.Key] = translation.Value;
            }

            // Ensure output directory exists
            var directory = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                _logger.LogInformation("Created directory: {Directory}", directory);
            }

            // Write the file
            var json = translationFile.ToString(Formatting.Indented);
            await File.WriteAllTextAsync(outputPath, json);

            _logger.LogInformation("Successfully wrote {Count} backend translations to {OutputPath}", 
                translations.Count, outputPath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error writing backend translation file to {OutputPath}", outputPath);
            throw;
        }
    }

    public async Task<Dictionary<string, string>> LoadExistingBackendTranslationsAsync(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                return new Dictionary<string, string>();
            }

            var content = await File.ReadAllTextAsync(filePath);
            var jsonObject = JObject.Parse(content);
            var translations = new Dictionary<string, string>();

            foreach (var property in jsonObject.Properties())
            {
                var value = property.Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(value))
                {
                    translations[property.Name] = value;
                }
            }

            _logger.LogInformation("Loaded {Count} existing translations from {FilePath}", 
                translations.Count, filePath);
            return translations;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading existing translations from {FilePath}", filePath);
            return new Dictionary<string, string>();
        }
    }

    public async Task WriteSummaryReportAsync(
        string outputPath,
        string language,
        BatchTranslationResponse response,
        Dictionary<string, string> finalTranslations)
    {
        try
        {
            var report = new
            {
                Language = language,
                Timestamp = DateTime.UtcNow,
                Translation = new
                {
                    TotalItems = response.Results.Count,
                    SuccessfulTranslations = response.SuccessCount,
                    FailedTranslations = response.FailureCount,
                    Duration = response.Duration.ToString(@"hh\:mm\:ss"),
                    SuccessRate = $"{(double)response.SuccessCount / response.Results.Count * 100:F1}%"
                },
                Output = new
                {
                    FinalTranslationCount = finalTranslations.Count,
                    OutputFile = outputPath
                },
                Failures = response.Results
                    .Where(r => !r.Success)
                    .Select(r => new { r.Key, r.Error })
                    .ToArray()
            };

            var reportPath = Path.ChangeExtension(outputPath, ".report.json");
            var json = JsonConvert.SerializeObject(report, _jsonSettings);
            await File.WriteAllTextAsync(reportPath, json);

            _logger.LogInformation("Translation summary report written to {ReportPath}", reportPath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error writing summary report");
        }
    }
}
