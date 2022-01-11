namespace InjectableAWS;

public sealed record CredentialsOptions: ICredentialsOptions {
	public CredentialsOptions() {
	}

	public CredentialsOptions(
		string credentialsFile
	) {
		CredentialsFile = credentialsFile;
	}

	public string? CredentialsFile { get; init; }
}

