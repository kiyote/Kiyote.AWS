using Kiyote.AWS.Credentials;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Kiyote.AWS.SecretsManager;

public static class ExtensionMethods {

	public static IServiceCollection AddSecretsManager<T>(
		this IServiceCollection services,
		Action<SecretsManagerOptions<T>>? configureOptions = null
	) where T: class {
		// Ensure at least the basic credentials provider is available
		services.TryAddSingleton<ICredentialsProvider, CredentialsProvider>();
		services.TryAddSingleton<CredentialsProviderOptions>();

		// Register the SecretsManagerContext
		_ = services
			.AddSingleton<SecretsManagerContext<T>>()
			.AddSingleton<SecretsManagerOptionsValidator<T>>()
			.AddOptions<SecretsManagerOptions<T>>()
			.Configure( ( opts ) => {
				configureOptions?.Invoke( opts );
			} )
			.ValidateOnStart();

		return services;
	}
}
