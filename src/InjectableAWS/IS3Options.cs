namespace InjectableAWS {
	public interface IS3Options<T> {
		string? CredentialsProfile { get; }
		string? RegionEndpoint { get; }
		string? Role { get; }
	}
}
