namespace InjectableAWS.DynamoDb.Repository;

public sealed record DynamoDbRepositoryOptions<T> {
	public string? TableName { get; init; }
	public string? IndexName { get; init; }
}

