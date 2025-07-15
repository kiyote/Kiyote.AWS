using System.Globalization;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Credentials;
using Microsoft.Extensions.Options;

namespace Kiyote.AWS.Credentials;

public sealed class CredentialsProvider : ICredentialsProvider {

	private readonly IOptions<CredentialsProviderOptions> _options;

	public CredentialsProvider(
		IOptions<CredentialsProviderOptions> options
	) {
		if( options.Value is null ) {
			throw new ArgumentException( $"{nameof( options )} must not be null", nameof( options ) );
		}

		_options = options;
	}

	AWSCredentials ICredentialsProvider.AssumeRole(
		AWSCredentials credentials,
		string role
	) {
		var roleCredentials = new AssumeRoleAWSCredentials(
			credentials,
			role,
			Guid.NewGuid().ToString( "N", CultureInfo.InvariantCulture ) );

		return roleCredentials;
	}

	AWSCredentials ICredentialsProvider.GetCredentials() {
		return ( this as ICredentialsProvider ).GetCredentials( null );
	}

	AWSCredentials ICredentialsProvider.GetCredentials(
		string? profile
	) {
		if( string.IsNullOrWhiteSpace( _options.Value.CredentialsFile ) ) {
			return DefaultAWSCredentialsIdentityResolver.GetCredentials();
		} else {
			var chain = new CredentialProfileStoreChain( _options.Value.CredentialsFile );
			if( !chain.TryGetAWSCredentials( profile ?? "default", out AWSCredentials credentials ) ) {
				throw new InvalidOperationException( $"Unable to read profile '{profile}' from file '{_options.Value.CredentialsFile}'." );
			}
			return credentials;
		}
	}
}
