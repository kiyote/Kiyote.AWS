namespace InjectableAWS {

	public sealed record S3Options<T>(
		string? CredentialsProfile,
		string? RegionEndpoint,
		string? Role
	): IS3Options<T> {
	}
}
