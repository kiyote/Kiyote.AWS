namespace InjectableAWS {

	public sealed record S3Options<T>: IS3Options<T> {
		public S3Options() {
		}

		public S3Options(
			string? regionEndpoint
		) {
			RegionEndpoint = regionEndpoint;
		}

		public S3Options(
			string? regionEndpoint,
			string? role
		) {
			RegionEndpoint = regionEndpoint;
			Role = role;
		}

		public S3Options(
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
}
