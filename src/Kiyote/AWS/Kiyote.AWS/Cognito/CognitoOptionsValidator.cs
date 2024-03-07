using Microsoft.Extensions.Options;

namespace Kiyote.AWS.Cognito;

internal sealed class CognitoOptionsValidator<T> : IValidateOptions<CognitoOptions<T>> {
	ValidateOptionsResult IValidateOptions<CognitoOptions<T>>.Validate(
		string? name,
		CognitoOptions<T> options
	) {
		if (string.IsNullOrWhiteSpace( options.ClientId)) {
			return ValidateOptionsResult.Fail( $"{nameof( CognitoOptions<T>.ClientId )} must not be empty." );
		}

		return ValidateOptionsResult.Success;
	}
}
