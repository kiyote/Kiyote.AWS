namespace InjectableAWS {
	public sealed record DynamoDbOptions<T>(
		string? CredentialsProfile,
		string? RegionEndpoint,
		string? ServiceUrl,
		string? Role
	): IDynamoDbOptions<T> {
	}
}
