using Microsoft.Extensions.DependencyInjection;

namespace Kiyote.AWS.Credentials;

public static class ExtensionMethods {

	public static IServiceCollection AddDefaultCredentials(
		this IServiceCollection services,
		Action<CredentialsProviderOptions>? configureOptions = null
	) {
		services
			.AddSingleton<ICredentialsProvider, CredentialsProvider>()
			.AddOptions<CredentialsProviderOptions>()
			.Configure( ( opts ) => {
				if( configureOptions is not null ) {
					configureOptions( opts );
				}
			} );

		return services;
	}
}
