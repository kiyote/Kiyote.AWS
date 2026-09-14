namespace Kiyote.AWS.DynamoDb;

public sealed record DynamoDbOptions<T> {

	public string? RegionEndpoint { get; set; }

	public string? CredentialsProfile { get; set; }

	public string? Role { get; set; }
}
