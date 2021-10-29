namespace InjectableAWS {
	public interface ICognitoOptions<T> {
		string? CredentialsProfile { get; }
		string? ClientId { get; }
		string? RegionEndpoint { get; }
		string? ServiceUrl { get; }
		string? Role { get; }
	}
}
