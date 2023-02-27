namespace InjectableAWS.S3;

public sealed record S3Options<T> {

	public string? RegionEndpoint { get; set; }

	public string? CredentialsProfile { get; set; }

	public string? Role { get; set; }

}
