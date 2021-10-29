namespace InjectableAWS {
	public sealed record CredentialsOptions(
		string? CredentialsFile
	): ICredentialsOptions { }
}
