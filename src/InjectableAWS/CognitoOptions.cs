namespace InjectableAWS {
	public sealed record CognitoOptions<T>(
		string? CredentialsProfile,
		string? ClientId,
		string? RegionEndpoint,
		string? ServiceUrl,
		string? Role
	): ICognitoOptions<T> {
	}
}
