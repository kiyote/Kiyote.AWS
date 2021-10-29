using System;
using System.Globalization;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Microsoft.Extensions.Options;

namespace InjectableAWS {
	public sealed class CredentialsProvider : ICredentialsProvider {

		private readonly ICredentialsOptions _options;

		public CredentialsProvider(
			IOptions<CredentialsOptions> options
		) : this( options?.Value ?? throw new ArgumentNullException( nameof(options) ) ) {
		}

		public CredentialsProvider(
			ICredentialsOptions options
		) {
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
			var chain = new CredentialProfileStoreChain( _options.CredentialsFile );
			
			if( !chain.TryGetAWSCredentials( "default", out AWSCredentials credentials ) ) {
				throw new InvalidOperationException( $"Unable to read default profile from file '{_options.CredentialsFile}'." );
			}

			return credentials;
		}

		AWSCredentials ICredentialsProvider.GetCredentials(
			string? profile
		) {
			var chain = new CredentialProfileStoreChain( _options.CredentialsFile );
			if( !chain.TryGetAWSCredentials( profile, out AWSCredentials credentials ) ) {
				throw new InvalidOperationException( $"Unable to read profile '{profile}' from file '{_options.CredentialsFile}'." );
			}
			return credentials;
		}

		AWSCredentials ICredentialsProvider.GetCredentials(
			string? profile,
			string? role
		) {
			var chain = new CredentialProfileStoreChain( _options.CredentialsFile );
			if( !chain.TryGetAWSCredentials( profile, out AWSCredentials credentials ) ) {
				throw new InvalidOperationException( $"Unable to read profile '{profile}' from file '{_options.CredentialsFile}'." );
			}

			if( string.IsNullOrWhiteSpace( role ) ) {
				return credentials;
			}

			var roleCredentials = new AssumeRoleAWSCredentials(
				credentials,
				role,
				Guid.NewGuid().ToString( "N", CultureInfo.InvariantCulture ) );

			return roleCredentials;
		}
	}
}
