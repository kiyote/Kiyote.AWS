using System;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Microsoft.Extensions.Options;

namespace InjectableAWS {
	public sealed class S3Context<T> : IDisposable {

		private bool _disposed;

		public S3Context(
			ICredentialsProvider credentialsProvider,
			IOptions<S3Options<T>> options
		) : this(
			credentialsProvider,
			options?.Value ?? throw new ArgumentNullException( nameof( options ) )
		) {
		}

		public S3Context(
			ICredentialsProvider credentialsProvider,
			IS3Options<T> options
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

			Client = CreateS3Client( credentialsProvider, options );
		}

		public IAmazonS3 Client { get; }

		private static IAmazonS3 CreateS3Client(
			ICredentialsProvider credentialsProvider,
			IS3Options<T> options
		) {
			AWSCredentials credentials = credentialsProvider.GetCredentials( options.CredentialsProfile );
			if( !string.IsNullOrWhiteSpace( options.Role ) ) {
				credentials = credentialsProvider.AssumeRole(
					credentials,
					options.Role
				);
			}

			AmazonS3Config config = new AmazonS3Config() {
				RegionEndpoint = RegionEndpoint.GetBySystemName( options.RegionEndpoint ),
				LogMetrics = true,
				DisableLogging = false
			};
			var client = new AmazonS3Client( credentials, config );

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
				Client.Dispose();
			}

			_disposed = true;
		}
	}
}
