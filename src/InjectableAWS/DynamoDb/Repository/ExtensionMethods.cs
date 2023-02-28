using Microsoft.Extensions.DependencyInjection;

namespace InjectableAWS.DynamoDb.Repository;

public static class ExtensionMethods {

	public static IServiceCollection AddDynamoDbRepository<T>(
		this IServiceCollection services,
		Action<DynamoDbRepositoryOptions<T>>? configureOptions
	) where T: class {
		services
			.AddOptions<DynamoDbRepositoryOptions<T>>()
			.Configure( ( opts ) => {
				if( configureOptions is not null ) {
					configureOptions( opts );
				}
			} );

		return services;
	}
}
