namespace InjectableAWS;

public sealed record DynamoDbOptions<T>: IDynamoDbOptions<T> {
	public DynamoDbOptions() {
	}

	public DynamoDbOptions(
		string? regionEndpoint
	) {
		RegionEndpoint = regionEndpoint;
	}

	public DynamoDbOptions(
		string? regionEndpoint,
		string? role
	) {
		RegionEndpoint = regionEndpoint;
		Role = role;
	}

	public DynamoDbOptions(
		string? regionEndpoint,
		string? role,
		string? credentialsProfile
	) {
		RegionEndpoint = regionEndpoint;
		Role = role;
		CredentialsProfile = credentialsProfile;
	}

	public string? RegionEndpoint { get; init; }

	public string? CredentialsProfile { get; init; }

	public string? Role { get; init; }
}
