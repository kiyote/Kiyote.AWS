namespace InjectableAWS {
	public interface IDynamoDbOptions<T> {
		string? CredentialsProfile { get; }
		string? RegionEndpoint { get; }
		string? ServiceUrl { get; }
		string? Role { get; }
	}
}
