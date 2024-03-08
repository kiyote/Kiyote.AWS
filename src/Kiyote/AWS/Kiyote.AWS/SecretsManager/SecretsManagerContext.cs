using Amazon;
using Amazon.Runtime;
using Amazon.SecretsManager;
using Kiyote.AWS.Credentials;
using Microsoft.Extensions.Options;

namespace Kiyote.AWS.SecretsManager;

public sealed class SecretsManagerContext<T> : IDisposable where T: class {

	private bool _disposed;

	public SecretsManagerContext(
		ICredentialsProvider credentialsProvider,
		IOptions<SecretsManagerOptions<T>> options
	) {
		Manager = CreateSecretsManager(
			credentialsProvider,
			options.Value
		);
	}

	public IAmazonSecretsManager Manager { get; }

	private static IAmazonSecretsManager CreateSecretsManager(
		ICredentialsProvider credentialsProvider,
		SecretsManagerOptions<T> options
	) {
		AWSCredentials credentials = credentialsProvider.GetCredentials( options.CredentialsProfile );
		if( !string.IsNullOrWhiteSpace( options.Role ) ) {
			credentials = credentialsProvider.AssumeRole(
				credentials,
				options.Role
			);
		}

		if( !string.IsNullOrWhiteSpace( options.RegionEndpoint ) ) {
			AmazonSecretsManagerConfig config = new AmazonSecretsManagerConfig{
				RegionEndpoint = RegionEndpoint.GetBySystemName( options.RegionEndpoint )
			};
			return new AmazonSecretsManagerClient( credentials, config );
		}

		return new AmazonSecretsManagerClient( credentials );
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
			Manager.Dispose();
		}

		_disposed = true;
	}
}
