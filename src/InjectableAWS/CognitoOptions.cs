namespace InjectableAWS {
	public sealed record CognitoOptions<T>(
		string? ClientId,
		string? RegionEndpoint,
		string? CredentialsProfile,
		string? Role
	): ICognitoOptions<T> {
	}
}
