using InjectableAWS.Credentials;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InjectableAWS.DynamoDb;

public static class ExtensionMethods {

	public static IServiceCollection AddDynamoDb<T>(
		this IServiceCollection services,
		Action<DynamoDbOptions<T>>? configureOptions = null
	) where T: class {
		// Ensure at least the basic credentials provider is available
		services.TryAddSingleton<ICredentialsProvider, CredentialsProvider>();
		services.TryAddSingleton<CredentialsProviderOptions>();

		// Register the DynamoDbContext
		services
			.AddSingleton<DynamoDbContext<T>>()
			.AddOptions<DynamoDbOptions<T>>()
			.Configure( ( opts ) => {
				if( configureOptions is not null ) {
					configureOptions( opts );
				}
			} );
		return services;
	}
}
