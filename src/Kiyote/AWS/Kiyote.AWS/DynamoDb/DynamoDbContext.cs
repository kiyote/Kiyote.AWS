using System.Diagnostics.CodeAnalysis;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace Kiyote.AWS.DynamoDb;

internal sealed partial class DynamoDbContextContext<T> {

	[ExcludeFromCodeCoverage]
	BatchGet<TItem> IDynamoDBContext.CreateBatchGet<TItem>( DynamoDBOperationConfig operationConfig ) {
		return Context.CreateBatchGet<TItem>( operationConfig );
	}

	[ExcludeFromCodeCoverage]
	BatchWrite<TItem> IDynamoDBContext.CreateBatchWrite<TItem>( DynamoDBOperationConfig operationConfig ) {
		return Context.CreateBatchWrite<TItem>( operationConfig );
	}

	[ExcludeFromCodeCoverage]
	BatchWrite<object> IDynamoDBContext.CreateBatchWrite( Type valuesType, DynamoDBOperationConfig operationConfig ) {
		return Context.CreateBatchWrite( valuesType, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	MultiTableBatchGet IDynamoDBContext.CreateMultiTableBatchGet( params BatchGet[] batches ) {
		return Context.CreateMultiTableBatchGet( batches);
	}

	[ExcludeFromCodeCoverage]
	MultiTableBatchWrite IDynamoDBContext.CreateMultiTableBatchWrite( params BatchWrite[] batches ) {
		return Context.CreateMultiTableBatchWrite( batches );
	}

	[ExcludeFromCodeCoverage]
	MultiTableTransactGet IDynamoDBContext.CreateMultiTableTransactGet( params TransactGet[] transactionParts ) {
		return Context.CreateMultiTableTransactGet( transactionParts );
	}

	[ExcludeFromCodeCoverage]
	MultiTableTransactWrite IDynamoDBContext.CreateMultiTableTransactWrite( params TransactWrite[] transactionParts ) {
		return Context.CreateMultiTableTransactWrite( transactionParts );
	}

	[ExcludeFromCodeCoverage]
	TransactGet<TItem> IDynamoDBContext.CreateTransactGet<TItem>( DynamoDBOperationConfig operationConfig ) {
		return Context.CreateTransactGet<TItem>( operationConfig );
	}

	[ExcludeFromCodeCoverage]
	TransactWrite<TItem> IDynamoDBContext.CreateTransactWrite<TItem>( DynamoDBOperationConfig operationConfig ) {
		return Context.CreateTransactWrite<TItem>( operationConfig );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.DeleteAsync<TItem>( TItem value, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( value, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.DeleteAsync<TItem>( TItem value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( value, operationConfig, cancellationToken);
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.DeleteAsync<TItem>( object hashKey, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( hashKey, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.DeleteAsync<TItem>( object hashKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( hashKey, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.DeleteAsync<TItem>( object hashKey, object rangeKey, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( hashKey, rangeKey, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.DeleteAsync<TItem>( object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( hashKey, rangeKey, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.ExecuteBatchGetAsync( BatchGet[] batches, CancellationToken cancellationToken ) {
		return Context.ExecuteBatchGetAsync( batches, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.ExecuteBatchWriteAsync( BatchWrite[] batches, CancellationToken cancellationToken ) {
		return Context.ExecuteBatchWriteAsync( batches, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.ExecuteTransactGetAsync( TransactGet[] transactionParts, CancellationToken cancellationToken ) {
		return Context.ExecuteTransactGetAsync( transactionParts, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.ExecuteTransactWriteAsync( TransactWrite[] transactionParts, CancellationToken cancellationToken ) {
		return Context.ExecuteTransactWriteAsync( transactionParts, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	TItem IDynamoDBContext.FromDocument<TItem>( Document document ) {
		return Context.FromDocument<TItem>( document );
	}

	[ExcludeFromCodeCoverage]
	TItem IDynamoDBContext.FromDocument<TItem>( Document document, DynamoDBOperationConfig operationConfig ) {
		return Context.FromDocument<TItem>( document, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	IEnumerable<TItem> IDynamoDBContext.FromDocuments<TItem>( IEnumerable<Document> documents ) {
		return Context.FromDocuments<TItem>( documents );
	}

	[ExcludeFromCodeCoverage]
	IEnumerable<TItem> IDynamoDBContext.FromDocuments<TItem>( IEnumerable<Document> documents, DynamoDBOperationConfig operationConfig ) {
		return Context.FromDocuments<TItem>( documents, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	AsyncSearch<TItem> IDynamoDBContext.FromQueryAsync<TItem>( QueryOperationConfig queryConfig, DynamoDBOperationConfig operationConfig ) {
		return Context.FromQueryAsync<TItem>( queryConfig, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	AsyncSearch<TItem> IDynamoDBContext.FromScanAsync<TItem>( ScanOperationConfig scanConfig, DynamoDBOperationConfig operationConfig ) {
		return Context.FromScanAsync<TItem>( scanConfig, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	Table IDynamoDBContext.GetTargetTable<TItem>( DynamoDBOperationConfig operationConfig ) {
		return Context.GetTargetTable<TItem>( operationConfig );
	}

	[ExcludeFromCodeCoverage]
	Task<TItem> IDynamoDBContext.LoadAsync<TItem>( object hashKey, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( hashKey, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TItem> IDynamoDBContext.LoadAsync<TItem>( object hashKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( hashKey, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TItem> IDynamoDBContext.LoadAsync<TItem>( object hashKey, object rangeKey, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( hashKey, rangeKey, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TItem> IDynamoDBContext.LoadAsync<TItem>( object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( hashKey, rangeKey, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TItem> IDynamoDBContext.LoadAsync<TItem>( TItem keyObject, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( keyObject, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TItem> IDynamoDBContext.LoadAsync<TItem>( TItem keyObject, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( keyObject, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	AsyncSearch<TItem> IDynamoDBContext.QueryAsync<TItem>( object hashKeyValue, DynamoDBOperationConfig operationConfig ) {
		return Context.QueryAsync<TItem>( operationConfig );
	}

	[ExcludeFromCodeCoverage]
	AsyncSearch<TItem> IDynamoDBContext.QueryAsync<TItem>( object hashKeyValue, QueryOperator op, IEnumerable<object> values, DynamoDBOperationConfig operationConfig ) {
		return Context.QueryAsync<TItem>( operationConfig );
	}

	[ExcludeFromCodeCoverage]
	void IDynamoDBContext.RegisterTableDefinition( Table table ) {
		Context.RegisterTableDefinition( table );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.SaveAsync<TItem>( TItem value, CancellationToken cancellationToken ) {
		return Context.SaveAsync<TItem>( value, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.SaveAsync<TItem>( TItem value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.SaveAsync<TItem>( value, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.SaveAsync( Type valueType, object value, CancellationToken cancellationToken ) {
		return Context.SaveAsync( valueType, value, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.SaveAsync( Type valueType, object value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.SaveAsync( valueType, value, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	AsyncSearch<TItem> IDynamoDBContext.ScanAsync<TItem>( IEnumerable<ScanCondition> conditions, DynamoDBOperationConfig operationConfig ) {
		return Context.ScanAsync<TItem>( conditions, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	Document IDynamoDBContext.ToDocument<TItem>( TItem value ) {
		return Context.ToDocument<TItem>( value );
	}

	[ExcludeFromCodeCoverage]
	Document IDynamoDBContext.ToDocument<TItem>( TItem value, DynamoDBOperationConfig operationConfig ) {
		return Context.ToDocument<TItem>( value, operationConfig );
	}
}
