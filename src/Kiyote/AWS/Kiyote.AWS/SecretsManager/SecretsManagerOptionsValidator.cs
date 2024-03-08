using Microsoft.Extensions.Options;

namespace Kiyote.AWS.SecretsManager;

internal sealed class SecretsManagerOptionsValidator<T> : IValidateOptions<SecretsManagerOptions<T>> where T : class {
	ValidateOptionsResult IValidateOptions<SecretsManagerOptions<T>>.Validate(
		string? name,
		SecretsManagerOptions<T> options
	) {
		return ValidateOptionsResult.Success;
	}
}
