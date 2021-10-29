namespace InjectableAWS {
	public interface IS3Options<T> {
		string? RegionEndpoint { get; }
		string? CredentialsProfile { get; }
		string? Role { get; }
	}
}
