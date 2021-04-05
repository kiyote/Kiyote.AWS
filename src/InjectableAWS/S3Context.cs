using System;
using System.Globalization;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Microsoft.Extensions.Options;

namespace InjectableAWS {
	public sealed class S3Context<T> : IDisposable {

		public S3Context(
			ICredentialsProvider credentialsProvider,
			IOptions<S3Options<T>> options
		) : this(
			credentialsProvider,
			options.Value
		) {
		}

		public S3Context(
			ICredentialsProvider credentialsProvider,
			S3Options<T> options
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

			Client = CreateS3Client( credentialsProvider, options );
		}

		public IAmazonS3 Client { get; }

		private static IAmazonS3 CreateS3Client(
			ICredentialsProvider credentialsProvider,
			S3Options<T> options
		) {
			AWSCredentials? roleCredentials = credentialsProvider.GetCredentials( options.CredentialsProfile, options.Role );

			AmazonS3Config config = new AmazonS3Config() {
				RegionEndpoint = RegionEndpoint.GetBySystemName( options.RegionEndpoint ),
				LogMetrics = true,
				DisableLogging = false				
			};
			var client = new AmazonS3Client( roleCredentials, config );

			return client;
		}

		void IDisposable.Dispose() {
			Client.Dispose();
		}
	}
}
