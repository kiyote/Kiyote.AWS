using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InjectableAWS {
	public static class ExtensionMethods {

		public static IServiceCollection AddCredentials(
			this IServiceCollection services
		) {
			services.TryAddSingleton( new CredentialsOptions() );
			services.TryAddSingleton<ICredentialsProvider, CredentialsProvider>();

			return services;
		}

		public static IServiceCollection AddCredentials(
			this IServiceCollection services,
			CredentialsOptions configuration
		) {
			services.TryAddSingleton( configuration );
			services.TryAddSingleton<ICredentialsProvider, CredentialsProvider>();

			return services;
		}

		public static IServiceCollection AddCredentials(
			this IServiceCollection services,
			IConfigurationSection configuration
		) {
			services.Configure<CredentialsOptions>( configuration );
			services.TryAddSingleton<ICredentialsProvider, CredentialsProvider>();

			return services;
		}

		public static IServiceCollection AddCognito<T>(
			this IServiceCollection services,
			IConfigurationSection configuration
		) {
			services.Configure<CognitoOptions<T>>( configuration );
			services.TryAddSingleton<CognitoContext<T>>();

			return services;
		}

		public static IServiceCollection AddCognito<T>(
			this IServiceCollection services,
			CognitoOptions<T> configuration
		) {
			services.TryAddSingleton( configuration );
			services.TryAddSingleton<CognitoContext<T>>();

			return services;
		}

		public static IServiceCollection AddDynamoDb<T>(
			this IServiceCollection services
		) {
			services.TryAddSingleton( new DynamoDbOptions<T>() );
			services.TryAddSingleton<DynamoDbContext<T>>();

			return services;
		}

		public static IServiceCollection AddDynamoDb<T>(
			this IServiceCollection services,
			DynamoDbOptions<T> configuration
		) {
			services.TryAddSingleton( configuration );
			services.TryAddSingleton<DynamoDbContext<T>>();

			return services;
		}

		public static IServiceCollection AddDynamoDb<T>(
			this IServiceCollection services,
			IConfigurationSection configuration
		) {
			services.Configure<DynamoDbOptions<T>>( configuration );
			services.TryAddSingleton<DynamoDbContext<T>>();

			return services;
		}

		public static IServiceCollection AddS3<T>(
			this IServiceCollection services
		) {
			services.TryAddSingleton( new S3Options<T>() );
			services.TryAddSingleton<S3Context<T>>();

			return services;
		}

		public static IServiceCollection AddS3<T>(
			this IServiceCollection services,
			S3Options<T> configuration
		) {
			services.TryAddSingleton( configuration );
			services.TryAddSingleton<S3Context<T>>();

			return services;
		}

		public static IServiceCollection AddS3<T>(
			this IServiceCollection services,
			IConfigurationSection configuration
		) {
			services.Configure<S3Options<T>>( configuration );
			services.TryAddSingleton<S3Context<T>>();

			return services;
		}
	}
}
