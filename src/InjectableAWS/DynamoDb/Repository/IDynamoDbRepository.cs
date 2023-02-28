﻿namespace InjectableAWS.DynamoDb.Repository;

public interface IDynamoDbRepository<T> where T : class {
	Task CreateAsync<TData>(
		TData data,
		CancellationToken cancellationToken
	);

	Task<TData?> LoadAsync<TData>(
		string pk,
		string sk,
		CancellationToken cancellationToken
	);

	Task<IEnumerable<TData>> QueryPrefixAsync<TData>(
		string pk,
		IEnumerable<string> prefixes,
		CancellationToken cancellationToken
	);

	Task<IEnumerable<TData>> QueryPrefixAsync<TData>(
		string pk,
		string prefix,
		CancellationToken cancellationToken
	);
}
