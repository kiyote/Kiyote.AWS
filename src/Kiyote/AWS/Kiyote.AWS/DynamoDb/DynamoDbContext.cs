using System.Diagnostics.CodeAnalysis;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace Kiyote.AWS.DynamoDb;

internal sealed class DynamoDbContext<T> : IDynamoDBContext<T> where T: class {

	private bool _disposed;

	public DynamoDbContext(
		IAmazonDynamoDB<T> dynamoDB
	) {
		Context = new DynamoDBContextBuilder().WithDynamoDBClient( () => dynamoDB ).Build();
	}

	public IDynamoDBContext Context { get; }

	public void Dispose() {
		Dispose( true );
		GC.SuppressFinalize( this );
	}

	private void Dispose( bool disposing ) {
		if( _disposed ) {
			return;
		}

		if( disposing ) {
			Context.Dispose();
		}

		_disposed = true;
	}


	[ExcludeFromCodeCoverage]
	IBatchGet<TItem> IDynamoDBContext.CreateBatchGet<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>() {
		return Context.CreateBatchGet<TItem>();
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	IBatchGet<TItem> IDynamoDBContext.CreateBatchGet<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( DynamoDBOperationConfig operationConfig ) {
		return Context.CreateBatchGet<TItem>( operationConfig );
	}

	[ExcludeFromCodeCoverage]
	IBatchGet<TItem> IDynamoDBContext.CreateBatchGet<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( BatchGetConfig batchGetConfig ) {
		return Context.CreateBatchGet<TItem>( batchGetConfig );
	}

	[ExcludeFromCodeCoverage]
	IBatchWrite<TItem> IDynamoDBContext.CreateBatchWrite<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>() {
		return Context.CreateBatchWrite<TItem>();
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	IBatchWrite<TItem> IDynamoDBContext.CreateBatchWrite<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( DynamoDBOperationConfig operationConfig ) {
		return Context.CreateBatchWrite<TItem>( operationConfig );
	}

	[ExcludeFromCodeCoverage]
	IBatchWrite<object> IDynamoDBContext.CreateBatchWrite( Type valuesType ) {
		return Context.CreateBatchWrite( valuesType );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	IBatchWrite<object> IDynamoDBContext.CreateBatchWrite( Type valuesType, DynamoDBOperationConfig operationConfig ) {
		return Context.CreateBatchWrite( valuesType, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	IBatchWrite<TItem> IDynamoDBContext.CreateBatchWrite<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( BatchWriteConfig batchWriteConfig ) {
		return Context.CreateBatchWrite<TItem>( batchWriteConfig );
	}

	[ExcludeFromCodeCoverage]
	IBatchWrite<object> IDynamoDBContext.CreateBatchWrite( Type valuesType, BatchWriteConfig batchWriteConfig ) {
		return Context.CreateBatchWrite( valuesType, batchWriteConfig );
	}

	[ExcludeFromCodeCoverage]
	IMultiTableBatchGet IDynamoDBContext.CreateMultiTableBatchGet( params IBatchGet[] batches ) {
		return Context.CreateMultiTableBatchGet( batches );
	}

	[ExcludeFromCodeCoverage]
	IMultiTableBatchWrite IDynamoDBContext.CreateMultiTableBatchWrite( params IBatchWrite[] batches ) {
		return Context.CreateMultiTableBatchWrite( batches );
	}

	[ExcludeFromCodeCoverage]
	IMultiTableTransactGet IDynamoDBContext.CreateMultiTableTransactGet( params ITransactGet[] transactionParts ) {
		return Context.CreateMultiTableTransactGet( transactionParts );
	}

	[ExcludeFromCodeCoverage]
	IMultiTableTransactWrite IDynamoDBContext.CreateMultiTableTransactWrite( params ITransactWrite[] transactionParts ) {
		return Context.CreateMultiTableTransactWrite( transactionParts );
	}

	[ExcludeFromCodeCoverage]
	ITransactGet<TItem> IDynamoDBContext.CreateTransactGet<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>() {
		return Context.CreateTransactGet<TItem>();
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	ITransactGet<TItem> IDynamoDBContext.CreateTransactGet<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( DynamoDBOperationConfig operationConfig ) {
		return Context.CreateTransactGet<TItem>( operationConfig );
	}

	[ExcludeFromCodeCoverage]
	ITransactGet<TItem> IDynamoDBContext.CreateTransactGet<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TransactGetConfig transactGetConfig ) {
		return Context.CreateTransactGet<TItem>( transactGetConfig );
	}

	[ExcludeFromCodeCoverage]
	ITransactWrite<TItem> IDynamoDBContext.CreateTransactWrite<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>() {
		return Context.CreateTransactWrite<TItem>();
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	ITransactWrite<TItem> IDynamoDBContext.CreateTransactWrite<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( DynamoDBOperationConfig operationConfig ) {
		return Context.CreateTransactWrite<TItem>( operationConfig );
	}

	[ExcludeFromCodeCoverage]
	ITransactWrite<TItem> IDynamoDBContext.CreateTransactWrite<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TransactWriteConfig transactWriteConfig ) {
		return Context.CreateTransactWrite<TItem>( transactWriteConfig );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.DeleteAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TItem value, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( value, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	Task IDynamoDBContext.DeleteAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TItem value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( value, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.DeleteAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TItem value, DeleteConfig deleteConfig, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( value, deleteConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.DeleteAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKey, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( hashKey, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	Task IDynamoDBContext.DeleteAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( hashKey, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.DeleteAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKey, DeleteConfig deleteConfig, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( hashKey, deleteConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.DeleteAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKey, object rangeKey, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( hashKey, rangeKey, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	Task IDynamoDBContext.DeleteAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( hashKey, rangeKey, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.DeleteAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKey, object rangeKey, DeleteConfig deleteConfig, CancellationToken cancellationToken ) {
		return Context.DeleteAsync<TItem>( hashKey, rangeKey, deleteConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.ExecuteBatchGetAsync( params IBatchGet[] batches ) {
		return Context.ExecuteBatchGetAsync( batches );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.ExecuteBatchGetAsync( IBatchGet[] batches, CancellationToken cancellationToken ) {
		return Context.ExecuteBatchGetAsync( batches, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.ExecuteBatchWriteAsync( IBatchWrite[] batches, CancellationToken cancellationToken ) {
		return Context.ExecuteBatchWriteAsync( batches, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.ExecuteTransactGetAsync( ITransactGet[] transactionParts, CancellationToken cancellationToken ) {
		return Context.ExecuteTransactGetAsync( transactionParts, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.ExecuteTransactWriteAsync( ITransactWrite[] transactionParts, CancellationToken cancellationToken ) {
		return Context.ExecuteTransactWriteAsync( transactionParts, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	TItem IDynamoDBContext.FromDocument<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( Document document ) {
		return Context.FromDocument<TItem>( document );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	TItem IDynamoDBContext.FromDocument<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( Document document, DynamoDBOperationConfig operationConfig ) {
		return Context.FromDocument<TItem>( document, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	TItem IDynamoDBContext.FromDocument<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( Document document, FromDocumentConfig fromDocumentConfig ) {
		return Context.FromDocument<TItem>( document, fromDocumentConfig );
	}

	[ExcludeFromCodeCoverage]
	IEnumerable<TItem> IDynamoDBContext.FromDocuments<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( IEnumerable<Document> documents ) {
		return Context.FromDocuments<TItem>( documents );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	IEnumerable<TItem> IDynamoDBContext.FromDocuments<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( IEnumerable<Document> documents, DynamoDBOperationConfig operationConfig ) {
		return Context.FromDocuments<TItem>( documents, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	IEnumerable<TItem> IDynamoDBContext.FromDocuments<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( IEnumerable<Document> documents, FromDocumentConfig fromDocumentConfig ) {
		return Context.FromDocuments<TItem>( documents, fromDocumentConfig );
	}

	[ExcludeFromCodeCoverage]
	IAsyncSearch<TItem> IDynamoDBContext.FromQueryAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( QueryOperationConfig queryConfig ) {
		return Context.FromQueryAsync<TItem>( queryConfig );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	IAsyncSearch<TItem> IDynamoDBContext.FromQueryAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( QueryOperationConfig queryConfig, DynamoDBOperationConfig operationConfig ) {
		return Context.FromQueryAsync<TItem>( queryConfig, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	IAsyncSearch<TItem> IDynamoDBContext.FromQueryAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( QueryOperationConfig queryConfig, FromQueryConfig fromQueryConfig ) {
		return Context.FromQueryAsync<TItem>( queryConfig, fromQueryConfig );
	}

	[ExcludeFromCodeCoverage]
	IAsyncSearch<TItem> IDynamoDBContext.FromScanAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( ScanOperationConfig scanConfig ) {
		return Context.FromScanAsync<TItem>( scanConfig );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	IAsyncSearch<TItem> IDynamoDBContext.FromScanAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( ScanOperationConfig scanConfig, DynamoDBOperationConfig operationConfig ) {
		return Context.FromScanAsync<TItem>( scanConfig, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	IAsyncSearch<TItem> IDynamoDBContext.FromScanAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( ScanOperationConfig scanConfig, FromScanConfig fromScanConfig ) {
		return Context.FromScanAsync<TItem>( scanConfig, fromScanConfig );
	}

	[ExcludeFromCodeCoverage]
	ITable IDynamoDBContext.GetTargetTable<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>() {
		return Context.GetTargetTable<TItem>();
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	ITable IDynamoDBContext.GetTargetTable<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( DynamoDBOperationConfig operationConfig ) {
		return Context.GetTargetTable<TItem>( operationConfig );
	}

	[ExcludeFromCodeCoverage]
	ITable IDynamoDBContext.GetTargetTable<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( GetTargetTableConfig getTargetTableConfig ) {
		return Context.GetTargetTable<TItem>( getTargetTableConfig );
	}

	[ExcludeFromCodeCoverage]
	Task<TItem> IDynamoDBContext.LoadAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKey, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( hashKey, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	Task<TItem> IDynamoDBContext.LoadAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( hashKey, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TItem> IDynamoDBContext.LoadAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKey, LoadConfig loadConfig, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( hashKey, loadConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TItem> IDynamoDBContext.LoadAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKey, object rangeKey, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( hashKey, rangeKey, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	Task<TItem> IDynamoDBContext.LoadAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKey, object rangeKey, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( hashKey, rangeKey, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TItem> IDynamoDBContext.LoadAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKey, object rangeKey, LoadConfig loadConfig, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( hashKey, rangeKey, loadConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TItem> IDynamoDBContext.LoadAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TItem keyObject, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( keyObject, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	Task<TItem> IDynamoDBContext.LoadAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TItem keyObject, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( keyObject, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TItem> IDynamoDBContext.LoadAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TItem keyObject, LoadConfig loadConfig, CancellationToken cancellationToken ) {
		return Context.LoadAsync<TItem>( keyObject, loadConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	IAsyncSearch<TItem> IDynamoDBContext.QueryAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKeyValue ) {
		return Context.QueryAsync<TItem>( hashKeyValue );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	IAsyncSearch<TItem> IDynamoDBContext.QueryAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKeyValue, DynamoDBOperationConfig operationConfig ) {
		return Context.QueryAsync<TItem>( hashKeyValue, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	IAsyncSearch<TItem> IDynamoDBContext.QueryAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKeyValue, QueryConfig queryConfig ) {
		return Context.QueryAsync<TItem>( hashKeyValue, queryConfig );
	}

	[ExcludeFromCodeCoverage]
	IAsyncSearch<TItem> IDynamoDBContext.QueryAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKeyValue, QueryOperator op, IEnumerable<object> values ) {
		return Context.QueryAsync<TItem>( hashKeyValue, op, values );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	IAsyncSearch<TItem> IDynamoDBContext.QueryAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKeyValue, QueryOperator op, IEnumerable<object> values, DynamoDBOperationConfig operationConfig ) {
		return Context.QueryAsync<TItem>( hashKeyValue, op, values, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	IAsyncSearch<TItem> IDynamoDBContext.QueryAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( object hashKeyValue, QueryOperator op, IEnumerable<object> values, QueryConfig queryConfig ) {
		return Context.QueryAsync<TItem>( hashKeyValue, op, values, queryConfig );
	}

	[ExcludeFromCodeCoverage]
	void IDynamoDBContext.RegisterTableDefinition( Table table ) {
		Context.RegisterTableDefinition( table );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.SaveAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TItem value, CancellationToken cancellationToken ) {
		return Context.SaveAsync<TItem>( value, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	Task IDynamoDBContext.SaveAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TItem value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.SaveAsync<TItem>( value, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.SaveAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TItem value, SaveConfig saveConfig, CancellationToken cancellationToken ) {
		return Context.SaveAsync<TItem>( value, saveConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.SaveAsync( Type valueType, object value, CancellationToken cancellationToken ) {
		return Context.SaveAsync( valueType, value, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	Task IDynamoDBContext.SaveAsync( Type valueType, object value, DynamoDBOperationConfig operationConfig, CancellationToken cancellationToken ) {
		return Context.SaveAsync( valueType, value, operationConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task IDynamoDBContext.SaveAsync( Type valueType, object value, SaveConfig saveConfig, CancellationToken cancellationToken ) {
		return Context.SaveAsync( valueType, value, saveConfig, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	IAsyncSearch<TItem> IDynamoDBContext.ScanAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( IEnumerable<ScanCondition> conditions ) {
		return Context.ScanAsync<TItem>( conditions );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	IAsyncSearch<TItem> IDynamoDBContext.ScanAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( IEnumerable<ScanCondition> conditions, DynamoDBOperationConfig operationConfig ) {
		return Context.ScanAsync<TItem>( conditions, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	IAsyncSearch<TItem> IDynamoDBContext.ScanAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( IEnumerable<ScanCondition> conditions, ScanConfig scanConfig ) {
		return Context.ScanAsync<TItem>( conditions, scanConfig );
	}

	[ExcludeFromCodeCoverage]
	Document IDynamoDBContext.ToDocument<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TItem value ) {
		return Context.ToDocument<TItem>( value );
	}

	[ExcludeFromCodeCoverage]
	[Obsolete]
	Document IDynamoDBContext.ToDocument<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TItem value, DynamoDBOperationConfig operationConfig ) {
		return Context.ToDocument<TItem>( value, operationConfig );
	}

	[ExcludeFromCodeCoverage]
	Document IDynamoDBContext.ToDocument<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( TItem value, ToDocumentConfig toDocumentConfig ) {
		return Context.ToDocument<TItem>( value, toDocumentConfig );
	}

	[ExcludeFromCodeCoverage]
	IAsyncSearch<TItem> IDynamoDBContext.ScanAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( ContextExpression filterExpression ) {
		return Context.ScanAsync<TItem>( filterExpression );
	}

	[ExcludeFromCodeCoverage]
	IAsyncSearch<TItem> IDynamoDBContext.ScanAsync<[DynamicallyAccessedMembers( (DynamicallyAccessedMemberTypes)( -1 ) )] TItem>( ContextExpression filterExpression, ScanConfig scanConfig ) {
		return Context.ScanAsync<TItem>( filterExpression, scanConfig );
	}
}
