using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace InjectableAWS.DynamoDb.Repository;

public abstract class DynamoDbRepository<T> : IDynamoDbRepository<T> where T : DynamoDbRepositoryOptions {
	private readonly DynamoDbContext<T> _context;
	private readonly DynamoDBOperationConfig _config;
	private readonly DynamoDBOperationConfig _searchConfig;

	protected DynamoDbRepository(
		T options,
		DynamoDbContext<T> context
	) {
		if( options is null ) {
			throw new ArgumentNullException( nameof( options ) );
		}

		_context = context;
		_config = new DynamoDBOperationConfig {
			OverrideTableName = options.TableName
		};
		_searchConfig = new DynamoDBOperationConfig {
			OverrideTableName = options.TableName,
			IndexName = options.IndexName
		};
	}

	public async Task CreateAsync<TData>(
		TData data,
		CancellationToken cancellationToken
	) {
		await _context.Context
			.SaveAsync(
				data,
				_config,
				cancellationToken
			).ConfigureAwait( false );
	}

	public async Task<TData?> LoadAsync<TData>(
		string pk,
		string sk,
		CancellationToken cancellationToken
	) {
		return await _context.Context
			.LoadAsync<TData?>(
				pk,
				sk,
				_config,
				cancellationToken
			).ConfigureAwait( false );
	}

	public Task<IEnumerable<TData>> QueryPrefixAsync<TData>(
		string pk,
		string prefix,
		CancellationToken cancellationToken
	) {
		return QueryPrefixAsync<TData>(
			pk,
			new List<string>() { prefix },
			cancellationToken
		);
	}

	public async Task<IEnumerable<TData>> QueryPrefixAsync<TData>(
		string pk,
		IEnumerable<string> prefixes,
		CancellationToken cancellationToken
	) {
		AsyncSearch<TData>? results = _context.Context
			.QueryAsync<TData>(
				pk,
				QueryOperator.BeginsWith,
				prefixes,
				_config
			);

		if( results is null ) {
			return Enumerable.Empty<TData>();
		}

		return await results
			.GetRemainingAsync( cancellationToken )
			.ConfigureAwait( false );
	}
}
