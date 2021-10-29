namespace InjectableAWS {
	public interface IDynamoDbOptions<T> {
		string? RegionEndpoint { get; }
		string? CredentialsProfile { get; }
		string? Role { get; }
	}
}
