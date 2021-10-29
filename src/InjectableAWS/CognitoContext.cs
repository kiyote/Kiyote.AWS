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

			if( string.IsNullOrWhiteSpace( options.CredentialsProfile ) ) {
				throw new ArgumentException( $"{nameof( options.CredentialsProfile )} must not be null or empty.", nameof( options ) );
			}

			if( string.IsNullOrWhiteSpace( options.Role ) ) {
				throw new ArgumentException( $"{nameof( options.Role )} must not be null or empty.", nameof( options ) );
			}

			if( string.IsNullOrWhiteSpace( options.ServiceUrl ) ) {
				throw new ArgumentException( $"{nameof( options.ServiceUrl )} must not be null or empty.", nameof( options ) );
			}

			if( string.IsNullOrWhiteSpace( options.RegionEndpoint ) ) {
				throw new ArgumentException( $"{nameof( options.RegionEndpoint )} must not be null or empty.", nameof( options ) );
			}

			Provider = CreateCognitoProvider( credentialsProvider, options );
		}

		public IAmazonCognitoIdentityProvider Provider { get; }

		private static IAmazonCognitoIdentityProvider CreateCognitoProvider(
			ICredentialsProvider credentialsProvider,
			ICognitoOptions<T> options
		) {
			AWSCredentials roleCredentials = credentialsProvider.GetCredentials( options.CredentialsProfile, options.Role );

			AmazonCognitoIdentityProviderConfig config = new AmazonCognitoIdentityProviderConfig {
				RegionEndpoint = RegionEndpoint.GetBySystemName( options.RegionEndpoint ),
				ServiceURL = options.ServiceUrl,
				LogMetrics = true,
				DisableLogging = false
			};
			var client = new AmazonCognitoIdentityProviderClient( roleCredentials, config );

			return client;
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
