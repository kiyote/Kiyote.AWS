using System.Diagnostics.CodeAnalysis;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;

namespace Kiyote.AWS.DynamoDb;

internal sealed partial class AmazonDynamoDbContext<T> {

	[ExcludeFromCodeCoverage]
	IDynamoDBv2PaginatorFactory IAmazonDynamoDB.Paginators => Client.Paginators;

	[ExcludeFromCodeCoverage]
	IClientConfig IAmazonService.Config => Client.Config;


	[ExcludeFromCodeCoverage]
	Task<BatchExecuteStatementResponse> IAmazonDynamoDB.BatchExecuteStatementAsync( BatchExecuteStatementRequest request, CancellationToken cancellationToken ) {
		return Client.BatchExecuteStatementAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<BatchGetItemResponse> IAmazonDynamoDB.BatchGetItemAsync( Dictionary<string, KeysAndAttributes> requestItems, ReturnConsumedCapacity returnConsumedCapacity, CancellationToken cancellationToken ) {
		return Client.BatchGetItemAsync( requestItems, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<BatchGetItemResponse> IAmazonDynamoDB.BatchGetItemAsync( Dictionary<string, KeysAndAttributes> requestItems, CancellationToken cancellationToken ) {
		return Client.BatchGetItemAsync( requestItems, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<BatchGetItemResponse> IAmazonDynamoDB.BatchGetItemAsync( BatchGetItemRequest request, CancellationToken cancellationToken ) {
		return Client.BatchGetItemAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<BatchWriteItemResponse> IAmazonDynamoDB.BatchWriteItemAsync( Dictionary<string, List<WriteRequest>> requestItems, CancellationToken cancellationToken ) {
		return Client.BatchWriteItemAsync( requestItems, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<BatchWriteItemResponse> IAmazonDynamoDB.BatchWriteItemAsync( BatchWriteItemRequest request, CancellationToken cancellationToken ) {
		return Client.BatchWriteItemAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateBackupResponse> IAmazonDynamoDB.CreateBackupAsync( CreateBackupRequest request, CancellationToken cancellationToken ) {
		return Client.CreateBackupAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateGlobalTableResponse> IAmazonDynamoDB.CreateGlobalTableAsync( CreateGlobalTableRequest request, CancellationToken cancellationToken ) {
		return Client.CreateGlobalTableAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateTableResponse> IAmazonDynamoDB.CreateTableAsync( string tableName, List<KeySchemaElement> keySchema, List<AttributeDefinition> attributeDefinitions, ProvisionedThroughput provisionedThroughput, CancellationToken cancellationToken ) {
		return Client.CreateTableAsync( tableName, keySchema, attributeDefinitions, provisionedThroughput, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateTableResponse> IAmazonDynamoDB.CreateTableAsync( CreateTableRequest request, CancellationToken cancellationToken ) {
		return Client.CreateTableAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteBackupResponse> IAmazonDynamoDB.DeleteBackupAsync( DeleteBackupRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteBackupAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteItemResponse> IAmazonDynamoDB.DeleteItemAsync( string tableName, Dictionary<string, AttributeValue> key, CancellationToken cancellationToken ) {
		return Client.DeleteItemAsync( tableName, key, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteItemResponse> IAmazonDynamoDB.DeleteItemAsync( string tableName, Dictionary<string, AttributeValue> key, ReturnValue returnValues, CancellationToken cancellationToken ) {
		return Client.DeleteItemAsync( tableName, key, returnValues, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteItemResponse> IAmazonDynamoDB.DeleteItemAsync( DeleteItemRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteItemAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteTableResponse> IAmazonDynamoDB.DeleteTableAsync( string tableName, CancellationToken cancellationToken ) {
		return Client.DeleteTableAsync( tableName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteTableResponse> IAmazonDynamoDB.DeleteTableAsync( DeleteTableRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteTableAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeBackupResponse> IAmazonDynamoDB.DescribeBackupAsync( DescribeBackupRequest request, CancellationToken cancellationToken ) {
		return Client.DescribeBackupAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeContinuousBackupsResponse> IAmazonDynamoDB.DescribeContinuousBackupsAsync( DescribeContinuousBackupsRequest request, CancellationToken cancellationToken ) {
		return Client.DescribeContinuousBackupsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeContributorInsightsResponse> IAmazonDynamoDB.DescribeContributorInsightsAsync( DescribeContributorInsightsRequest request, CancellationToken cancellationToken ) {
		return Client.DescribeContributorInsightsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeEndpointsResponse> IAmazonDynamoDB.DescribeEndpointsAsync( DescribeEndpointsRequest request, CancellationToken cancellationToken ) {
		return Client.DescribeEndpointsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeExportResponse> IAmazonDynamoDB.DescribeExportAsync( DescribeExportRequest request, CancellationToken cancellationToken ) {
		return Client.DescribeExportAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeGlobalTableResponse> IAmazonDynamoDB.DescribeGlobalTableAsync( DescribeGlobalTableRequest request, CancellationToken cancellationToken ) {
		return Client.DescribeGlobalTableAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeGlobalTableSettingsResponse> IAmazonDynamoDB.DescribeGlobalTableSettingsAsync( DescribeGlobalTableSettingsRequest request, CancellationToken cancellationToken ) {
		return Client.DescribeGlobalTableSettingsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeImportResponse> IAmazonDynamoDB.DescribeImportAsync( DescribeImportRequest request, CancellationToken cancellationToken ) {
		return Client.DescribeImportAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeKinesisStreamingDestinationResponse> IAmazonDynamoDB.DescribeKinesisStreamingDestinationAsync( DescribeKinesisStreamingDestinationRequest request, CancellationToken cancellationToken ) {
		return Client.DescribeKinesisStreamingDestinationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeLimitsResponse> IAmazonDynamoDB.DescribeLimitsAsync( DescribeLimitsRequest request, CancellationToken cancellationToken ) {
		return Client.DescribeLimitsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeTableResponse> IAmazonDynamoDB.DescribeTableAsync( string tableName, CancellationToken cancellationToken ) {
		return Client.DescribeTableAsync( tableName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeTableResponse> IAmazonDynamoDB.DescribeTableAsync( DescribeTableRequest request, CancellationToken cancellationToken ) {
		return Client.DescribeTableAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeTableReplicaAutoScalingResponse> IAmazonDynamoDB.DescribeTableReplicaAutoScalingAsync( DescribeTableReplicaAutoScalingRequest request, CancellationToken cancellationToken ) {
		return Client.DescribeTableReplicaAutoScalingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeTimeToLiveResponse> IAmazonDynamoDB.DescribeTimeToLiveAsync( string tableName, CancellationToken cancellationToken ) {
		return Client.DescribeTimeToLiveAsync( tableName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeTimeToLiveResponse> IAmazonDynamoDB.DescribeTimeToLiveAsync( DescribeTimeToLiveRequest request, CancellationToken cancellationToken ) {
		return Client.DescribeTimeToLiveAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Amazon.Runtime.Endpoints.Endpoint IAmazonDynamoDB.DetermineServiceOperationEndpoint( AmazonWebServiceRequest request ) {
		return Client.DetermineServiceOperationEndpoint( request );
	}

	[ExcludeFromCodeCoverage]
	Task<DisableKinesisStreamingDestinationResponse> IAmazonDynamoDB.DisableKinesisStreamingDestinationAsync( DisableKinesisStreamingDestinationRequest request, CancellationToken cancellationToken ) {
		return Client.DisableKinesisStreamingDestinationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<EnableKinesisStreamingDestinationResponse> IAmazonDynamoDB.EnableKinesisStreamingDestinationAsync( EnableKinesisStreamingDestinationRequest request, CancellationToken cancellationToken ) {
		return Client.EnableKinesisStreamingDestinationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ExecuteStatementResponse> IAmazonDynamoDB.ExecuteStatementAsync( ExecuteStatementRequest request, CancellationToken cancellationToken ) {
		return Client.ExecuteStatementAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ExecuteTransactionResponse> IAmazonDynamoDB.ExecuteTransactionAsync( ExecuteTransactionRequest request, CancellationToken cancellationToken ) {
		return Client.ExecuteTransactionAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ExportTableToPointInTimeResponse> IAmazonDynamoDB.ExportTableToPointInTimeAsync( ExportTableToPointInTimeRequest request, CancellationToken cancellationToken ) {
		return Client.ExportTableToPointInTimeAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetItemResponse> IAmazonDynamoDB.GetItemAsync( string tableName, Dictionary<string, AttributeValue> key, CancellationToken cancellationToken ) {
		return Client.GetItemAsync( tableName, key, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetItemResponse> IAmazonDynamoDB.GetItemAsync( string tableName, Dictionary<string, AttributeValue> key, bool consistentRead, CancellationToken cancellationToken ) {
		return Client.GetItemAsync( tableName, key, consistentRead, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetItemResponse> IAmazonDynamoDB.GetItemAsync( GetItemRequest request, CancellationToken cancellationToken ) {
		return Client.GetItemAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ImportTableResponse> IAmazonDynamoDB.ImportTableAsync( ImportTableRequest request, CancellationToken cancellationToken ) {
		return Client.ImportTableAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListBackupsResponse> IAmazonDynamoDB.ListBackupsAsync( ListBackupsRequest request, CancellationToken cancellationToken ) {
		return Client.ListBackupsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListContributorInsightsResponse> IAmazonDynamoDB.ListContributorInsightsAsync( ListContributorInsightsRequest request, CancellationToken cancellationToken ) {
		return Client.ListContributorInsightsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListExportsResponse> IAmazonDynamoDB.ListExportsAsync( ListExportsRequest request, CancellationToken cancellationToken ) {
		return Client.ListExportsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListGlobalTablesResponse> IAmazonDynamoDB.ListGlobalTablesAsync( ListGlobalTablesRequest request, CancellationToken cancellationToken ) {
		return Client.ListGlobalTablesAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListImportsResponse> IAmazonDynamoDB.ListImportsAsync( ListImportsRequest request, CancellationToken cancellationToken ) {
		return Client.ListImportsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListTablesResponse> IAmazonDynamoDB.ListTablesAsync( CancellationToken cancellationToken ) {
		return Client.ListTablesAsync( cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListTablesResponse> IAmazonDynamoDB.ListTablesAsync( string exclusiveStartTableName, CancellationToken cancellationToken ) {
		return Client.ListTablesAsync( exclusiveStartTableName, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListTablesResponse> IAmazonDynamoDB.ListTablesAsync( string exclusiveStartTableName, int limit, CancellationToken cancellationToken ) {
		return Client.ListTablesAsync( exclusiveStartTableName, limit, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListTablesResponse> IAmazonDynamoDB.ListTablesAsync( int limit, CancellationToken cancellationToken ) {
		return Client.ListTablesAsync( limit, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListTablesResponse> IAmazonDynamoDB.ListTablesAsync( ListTablesRequest request, CancellationToken cancellationToken ) {
		return Client.ListTablesAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListTagsOfResourceResponse> IAmazonDynamoDB.ListTagsOfResourceAsync( ListTagsOfResourceRequest request, CancellationToken cancellationToken ) {
		return Client.ListTagsOfResourceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutItemResponse> IAmazonDynamoDB.PutItemAsync( string tableName, Dictionary<string, AttributeValue> item, CancellationToken cancellationToken ) {
		return Client.PutItemAsync( tableName, item, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutItemResponse> IAmazonDynamoDB.PutItemAsync( string tableName, Dictionary<string, AttributeValue> item, ReturnValue returnValues, CancellationToken cancellationToken ) {
		return Client.PutItemAsync( tableName, item, returnValues, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<PutItemResponse> IAmazonDynamoDB.PutItemAsync( PutItemRequest request, CancellationToken cancellationToken ) {
		return Client.PutItemAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<QueryResponse> IAmazonDynamoDB.QueryAsync( QueryRequest request, CancellationToken cancellationToken ) {
		return Client.QueryAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<RestoreTableFromBackupResponse> IAmazonDynamoDB.RestoreTableFromBackupAsync( RestoreTableFromBackupRequest request, CancellationToken cancellationToken ) {
		return Client.RestoreTableFromBackupAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<RestoreTableToPointInTimeResponse> IAmazonDynamoDB.RestoreTableToPointInTimeAsync( RestoreTableToPointInTimeRequest request, CancellationToken cancellationToken ) {
		return Client.RestoreTableToPointInTimeAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ScanResponse> IAmazonDynamoDB.ScanAsync( string tableName, List<string> attributesToGet, CancellationToken cancellationToken ) {
		return Client.ScanAsync( tableName, attributesToGet, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ScanResponse> IAmazonDynamoDB.ScanAsync( string tableName, Dictionary<string, Condition> scanFilter, CancellationToken cancellationToken ) {
		return Client.ScanAsync( tableName, scanFilter, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ScanResponse> IAmazonDynamoDB.ScanAsync( string tableName, List<string> attributesToGet, Dictionary<string, Condition> scanFilter, CancellationToken cancellationToken ) {
		return Client.ScanAsync( tableName, attributesToGet, scanFilter, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ScanResponse> IAmazonDynamoDB.ScanAsync( ScanRequest request, CancellationToken cancellationToken ) {
		return Client.ScanAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TagResourceResponse> IAmazonDynamoDB.TagResourceAsync( TagResourceRequest request, CancellationToken cancellationToken ) {
		return Client.TagResourceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TransactGetItemsResponse> IAmazonDynamoDB.TransactGetItemsAsync( TransactGetItemsRequest request, CancellationToken cancellationToken ) {
		return Client.TransactGetItemsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TransactWriteItemsResponse> IAmazonDynamoDB.TransactWriteItemsAsync( TransactWriteItemsRequest request, CancellationToken cancellationToken ) {
		return Client.TransactWriteItemsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UntagResourceResponse> IAmazonDynamoDB.UntagResourceAsync( UntagResourceRequest request, CancellationToken cancellationToken ) {
		return Client.UntagResourceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateContinuousBackupsResponse> IAmazonDynamoDB.UpdateContinuousBackupsAsync( UpdateContinuousBackupsRequest request, CancellationToken cancellationToken ) {
		return Client.UpdateContinuousBackupsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateContributorInsightsResponse> IAmazonDynamoDB.UpdateContributorInsightsAsync( UpdateContributorInsightsRequest request, CancellationToken cancellationToken ) {
		return Client.UpdateContributorInsightsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateGlobalTableResponse> IAmazonDynamoDB.UpdateGlobalTableAsync( UpdateGlobalTableRequest request, CancellationToken cancellationToken ) {
		return Client.UpdateGlobalTableAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateGlobalTableSettingsResponse> IAmazonDynamoDB.UpdateGlobalTableSettingsAsync( UpdateGlobalTableSettingsRequest request, CancellationToken cancellationToken ) {
		return Client.UpdateGlobalTableSettingsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateItemResponse> IAmazonDynamoDB.UpdateItemAsync( string tableName, Dictionary<string, AttributeValue> key, Dictionary<string, AttributeValueUpdate> attributeUpdates, CancellationToken cancellationToken ) {
		return Client.UpdateItemAsync( tableName, key, attributeUpdates, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateItemResponse> IAmazonDynamoDB.UpdateItemAsync( string tableName, Dictionary<string, AttributeValue> key, Dictionary<string, AttributeValueUpdate> attributeUpdates, ReturnValue returnValues, CancellationToken cancellationToken ) {
		return Client.UpdateItemAsync( tableName, key, attributeUpdates, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateItemResponse> IAmazonDynamoDB.UpdateItemAsync( UpdateItemRequest request, CancellationToken cancellationToken ) {
		return Client.UpdateItemAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateKinesisStreamingDestinationResponse> IAmazonDynamoDB.UpdateKinesisStreamingDestinationAsync( UpdateKinesisStreamingDestinationRequest request, CancellationToken cancellationToken ) {
		return Client.UpdateKinesisStreamingDestinationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateTableResponse> IAmazonDynamoDB.UpdateTableAsync( string tableName, ProvisionedThroughput provisionedThroughput, CancellationToken cancellationToken ) {
		return Client.UpdateTableAsync( tableName, provisionedThroughput, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateTableResponse> IAmazonDynamoDB.UpdateTableAsync( UpdateTableRequest request, CancellationToken cancellationToken ) {
		return Client.UpdateTableAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateTableReplicaAutoScalingResponse> IAmazonDynamoDB.UpdateTableReplicaAutoScalingAsync( UpdateTableReplicaAutoScalingRequest request, CancellationToken cancellationToken ) {
		return Client.UpdateTableReplicaAutoScalingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateTimeToLiveResponse> IAmazonDynamoDB.UpdateTimeToLiveAsync( UpdateTimeToLiveRequest request, CancellationToken cancellationToken ) {
		return Client.UpdateTimeToLiveAsync( request, cancellationToken );
	}

	Task<GetResourcePolicyResponse> IAmazonDynamoDB.GetResourcePolicyAsync( GetResourcePolicyRequest request, CancellationToken cancellationToken ) {
		return Client.GetResourcePolicyAsync( request, cancellationToken );
	}

	Task<PutResourcePolicyResponse> IAmazonDynamoDB.PutResourcePolicyAsync( PutResourcePolicyRequest request, CancellationToken cancellationToken ) {
		return Client.PutResourcePolicyAsync( request, cancellationToken );
	}

	Task<DeleteResourcePolicyResponse> IAmazonDynamoDB.DeleteResourcePolicyAsync( DeleteResourcePolicyRequest request, CancellationToken cancellationToken ) {
		return Client.DeleteResourcePolicyAsync( request, cancellationToken );
	}

}
