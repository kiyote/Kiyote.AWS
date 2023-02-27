namespace InjectableAWS.DynamoDb.Repository;

public record DynamoDbRepositoryOptions(
	string TableName,
	string IndexName
);

