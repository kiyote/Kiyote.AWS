namespace InjectableAWS {
	public sealed record DynamoDbOptions<T>(
		string? RegionEndpoint,
		string? CredentialsProfile,
		string? Role
	): IDynamoDbOptions<T> {
	}
}
