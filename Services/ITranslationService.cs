using System.Threading.Tasks;
using BTCPayTranslator.Models;

namespace BTCPayTranslator.Services;

public interface ITranslationService
{
    Task<TranslationResponse> TranslateAsync(TranslationRequest request);
    Task<BatchTranslationResponse> TranslateBatchAsync(BatchTranslationRequest request);
    string ProviderName { get; }
}
