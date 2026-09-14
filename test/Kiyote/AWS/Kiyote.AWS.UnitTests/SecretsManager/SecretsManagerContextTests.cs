using Kiyote.AWS.Credentials;

namespace Kiyote.AWS.SecretsManager.UnitTests;

[TestFixture]
public sealed class SecretsManagerContextTests {

	private Mock<ICredentialsProvider>? _credentialsProvider;
	private Mock<IOptions<SecretsManagerOptions<SecretsManagerContextTests>>>? _options;
	private AmazonSecretsManager<SecretsManagerContextTests>? _context;

	[SetUp]
	public void SetUp() {
		_credentialsProvider = new Mock<ICredentialsProvider>( MockBehavior.Strict );
		_options = new Mock<IOptions<SecretsManagerOptions<SecretsManagerContextTests>>>( MockBehavior.Strict );
	}

	[TearDown]
	public void TearDown() {
		_credentialsProvider?.VerifyAll();
		_options?.VerifyAll();

		_context?.Dispose();
		_context = null;
	}

	[Test]
	public void Ctor_UseProfileAndRegion_ContextWithAssumedRoleCreated() {
		string profile = "profile";
		string role = "role";
		string region = "us-east-1";
		BasicAWSCredentials creds1 = new BasicAWSCredentials( "1", "1" );
		_credentialsProvider!
			.Setup( cp => cp.GetCredentials( profile ) )
			.Returns( creds1 );
		BasicAWSCredentials creds2 = new BasicAWSCredentials( "2", "2" );
		_credentialsProvider!
			.Setup( cp => cp.AssumeRole( creds1, role ) )
			.Returns( creds2 );

		SetupContext(
			credentialsProfile: profile,
			regionEndpoint: region,
			role: role
		);

		Assert.That( _context!.Manager, Is.Not.Null );
	}

	[Test]
	public void Ctor_DefaultCredentials_ProviderCreated() {

		BasicAWSCredentials credentials = new BasicAWSCredentials( "accessKey", "secretKey" ) {
		};
		AWSConfigs.AWSRegion = "us-east-1";
		_credentialsProvider!
			.Setup( cp => cp.GetCredentials( null ) )
			.Returns( credentials );

		SetupContext();

		Assert.That( _context!.Manager, Is.Not.Null );
	}

	private void SetupContext(
		string? regionEndpoint = null,
		string? credentialsProfile = null,
		string? role = null
	) {
		SecretsManagerOptions<SecretsManagerContextTests> options = new SecretsManagerOptions<SecretsManagerContextTests> {
			RegionEndpoint = regionEndpoint,
			CredentialsProfile = credentialsProfile,
			Role = role
		};
		_options!
			.Setup( o => o.Value )
			.Returns( options );

		_context = new AmazonSecretsManager<SecretsManagerContextTests>(
			_credentialsProvider!.Object,
			_options.Object
		);
	}
}

