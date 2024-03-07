using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using Kiyote.AWS.Credentials;
using Microsoft.Extensions.Options;

namespace Kiyote.AWS.DynamoDb;

public sealed class DynamoDbContext<T> : IDisposable {

	private bool _disposed;

	public DynamoDbContext(
		ICredentialsProvider credentialsProvider,
		IOptions<DynamoDbOptions<T>> options
	) {
		if( options.Value is null ) {
			throw new ArgumentException( $"{nameof( options )} must not be null.", nameof( options ) );
		}

		Client = CreateClient( credentialsProvider, options.Value );
		Context = new DynamoDBContext( Client );
	}

	public IDynamoDBContext Context { get; }

	public IAmazonDynamoDB Client { get; }

	private static IAmazonDynamoDB CreateClient(
		ICredentialsProvider credentialsProvider,
		DynamoDbOptions<T> options
	) {
		AWSCredentials credentials = credentialsProvider.GetCredentials( options.CredentialsProfile );
		if( !string.IsNullOrWhiteSpace( options.Role ) ) {
			credentials = credentialsProvider.AssumeRole(
				credentials,
				options.Role
			);
		}

		if( !string.IsNullOrWhiteSpace( options.RegionEndpoint ) ) {
			AmazonDynamoDBConfig config = new AmazonDynamoDBConfig {
				RegionEndpoint = RegionEndpoint.GetBySystemName( options.RegionEndpoint )
			};
			return new AmazonDynamoDBClient( credentials, config );
		}

		return new AmazonDynamoDBClient( credentials );
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
