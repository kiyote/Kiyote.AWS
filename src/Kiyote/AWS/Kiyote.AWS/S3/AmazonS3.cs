using System.Diagnostics.CodeAnalysis;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.SharedInterfaces;
using Amazon.S3;
using Amazon.S3.Model;
using Kiyote.AWS.Credentials;
using Microsoft.Extensions.Options;

namespace Kiyote.AWS.S3;

internal sealed class AmazonS3<T> : IAmazonS3<T> where T: class {

	private bool _disposed;

	public AmazonS3(
		ICredentialsProvider credentialsProvider,
		IOptions<S3Options<T>> options
	) {
		if( options.Value is null ) {
			throw new ArgumentException( $"{nameof( options )} must not be null.", nameof( options ) );
		}

		Client = CreateS3Client( credentialsProvider, options.Value );
	}

	public IAmazonS3 Client { get; }

	IS3PaginatorFactory IAmazonS3.Paginators => throw new NotImplementedException();

	IClientConfig IAmazonService.Config => throw new NotImplementedException();

	private static IAmazonS3 CreateS3Client(
		ICredentialsProvider credentialsProvider,
		S3Options<T> options
	) {
		AWSCredentials credentials = credentialsProvider.GetCredentials( options.CredentialsProfile );
		if( !string.IsNullOrWhiteSpace( options.Role ) ) {
			credentials = credentialsProvider.AssumeRole(
				credentials,
				options.Role
			);
		}

		if( !string.IsNullOrWhiteSpace( options.RegionEndpoint ) ) {
			AmazonS3Config config = new AmazonS3Config() {
				RegionEndpoint = RegionEndpoint.GetBySystemName( options.RegionEndpoint )
			};
			return new AmazonS3Client( credentials, config );
		}

		return new AmazonS3Client( credentials );
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

	[ExcludeFromCodeCoverage]
	Task<AbortMultipartUploadResponse> IAmazonS3.AbortMultipartUploadAsync( string bucketName, string key, string uploadId, CancellationToken cancellationToken ) {
		return Client.AbortMultipartUploadAsync( bucketName, key, uploadId, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AbortMultipartUploadResponse> IAmazonS3.AbortMultipartUploadAsync( AbortMultipartUploadRequest request, CancellationToken cancellationToken ) {
		return Client.AbortMultipartUploadAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CompleteMultipartUploadResponse> IAmazonS3.CompleteMultipartUploadAsync( CompleteMultipartUploadRequest request, CancellationToken cancellationToken ) {
		return Client.CompleteMultipartUploadAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CopyObjectResponse> IAmazonS3.CopyObjectAsync( string sourceBucket, string sourceKey, string destinationBucket, string destinationKey, CancellationToken cancellationToken ) {
		return Client.CopyObjectAsync( sourceBucket, sourceKey, destinationBucket, destinationKey, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CopyObjectResponse> IAmazonS3.CopyObjectAsync( string sourceBucket, string sourceKey, string sourceVersionId, string destinationBucket, string destinationKey, CancellationToken cancellationToken ) {
		return Client.CopyObjectAsync( sourceBucket, sourceKey, sourceVersionId, destinationBucket, destinationKey, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CopyObjectResponse> IAmazonS3.CopyObjectAsync( CopyObjectRequest request, CancellationToken cancellationToken ) {
		return Client.CopyObjectAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CopyPartResponse> IAmazonS3.CopyPartAsync( string sourceBucket, string sourceKey, string destinationBucket, string destinationKey, string uploadId, int? partNumber, CancellationToken cancellationToken ) { 

		return Client.CopyPartAsync( sourceBucket, sourceKey, destinationBucket, destinationKey, uploadId, partNumber, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CopyPartResponse> IAmazonS3.CopyPartAsync( string sourceBucket, string sourceKey, string sourceVersionId, string destinationBucket, string destinationKey, string uploadId, int? partNumber, CancellationToken cancellationToken ) {
		return Client.CopyPartAsync( sourceBucket, sourceKey, sourceVersionId, destinationBucket, destinationKey, uploadId, partNumber, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CopyPartResponse> IAmazonS3.CopyPartAsync( CopyPartRequest request, CancellationToken cancellationToken ) {
		return Client.CopyPartAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateBucketMetadataTableConfigurationResponse> IAmazonS3.CreateBucketMetadataTableConfigurationAsync( CreateBucketMetadataTableConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.CreateBucketMetadataTableConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateSessionResponse> IAmazonS3.CreateSessionAsync( CreateSessionRequest request, CancellationToken cancellationToken ) {
		return Client.CreateSessionAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task ICoreAmazonS3.DeleteAsync( string bucketName, string objectKey, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken ) {
		return Client.DeleteAsync( bucketName, objectKey, additionalProperties, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketAnalyticsConfigurationResponse> IAmazonS3.DeleteBucketAnalyticsConfigurationAsync( DeleteBucketAnalyticsConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteBucketAnalyticsConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketResponse> IAmazonS3.DeleteBucketAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.DeleteBucketAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketResponse> IAmazonS3.DeleteBucketAsync( DeleteBucketRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteBucketAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketEncryptionResponse> IAmazonS3.DeleteBucketEncryptionAsync( DeleteBucketEncryptionRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteBucketEncryptionAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketIntelligentTieringConfigurationResponse> IAmazonS3.DeleteBucketIntelligentTieringConfigurationAsync( DeleteBucketIntelligentTieringConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteBucketIntelligentTieringConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketInventoryConfigurationResponse> IAmazonS3.DeleteBucketInventoryConfigurationAsync( DeleteBucketInventoryConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteBucketInventoryConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketMetadataTableConfigurationResponse> IAmazonS3.DeleteBucketMetadataTableConfigurationAsync( DeleteBucketMetadataTableConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteBucketMetadataTableConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketMetricsConfigurationResponse> IAmazonS3.DeleteBucketMetricsConfigurationAsync( DeleteBucketMetricsConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteBucketMetricsConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketOwnershipControlsResponse> IAmazonS3.DeleteBucketOwnershipControlsAsync( DeleteBucketOwnershipControlsRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteBucketOwnershipControlsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketPolicyResponse> IAmazonS3.DeleteBucketPolicyAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.DeleteBucketPolicyAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketPolicyResponse> IAmazonS3.DeleteBucketPolicyAsync( DeleteBucketPolicyRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteBucketPolicyAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketReplicationResponse> IAmazonS3.DeleteBucketReplicationAsync( DeleteBucketReplicationRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteBucketReplicationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketTaggingResponse> IAmazonS3.DeleteBucketTaggingAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.DeleteBucketTaggingAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketTaggingResponse> IAmazonS3.DeleteBucketTaggingAsync( DeleteBucketTaggingRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteBucketTaggingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketWebsiteResponse> IAmazonS3.DeleteBucketWebsiteAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.DeleteBucketWebsiteAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBucketWebsiteResponse> IAmazonS3.DeleteBucketWebsiteAsync( DeleteBucketWebsiteRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteBucketWebsiteAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteCORSConfigurationResponse> IAmazonS3.DeleteCORSConfigurationAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.DeleteCORSConfigurationAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteCORSConfigurationResponse> IAmazonS3.DeleteCORSConfigurationAsync( DeleteCORSConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteCORSConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteLifecycleConfigurationResponse> IAmazonS3.DeleteLifecycleConfigurationAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.DeleteLifecycleConfigurationAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteLifecycleConfigurationResponse> IAmazonS3.DeleteLifecycleConfigurationAsync( DeleteLifecycleConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteLifecycleConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteObjectResponse> IAmazonS3.DeleteObjectAsync( string bucketName, string key, CancellationToken cancellationToken ) {
		return Client.DeleteObjectAsync( bucketName, key, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteObjectResponse> IAmazonS3.DeleteObjectAsync( string bucketName, string key, string versionId, CancellationToken cancellationToken ) {
		return Client.DeleteObjectAsync( bucketName, key, versionId, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteObjectResponse> IAmazonS3.DeleteObjectAsync( DeleteObjectRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteObjectAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteObjectsResponse> IAmazonS3.DeleteObjectsAsync( DeleteObjectsRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteObjectsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteObjectTaggingResponse> IAmazonS3.DeleteObjectTaggingAsync( DeleteObjectTaggingRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteObjectTaggingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeletePublicAccessBlockResponse> IAmazonS3.DeletePublicAccessBlockAsync( DeletePublicAccessBlockRequest request, CancellationToken cancellationToken ) {
		return Client.DeletePublicAccessBlockAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task ICoreAmazonS3.DeletesAsync( string bucketName, IEnumerable<string> objectKeys, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken ) {
		return Client.DeletesAsync( bucketName, objectKeys, additionalProperties, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Endpoint IAmazonS3.DetermineServiceOperationEndpoint( AmazonWebServiceRequest request ) {
		return Client.DetermineServiceOperationEndpoint( request );
	}

	[ExcludeFromCodeCoverage]
	Task ICoreAmazonS3.DownloadToFilePathAsync( string bucketName, string objectKey, string filepath, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken ) {
		return Client.DownloadToFilePathAsync( bucketName, objectKey, filepath, additionalProperties, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task ICoreAmazonS3.EnsureBucketExistsAsync( string bucketName ) {
		return Client.EnsureBucketExistsAsync( bucketName );
	}

	[ExcludeFromCodeCoverage]
	string ICoreAmazonS3.GeneratePreSignedURL( string bucketName, string objectKey, DateTime expiration, IDictionary<string, object> additionalProperties ) {
		return Client.GeneratePreSignedURL( bucketName, objectKey, expiration, additionalProperties );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	Task<GetACLResponse> IAmazonS3.GetACLAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.GetACLAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	Task<GetACLResponse> IAmazonS3.GetACLAsync( GetACLRequest request, CancellationToken cancellationToken ) {
		return Client.GetACLAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<IList<string>> ICoreAmazonS3.GetAllObjectKeysAsync( string bucketName, string prefix, IDictionary<string, object> additionalProperties ) {
		return Client.GetAllObjectKeysAsync( bucketName, prefix, additionalProperties );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketAccelerateConfigurationResponse> IAmazonS3.GetBucketAccelerateConfigurationAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.GetBucketAccelerateConfigurationAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketAccelerateConfigurationResponse> IAmazonS3.GetBucketAccelerateConfigurationAsync( GetBucketAccelerateConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketAccelerateConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketAclResponse> IAmazonS3.GetBucketAclAsync( GetBucketAclRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketAclAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketAnalyticsConfigurationResponse> IAmazonS3.GetBucketAnalyticsConfigurationAsync( GetBucketAnalyticsConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketAnalyticsConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketEncryptionResponse> IAmazonS3.GetBucketEncryptionAsync( GetBucketEncryptionRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketEncryptionAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketIntelligentTieringConfigurationResponse> IAmazonS3.GetBucketIntelligentTieringConfigurationAsync( GetBucketIntelligentTieringConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketIntelligentTieringConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketInventoryConfigurationResponse> IAmazonS3.GetBucketInventoryConfigurationAsync( GetBucketInventoryConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketInventoryConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketLocationResponse> IAmazonS3.GetBucketLocationAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.GetBucketLocationAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketLocationResponse> IAmazonS3.GetBucketLocationAsync( GetBucketLocationRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketLocationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketLoggingResponse> IAmazonS3.GetBucketLoggingAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.GetBucketLoggingAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketLoggingResponse> IAmazonS3.GetBucketLoggingAsync( GetBucketLoggingRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketLoggingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketMetadataTableConfigurationResponse> IAmazonS3.GetBucketMetadataTableConfigurationAsync( GetBucketMetadataTableConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketMetadataTableConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketMetricsConfigurationResponse> IAmazonS3.GetBucketMetricsConfigurationAsync( GetBucketMetricsConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketMetricsConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketNotificationResponse> IAmazonS3.GetBucketNotificationAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.GetBucketNotificationAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketNotificationResponse> IAmazonS3.GetBucketNotificationAsync( GetBucketNotificationRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketNotificationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketOwnershipControlsResponse> IAmazonS3.GetBucketOwnershipControlsAsync( GetBucketOwnershipControlsRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketOwnershipControlsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketPolicyResponse> IAmazonS3.GetBucketPolicyAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.GetBucketPolicyAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketPolicyResponse> IAmazonS3.GetBucketPolicyAsync( GetBucketPolicyRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketPolicyAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketPolicyStatusResponse> IAmazonS3.GetBucketPolicyStatusAsync( GetBucketPolicyStatusRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketPolicyStatusAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketReplicationResponse> IAmazonS3.GetBucketReplicationAsync( GetBucketReplicationRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketReplicationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketRequestPaymentResponse> IAmazonS3.GetBucketRequestPaymentAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.GetBucketRequestPaymentAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketRequestPaymentResponse> IAmazonS3.GetBucketRequestPaymentAsync( GetBucketRequestPaymentRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketRequestPaymentAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketTaggingResponse> IAmazonS3.GetBucketTaggingAsync( GetBucketTaggingRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketTaggingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketVersioningResponse> IAmazonS3.GetBucketVersioningAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.GetBucketVersioningAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketVersioningResponse> IAmazonS3.GetBucketVersioningAsync( GetBucketVersioningRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketVersioningAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketWebsiteResponse> IAmazonS3.GetBucketWebsiteAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.GetBucketWebsiteAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetBucketWebsiteResponse> IAmazonS3.GetBucketWebsiteAsync( GetBucketWebsiteRequest request, CancellationToken cancellationToken ) {
		return Client.GetBucketWebsiteAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetCORSConfigurationResponse> IAmazonS3.GetCORSConfigurationAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.GetCORSConfigurationAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetCORSConfigurationResponse> IAmazonS3.GetCORSConfigurationAsync( GetCORSConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.GetCORSConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetLifecycleConfigurationResponse> IAmazonS3.GetLifecycleConfigurationAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.GetLifecycleConfigurationAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetLifecycleConfigurationResponse> IAmazonS3.GetLifecycleConfigurationAsync( GetLifecycleConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.GetLifecycleConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectAclResponse> IAmazonS3.GetObjectAclAsync( GetObjectAclRequest request, CancellationToken cancellationToken ) {
		return Client.GetObjectAclAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectResponse> IAmazonS3.GetObjectAsync( string bucketName, string key, CancellationToken cancellationToken ) {
		return Client.GetObjectAsync( bucketName, key, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectResponse> IAmazonS3.GetObjectAsync( string bucketName, string key, string versionId, CancellationToken cancellationToken ) {
		return Client.GetObjectAsync( bucketName, key, versionId, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectResponse> IAmazonS3.GetObjectAsync( GetObjectRequest request, CancellationToken cancellationToken ) {
		return Client.GetObjectAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectAttributesResponse> IAmazonS3.GetObjectAttributesAsync( GetObjectAttributesRequest request, CancellationToken cancellationToken ) {
		return Client.GetObjectAttributesAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectLegalHoldResponse> IAmazonS3.GetObjectLegalHoldAsync( GetObjectLegalHoldRequest request, CancellationToken cancellationToken ) {
		return Client.GetObjectLegalHoldAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectLockConfigurationResponse> IAmazonS3.GetObjectLockConfigurationAsync( GetObjectLockConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.GetObjectLockConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectMetadataResponse> IAmazonS3.GetObjectMetadataAsync( string bucketName, string key, CancellationToken cancellationToken ) {
		return Client.GetObjectMetadataAsync( bucketName, key, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectMetadataResponse> IAmazonS3.GetObjectMetadataAsync( string bucketName, string key, string versionId, CancellationToken cancellationToken ) {
		return Client.GetObjectMetadataAsync( bucketName, key, versionId, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectMetadataResponse> IAmazonS3.GetObjectMetadataAsync( GetObjectMetadataRequest request, CancellationToken cancellationToken ) {
		return Client.GetObjectMetadataAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectRetentionResponse> IAmazonS3.GetObjectRetentionAsync( GetObjectRetentionRequest request, CancellationToken cancellationToken ) {
		return Client.GetObjectRetentionAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<Stream> ICoreAmazonS3.GetObjectStreamAsync( string bucketName, string objectKey, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken ) {
		return Client.GetObjectStreamAsync( bucketName, objectKey, additionalProperties, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectTaggingResponse> IAmazonS3.GetObjectTaggingAsync( GetObjectTaggingRequest request, CancellationToken cancellationToken ) {
		return Client.GetObjectTaggingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectTorrentResponse> IAmazonS3.GetObjectTorrentAsync( string bucketName, string key, CancellationToken cancellationToken ) {
		return Client.GetObjectTorrentAsync( bucketName, key, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetObjectTorrentResponse> IAmazonS3.GetObjectTorrentAsync( GetObjectTorrentRequest request, CancellationToken cancellationToken ) {
		return Client.GetObjectTorrentAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	string IAmazonS3.GetPreSignedURL( GetPreSignedUrlRequest request ) {
		return Client.GetPreSignedURL( request );
	}

	[ExcludeFromCodeCoverage]
	Task<string> IAmazonS3.GetPreSignedURLAsync( GetPreSignedUrlRequest request ) {
		return Client.GetPreSignedURLAsync( request );
	}

	[ExcludeFromCodeCoverage]
	Task<GetPublicAccessBlockResponse> IAmazonS3.GetPublicAccessBlockAsync( GetPublicAccessBlockRequest request, CancellationToken cancellationToken ) {
		return Client.GetPublicAccessBlockAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<HeadBucketResponse> IAmazonS3.HeadBucketAsync( HeadBucketRequest request, CancellationToken cancellationToken ) {
		return Client.HeadBucketAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<InitiateMultipartUploadResponse> IAmazonS3.InitiateMultipartUploadAsync( string bucketName, string key, CancellationToken cancellationToken ) {
		return Client.InitiateMultipartUploadAsync( bucketName, key, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<InitiateMultipartUploadResponse> IAmazonS3.InitiateMultipartUploadAsync( InitiateMultipartUploadRequest request, CancellationToken cancellationToken ) {
		return Client.InitiateMultipartUploadAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListBucketAnalyticsConfigurationsResponse> IAmazonS3.ListBucketAnalyticsConfigurationsAsync( ListBucketAnalyticsConfigurationsRequest request, CancellationToken cancellationToken ) {
		return Client.ListBucketAnalyticsConfigurationsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListBucketIntelligentTieringConfigurationsResponse> IAmazonS3.ListBucketIntelligentTieringConfigurationsAsync( ListBucketIntelligentTieringConfigurationsRequest request, CancellationToken cancellationToken ) {
		return Client.ListBucketIntelligentTieringConfigurationsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListBucketInventoryConfigurationsResponse> IAmazonS3.ListBucketInventoryConfigurationsAsync( ListBucketInventoryConfigurationsRequest request, CancellationToken cancellationToken ) {
		return Client.ListBucketInventoryConfigurationsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListBucketMetricsConfigurationsResponse> IAmazonS3.ListBucketMetricsConfigurationsAsync( ListBucketMetricsConfigurationsRequest request, CancellationToken cancellationToken ) {
		return Client.ListBucketMetricsConfigurationsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListBucketsResponse> IAmazonS3.ListBucketsAsync( CancellationToken cancellationToken ) {
		return Client.ListBucketsAsync( cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListBucketsResponse> IAmazonS3.ListBucketsAsync( ListBucketsRequest request, CancellationToken cancellationToken ) {
		return Client.ListBucketsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListDirectoryBucketsResponse> IAmazonS3.ListDirectoryBucketsAsync( ListDirectoryBucketsRequest request, CancellationToken cancellationToken ) {
		return Client.ListDirectoryBucketsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListMultipartUploadsResponse> IAmazonS3.ListMultipartUploadsAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.ListMultipartUploadsAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListMultipartUploadsResponse> IAmazonS3.ListMultipartUploadsAsync( string bucketName, string prefix, CancellationToken cancellationToken ) {
		return Client.ListMultipartUploadsAsync( bucketName, prefix, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListMultipartUploadsResponse> IAmazonS3.ListMultipartUploadsAsync( ListMultipartUploadsRequest request, CancellationToken cancellationToken ) {
		return Client.ListMultipartUploadsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListObjectsResponse> IAmazonS3.ListObjectsAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.ListObjectsAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListObjectsResponse> IAmazonS3.ListObjectsAsync( string bucketName, string prefix, CancellationToken cancellationToken ) {
		return Client.ListObjectsAsync( bucketName, prefix, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListObjectsResponse> IAmazonS3.ListObjectsAsync( ListObjectsRequest request, CancellationToken cancellationToken ) {
		return Client.ListObjectsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListObjectsV2Response> IAmazonS3.ListObjectsV2Async( ListObjectsV2Request request, CancellationToken cancellationToken ) {
		return Client.ListObjectsV2Async( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListPartsResponse> IAmazonS3.ListPartsAsync( string bucketName, string key, string uploadId, CancellationToken cancellationToken ) {
		return Client.ListPartsAsync( bucketName, key, uploadId, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListPartsResponse> IAmazonS3.ListPartsAsync( ListPartsRequest request, CancellationToken cancellationToken ) {
		return Client.ListPartsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListVersionsResponse> IAmazonS3.ListVersionsAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.ListVersionsAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListVersionsResponse> IAmazonS3.ListVersionsAsync( string bucketName, string prefix, CancellationToken cancellationToken ) {
		return Client.ListVersionsAsync( bucketName, prefix, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListVersionsResponse> IAmazonS3.ListVersionsAsync( ListVersionsRequest request, CancellationToken cancellationToken ) {
		return Client.ListVersionsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task ICoreAmazonS3.MakeObjectPublicAsync( string bucketName, string objectKey, bool enable ) {
		return Client.MakeObjectPublicAsync( bucketName, objectKey, enable );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	Task<PutACLResponse> IAmazonS3.PutACLAsync( PutACLRequest request, CancellationToken cancellationToken ) {
		return Client.PutACLAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketAccelerateConfigurationResponse> IAmazonS3.PutBucketAccelerateConfigurationAsync( PutBucketAccelerateConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketAccelerateConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketAclResponse> IAmazonS3.PutBucketAclAsync( PutBucketAclRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketAclAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketAnalyticsConfigurationResponse> IAmazonS3.PutBucketAnalyticsConfigurationAsync( PutBucketAnalyticsConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketAnalyticsConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketResponse> IAmazonS3.PutBucketAsync( string bucketName, CancellationToken cancellationToken ) {
		return Client.PutBucketAsync( bucketName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketResponse> IAmazonS3.PutBucketAsync( PutBucketRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketEncryptionResponse> IAmazonS3.PutBucketEncryptionAsync( PutBucketEncryptionRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketEncryptionAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketIntelligentTieringConfigurationResponse> IAmazonS3.PutBucketIntelligentTieringConfigurationAsync( PutBucketIntelligentTieringConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketIntelligentTieringConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketInventoryConfigurationResponse> IAmazonS3.PutBucketInventoryConfigurationAsync( PutBucketInventoryConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketInventoryConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketLoggingResponse> IAmazonS3.PutBucketLoggingAsync( PutBucketLoggingRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketLoggingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketMetricsConfigurationResponse> IAmazonS3.PutBucketMetricsConfigurationAsync( PutBucketMetricsConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketMetricsConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketNotificationResponse> IAmazonS3.PutBucketNotificationAsync( PutBucketNotificationRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketNotificationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketOwnershipControlsResponse> IAmazonS3.PutBucketOwnershipControlsAsync( PutBucketOwnershipControlsRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketOwnershipControlsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketPolicyResponse> IAmazonS3.PutBucketPolicyAsync( string bucketName, string policy, CancellationToken cancellationToken ) {
		return Client.PutBucketPolicyAsync( bucketName, policy, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketPolicyResponse> IAmazonS3.PutBucketPolicyAsync( string bucketName, string policy, string contentMD5, CancellationToken cancellationToken ) {
		return Client.PutBucketPolicyAsync( bucketName, policy, contentMD5, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketPolicyResponse> IAmazonS3.PutBucketPolicyAsync( PutBucketPolicyRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketPolicyAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketReplicationResponse> IAmazonS3.PutBucketReplicationAsync( PutBucketReplicationRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketReplicationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketRequestPaymentResponse> IAmazonS3.PutBucketRequestPaymentAsync( string bucketName, RequestPaymentConfiguration requestPaymentConfiguration, CancellationToken cancellationToken ) {
		return Client.PutBucketRequestPaymentAsync( bucketName, requestPaymentConfiguration, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketRequestPaymentResponse> IAmazonS3.PutBucketRequestPaymentAsync( PutBucketRequestPaymentRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketRequestPaymentAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketTaggingResponse> IAmazonS3.PutBucketTaggingAsync( string bucketName, List<Tag> tagSet, CancellationToken cancellationToken ) {
		return Client.PutBucketTaggingAsync( bucketName, tagSet, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketTaggingResponse> IAmazonS3.PutBucketTaggingAsync( PutBucketTaggingRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketTaggingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketVersioningResponse> IAmazonS3.PutBucketVersioningAsync( PutBucketVersioningRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketVersioningAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketWebsiteResponse> IAmazonS3.PutBucketWebsiteAsync( string bucketName, WebsiteConfiguration websiteConfiguration, CancellationToken cancellationToken ) {
		return Client.PutBucketWebsiteAsync( bucketName, websiteConfiguration, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutBucketWebsiteResponse> IAmazonS3.PutBucketWebsiteAsync( PutBucketWebsiteRequest request, CancellationToken cancellationToken ) {
		return Client.PutBucketWebsiteAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutCORSConfigurationResponse> IAmazonS3.PutCORSConfigurationAsync( string bucketName, CORSConfiguration configuration, CancellationToken cancellationToken ) {
		return Client.PutCORSConfigurationAsync( bucketName, configuration, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutCORSConfigurationResponse> IAmazonS3.PutCORSConfigurationAsync( PutCORSConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.PutCORSConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutLifecycleConfigurationResponse> IAmazonS3.PutLifecycleConfigurationAsync( string bucketName, LifecycleConfiguration configuration, CancellationToken cancellationToken ) {
		return Client.PutLifecycleConfigurationAsync( bucketName, configuration, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutLifecycleConfigurationResponse> IAmazonS3.PutLifecycleConfigurationAsync( PutLifecycleConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.PutLifecycleConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutObjectAclResponse> IAmazonS3.PutObjectAclAsync( PutObjectAclRequest request, CancellationToken cancellationToken ) {
		return Client.PutObjectAclAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutObjectResponse> IAmazonS3.PutObjectAsync( PutObjectRequest request, CancellationToken cancellationToken ) {
		return Client.PutObjectAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutObjectLegalHoldResponse> IAmazonS3.PutObjectLegalHoldAsync( PutObjectLegalHoldRequest request, CancellationToken cancellationToken ) {
		return Client.PutObjectLegalHoldAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutObjectLockConfigurationResponse> IAmazonS3.PutObjectLockConfigurationAsync( PutObjectLockConfigurationRequest request, CancellationToken cancellationToken ) {
		return Client.PutObjectLockConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutObjectRetentionResponse> IAmazonS3.PutObjectRetentionAsync( PutObjectRetentionRequest request, CancellationToken cancellationToken ) {
		return Client.PutObjectRetentionAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutObjectTaggingResponse> IAmazonS3.PutObjectTaggingAsync( PutObjectTaggingRequest request, CancellationToken cancellationToken ) {
		return Client.PutObjectTaggingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutPublicAccessBlockResponse> IAmazonS3.PutPublicAccessBlockAsync( PutPublicAccessBlockRequest request, CancellationToken cancellationToken ) {
		return Client.PutPublicAccessBlockAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<RenameObjectResponse> IAmazonS3.RenameObjectAsync( RenameObjectRequest request, CancellationToken cancellationToken ) {
		return Client.RenameObjectAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<RestoreObjectResponse> IAmazonS3.RestoreObjectAsync( string bucketName, string key, CancellationToken cancellationToken ) {
		return Client.RestoreObjectAsync( bucketName, key, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<RestoreObjectResponse> IAmazonS3.RestoreObjectAsync( string bucketName, string key, int? days, CancellationToken cancellationToken ) {
		return Client.RestoreObjectAsync( bucketName, key, days, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<RestoreObjectResponse> IAmazonS3.RestoreObjectAsync( string bucketName, string key, string versionId, CancellationToken cancellationToken ) {
		return Client.RestoreObjectAsync( bucketName, key, versionId, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<RestoreObjectResponse> IAmazonS3.RestoreObjectAsync( string bucketName, string key, string versionId, int? days, CancellationToken cancellationToken ) {
		return Client.RestoreObjectAsync( bucketName, key, versionId, days, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<RestoreObjectResponse> IAmazonS3.RestoreObjectAsync( RestoreObjectRequest request, CancellationToken cancellationToken ) {
		return Client.RestoreObjectAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<SelectObjectContentResponse> IAmazonS3.SelectObjectContentAsync( SelectObjectContentRequest request, CancellationToken cancellationToken ) {
		return Client.SelectObjectContentAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task ICoreAmazonS3.UploadObjectFromFilePathAsync( string bucketName, string objectKey, string filepath, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken ) {
		return Client.UploadObjectFromFilePathAsync( bucketName, objectKey, filepath, additionalProperties, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task ICoreAmazonS3.UploadObjectFromStreamAsync( string bucketName, string objectKey, Stream stream, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken ) {
		return Client.UploadObjectFromStreamAsync( bucketName, objectKey, stream, additionalProperties, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UploadPartResponse> IAmazonS3.UploadPartAsync( UploadPartRequest request, CancellationToken cancellationToken ) {
		return Client.UploadPartAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<WriteGetObjectResponseResponse> IAmazonS3.WriteGetObjectResponseAsync( WriteGetObjectResponseRequest request, CancellationToken cancellationToken ) {
		return Client.WriteGetObjectResponseAsync( request, cancellationToken );
	}
}
