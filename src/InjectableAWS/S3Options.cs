namespace InjectableAWS {

	public sealed record S3Options<T>(
		string? RegionEndpoint,
		string? CredentialsProfile,
		string? Role
	): IS3Options<T> {
	}
}
