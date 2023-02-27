using InjectableAWS.Credentials;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InjectableAWS.Cognito;

public static class ExtensionMethods {

	public static IServiceCollection AddCognito<T>(
		this IServiceCollection services,
		Action<CognitoOptions<T>>? configureOptions = null
	) {
		// Ensure at least the basic credentials provider is available
		services.TryAddSingleton<ICredentialsProvider, CredentialsProvider>();
		services.TryAddSingleton<CredentialsProviderOptions>();

		// Register the CognitoContext
		services
			.AddSingleton<CognitoContext<CognitoOptions<T>>>()
			.AddSingleton<CognitoOptionsValidator<T>>()
			.AddOptions<CognitoOptions<T>>()
			.Configure( ( opts ) => {
				if( configureOptions is not null ) {
					configureOptions( opts );
				}
			} )
			.ValidateOnStart();

		return services;
	}
}
