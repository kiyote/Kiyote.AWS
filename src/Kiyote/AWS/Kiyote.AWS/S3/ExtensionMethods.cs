using Kiyote.AWS.Credentials;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Kiyote.AWS.S3;

public static class ExtensionMethods {

	public static IServiceCollection AddS3<T>(
		this IServiceCollection services,
		Action<S3Options<T>>? configureOptions = null
	) where T: class {
		// Ensure at least the basic credentials provider is available
		services.TryAddSingleton<ICredentialsProvider, CredentialsProvider>();
		services.TryAddSingleton<CredentialsProviderOptions>();

		// Register the S3Context
		services
			.AddSingleton<S3Context<T>>()
			.AddOptions<S3Options<T>>()
			.Configure( ( opts ) => {
				if( configureOptions is not null ) {
					configureOptions( opts );
				}
			} );
		return services;
	}
}
