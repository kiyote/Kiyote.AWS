using System.Diagnostics.CodeAnalysis;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.Endpoints;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Kiyote.AWS.Credentials;
using Microsoft.Extensions.Options;

namespace Kiyote.AWS.SecretsManager;

internal sealed class AmazonSecretsManager<T> : IAmazonSecretsManager<T> where T: class {

	private bool _disposed;

	public AmazonSecretsManager(
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

	[ExcludeFromCodeCoverage]
	ISecretsManagerPaginatorFactory IAmazonSecretsManager.Paginators => Manager.Paginators;

	[ExcludeFromCodeCoverage]
	IClientConfig IAmazonService.Config => Manager.Config;

	[ExcludeFromCodeCoverage]
	Endpoint IAmazonSecretsManager.DetermineServiceOperationEndpoint( AmazonWebServiceRequest request ) {
		return Manager.DetermineServiceOperationEndpoint( request );
	}

	[ExcludeFromCodeCoverage]
	Task<BatchGetSecretValueResponse> IAmazonSecretsManager.BatchGetSecretValueAsync( BatchGetSecretValueRequest request, CancellationToken cancellationToken ) {
		return Manager.BatchGetSecretValueAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CancelRotateSecretResponse> IAmazonSecretsManager.CancelRotateSecretAsync( CancelRotateSecretRequest request, CancellationToken cancellationToken ) {
		return Manager.CancelRotateSecretAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateSecretResponse> IAmazonSecretsManager.CreateSecretAsync( CreateSecretRequest request, CancellationToken cancellationToken ) {
		return Manager.CreateSecretAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteResourcePolicyResponse> IAmazonSecretsManager.DeleteResourcePolicyAsync( DeleteResourcePolicyRequest request, CancellationToken cancellationToken ) {
		return Manager.DeleteResourcePolicyAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteSecretResponse> IAmazonSecretsManager.DeleteSecretAsync( DeleteSecretRequest request, CancellationToken cancellationToken ) {
		return Manager.DeleteSecretAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeSecretResponse> IAmazonSecretsManager.DescribeSecretAsync( DescribeSecretRequest request, CancellationToken cancellationToken ) {
		return Manager.DescribeSecretAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetRandomPasswordResponse> IAmazonSecretsManager.GetRandomPasswordAsync( GetRandomPasswordRequest request, CancellationToken cancellationToken ) {
		return Manager.GetRandomPasswordAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetResourcePolicyResponse> IAmazonSecretsManager.GetResourcePolicyAsync( GetResourcePolicyRequest request, CancellationToken cancellationToken ) {
		return Manager.GetResourcePolicyAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetSecretValueResponse> IAmazonSecretsManager.GetSecretValueAsync( GetSecretValueRequest request, CancellationToken cancellationToken ) {
		return Manager.GetSecretValueAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListSecretsResponse> IAmazonSecretsManager.ListSecretsAsync( ListSecretsRequest request, CancellationToken cancellationToken ) {
		return Manager.ListSecretsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListSecretVersionIdsResponse> IAmazonSecretsManager.ListSecretVersionIdsAsync( ListSecretVersionIdsRequest request, CancellationToken cancellationToken ) {
		return Manager.ListSecretVersionIdsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutResourcePolicyResponse> IAmazonSecretsManager.PutResourcePolicyAsync( PutResourcePolicyRequest request, CancellationToken cancellationToken ) {
		return Manager.PutResourcePolicyAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutSecretValueResponse> IAmazonSecretsManager.PutSecretValueAsync( PutSecretValueRequest request, CancellationToken cancellationToken ) {
		return Manager.PutSecretValueAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<RemoveRegionsFromReplicationResponse> IAmazonSecretsManager.RemoveRegionsFromReplicationAsync( RemoveRegionsFromReplicationRequest request, CancellationToken cancellationToken ) {
		return Manager.RemoveRegionsFromReplicationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ReplicateSecretToRegionsResponse> IAmazonSecretsManager.ReplicateSecretToRegionsAsync( ReplicateSecretToRegionsRequest request, CancellationToken cancellationToken ) {
		return Manager.ReplicateSecretToRegionsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<RestoreSecretResponse> IAmazonSecretsManager.RestoreSecretAsync( RestoreSecretRequest request, CancellationToken cancellationToken ) {
		return Manager.RestoreSecretAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<RotateSecretResponse> IAmazonSecretsManager.RotateSecretAsync( RotateSecretRequest request, CancellationToken cancellationToken ) {
		return Manager.RotateSecretAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<StopReplicationToReplicaResponse> IAmazonSecretsManager.StopReplicationToReplicaAsync( StopReplicationToReplicaRequest request, CancellationToken cancellationToken ) {
		return Manager.StopReplicationToReplicaAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TagResourceResponse> IAmazonSecretsManager.TagResourceAsync( TagResourceRequest request, CancellationToken cancellationToken ) {
		return Manager.TagResourceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UntagResourceResponse> IAmazonSecretsManager.UntagResourceAsync( UntagResourceRequest request, CancellationToken cancellationToken ) {
		return Manager.UntagResourceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateSecretResponse> IAmazonSecretsManager.UpdateSecretAsync( UpdateSecretRequest request, CancellationToken cancellationToken ) {
		return Manager.UpdateSecretAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateSecretVersionStageResponse> IAmazonSecretsManager.UpdateSecretVersionStageAsync( UpdateSecretVersionStageRequest request, CancellationToken cancellationToken ) {
		return Manager.UpdateSecretVersionStageAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ValidateResourcePolicyResponse> IAmazonSecretsManager.ValidateResourcePolicyAsync( ValidateResourcePolicyRequest request, CancellationToken cancellationToken ) {
		return Manager.ValidateResourcePolicyAsync( request, cancellationToken );
	}

}
