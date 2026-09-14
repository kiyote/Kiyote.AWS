namespace Kiyote.AWS.SecretsManager;

public sealed record SecretsManagerOptions<T> where T: class {

	public string? RegionEndpoint { get; set; }

	public string? CredentialsProfile { get; set; }

	public string? Role { get; set; }

}
