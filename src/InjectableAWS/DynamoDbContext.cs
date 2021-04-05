using System;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using Microsoft.Extensions.Options;

namespace InjectableAWS {
	public sealed class DynamoDbContext<T>: IDisposable {

		public DynamoDbContext(
			ICredentialsProvider credentialsProvider,
			IOptions<DynamoDbOptions<T>> options
		): this(
			credentialsProvider,
			options.Value
		) {
		}

		public DynamoDbContext(
			ICredentialsProvider credentialsProvider,
			DynamoDbOptions<T> options
		) {
			if (options is null) {
				throw new ArgumentException( $"{nameof( options )} must not be null.", nameof( options ) );
			}

			if( credentialsProvider is null ) {
				throw new ArgumentException( $"{nameof( credentialsProvider )} must not be null.", nameof( credentialsProvider ) );
			}

			if( string.IsNullOrWhiteSpace( options.CredentialsProfile ) ) {
				throw new ArgumentException( $"{nameof( options.CredentialsProfile )} must not be null or empty.", nameof( options ) );
			}

			if( string.IsNullOrWhiteSpace( options.Role ) ) {
				throw new ArgumentException( $"{nameof( options.Role )} must not be null or empty.", nameof( options ) );
			}

			if( string.IsNullOrWhiteSpace( options.RegionEndpoint ) ) {
				throw new ArgumentException( $"{nameof( options.RegionEndpoint )} must not be null or empty.", nameof( options ) );
			}

			Client = CreateClient( credentialsProvider, options );
			Context = new DynamoDBContext( Client );
		}

		public IDynamoDBContext Context { get; }

		public IAmazonDynamoDB Client { get; }

		private static IAmazonDynamoDB CreateClient(
			ICredentialsProvider credentialsProvider,
			DynamoDbOptions<T> options
		) {
			AWSCredentials roleCredentials = credentialsProvider.GetCredentials( options.CredentialsProfile, options.Role );

			AmazonDynamoDBConfig config = new AmazonDynamoDBConfig {
				RegionEndpoint = RegionEndpoint.GetBySystemName( options.RegionEndpoint ),
				ServiceURL = options.ServiceUrl,
				LogMetrics = true,
				DisableLogging = false
			};
			return new AmazonDynamoDBClient( roleCredentials, config );
		}

		void IDisposable.Dispose() {
			Context.Dispose();
			Client.Dispose();
		}
	}

}
