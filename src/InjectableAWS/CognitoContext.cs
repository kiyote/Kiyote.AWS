using System;
using System.Globalization;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Runtime;
using Microsoft.Extensions.Options;

namespace InjectableAWS {
	public sealed class CognitoContext<T>: IDisposable {

		public CognitoContext(
			ICredentialsProvider credentialsProvider,
			IOptions<CognitoOptions<T>> options
		): this(
			credentialsProvider,
			options.Value
		) {
		}

		public CognitoContext(
			ICredentialsProvider credentialsProvider,
			CognitoOptions<T> options
		) {
			if (credentialsProvider is null) {
				throw new ArgumentException( $"{nameof( credentialsProvider )} must not be null.", nameof( credentialsProvider ) );
			}

			if (options is null) {
				throw new ArgumentException( $"{nameof( options )} must not be null.", nameof( options ) );
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

			Provider = CreateCognitoProvider( credentialsProvider, options );
		}

		public IAmazonCognitoIdentityProvider Provider { get; }

		private static IAmazonCognitoIdentityProvider CreateCognitoProvider(
			ICredentialsProvider credentialsProvider,
			CognitoOptions<T> options
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

		void IDisposable.Dispose() {
			Provider.Dispose();
		}
	}
}
