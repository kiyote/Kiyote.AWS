namespace Kiyote.AWS.Credentials.UnitTests;

[TestFixture]
internal class CredentialsProviderTests {

	private Mock<IOptions<CredentialsProviderOptions>>? _options;
	private ICredentialsProvider? _provider;

	[SetUp]
	public void SetUp() {
		_options = new Mock<IOptions<CredentialsProviderOptions>>( MockBehavior.Strict );
	}

	[TearDown]
	public void TearDown() {
		_options!.VerifyAll();
	}

	[Test]
	public void Ctor_NullOptions_ThrowsException() {
		Assert.Throws<ArgumentException>( () =>
		new CredentialsProvider(
			new NullOptions<CredentialsProviderOptions>()
		) );
	}

	[Test]
	public void AssumeRole_ValidCredentials_NewCredentialsReturned() {
		ConfigureProvider();
		var credentials = new BasicAWSCredentials(
			"accessKey",
			"secretKey"
		);
		string? role = "role";
		AWSCredentials? assumedCredentials = _provider!.AssumeRole( credentials, role );

		Assert.That( assumedCredentials, Is.AssignableFrom<AssumeRoleAWSCredentials>() );
	}

	private void ConfigureProvider(
		string? credentialsFile = null
	) {
		CredentialsProviderOptions options = new CredentialsProviderOptions {
			CredentialsFile = credentialsFile
		};
		_options!
			.Setup( o => o.Value )
			.Returns( options );
		_provider = new CredentialsProvider( _options.Object );
	}
}
