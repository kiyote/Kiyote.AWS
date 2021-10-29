using System;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using Microsoft.Extensions.Options;

namespace InjectableAWS {
	public sealed class DynamoDbContext<T> : IDisposable {

		private bool _disposed;

		public DynamoDbContext(
			ICredentialsProvider credentialsProvider,
			IOptions<DynamoDbOptions<T>> options
		) : this(
			credentialsProvider,
			options?.Value ?? throw new ArgumentNullException( nameof( credentialsProvider ) )
		) {
		}

		public DynamoDbContext(
			ICredentialsProvider credentialsProvider,
			IDynamoDbOptions<T> options
		) {
			if( options is null ) {
				throw new ArgumentException( $"{nameof( options )} must not be null.", nameof( options ) );
			}

			if( credentialsProvider is null ) {
				throw new ArgumentException( $"{nameof( credentialsProvider )} must not be null.", nameof( credentialsProvider ) );
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
			IDynamoDbOptions<T> options
		) {
			AWSCredentials credentials = credentialsProvider.GetCredentials( options.CredentialsProfile );
			if( !string.IsNullOrWhiteSpace( options.Role ) ) {
				credentials = credentialsProvider.AssumeRole(
					credentials,
					options.Role
				);
			}

			AmazonDynamoDBConfig config = new AmazonDynamoDBConfig {
				RegionEndpoint = RegionEndpoint.GetBySystemName( options.RegionEndpoint ),
				LogMetrics = true,
				DisableLogging = false
			};
			return new AmazonDynamoDBClient( credentials, config );
		}

		public void Dispose() {
			Dispose( true );
			GC.SuppressFinalize( this );
		}

		private void Dispose( bool disposing ) {
			if( _disposed ) {
				return;
			}

			if( disposing ) {
				Context.Dispose();
				Client.Dispose();
			}

			_disposed = true;
		}
	}

}
