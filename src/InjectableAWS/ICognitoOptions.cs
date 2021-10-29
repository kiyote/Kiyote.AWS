namespace InjectableAWS {
	public interface ICognitoOptions<T> {
		string? ClientId { get; }
		string? RegionEndpoint { get; }
		string? CredentialsProfile { get; }
		string? Role { get; }
	}
}
