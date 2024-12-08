using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Runtime;
using Kiyote.AWS.Credentials;
using Microsoft.Extensions.Options;

namespace Kiyote.AWS.Cognito;

internal sealed partial class AmazonCognitoIdentityProviderContext<T> : IAmazonCognitoIdentityProvider<T> where T : class {

	private bool _disposed;

	public AmazonCognitoIdentityProviderContext(
		ICredentialsProvider credentialsProvider,
		IOptions<CognitoOptions<T>> options
	) {
		if( options.Value is null ) {
			throw new ArgumentException( $"{nameof( options )} must not be null.", nameof( options ) );
		}

		Provider = CreateCognitoProvider( credentialsProvider, options.Value );
	}

	public IAmazonCognitoIdentityProvider Provider { get; }

	private static IAmazonCognitoIdentityProvider CreateCognitoProvider(
		ICredentialsProvider credentialsProvider,
		CognitoOptions<T> options
	) {
		AWSCredentials credentials = credentialsProvider.GetCredentials( options.CredentialsProfile );
		if( !string.IsNullOrWhiteSpace( options.Role ) ) {
			credentials = credentialsProvider.AssumeRole(
				credentials,
				options.Role
			);
		}

		if( !string.IsNullOrWhiteSpace( options.RegionEndpoint ) ) {
			AmazonCognitoIdentityProviderConfig config = new AmazonCognitoIdentityProviderConfig {
				RegionEndpoint = RegionEndpoint.GetBySystemName( options.RegionEndpoint )
			};
			return new AmazonCognitoIdentityProviderClient( credentials, config );
		}

		return new AmazonCognitoIdentityProviderClient( credentials );
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
			Provider.Dispose();
		}

		_disposed = true;
	}

}
