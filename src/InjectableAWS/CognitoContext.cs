using System;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Runtime;
using Microsoft.Extensions.Options;

namespace InjectableAWS {
	public sealed class CognitoContext<T> : IDisposable {

		private bool _disposed;

		public CognitoContext(
			ICredentialsProvider credentialsProvider,
			IOptions<CognitoOptions<T>> options
		) : this(
			credentialsProvider,
			options?.Value ?? throw new ArgumentNullException( nameof( options ) )
		) {
		}

		public CognitoContext(
			ICredentialsProvider credentialsProvider,
			ICognitoOptions<T> options
		) {
			if( credentialsProvider is null ) {
				throw new ArgumentException( $"{nameof( credentialsProvider )} must not be null.", nameof( credentialsProvider ) );
			}

			if( options is null ) {
				throw new ArgumentException( $"{nameof( options )} must not be null.", nameof( options ) );
			}

			Provider = CreateCognitoProvider( credentialsProvider, options );
		}

		public IAmazonCognitoIdentityProvider Provider { get; }

		private static IAmazonCognitoIdentityProvider CreateCognitoProvider(
			ICredentialsProvider credentialsProvider,
			ICognitoOptions<T> options
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
}
