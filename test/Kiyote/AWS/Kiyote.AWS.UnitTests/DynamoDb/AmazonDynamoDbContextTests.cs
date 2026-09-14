using Kiyote.AWS.Credentials;

namespace Kiyote.AWS.DynamoDb.UnitTests;

[TestFixture]
public sealed class AmazonDynamoDbContextTests {

	private Mock<ICredentialsProvider>? _credentialsProvider;
	private Mock<IOptions<DynamoDbOptions<AmazonDynamoDbContextTests>>>? _options;
	private AmazonDynamoDb<AmazonDynamoDbContextTests>? _context;

	[SetUp]
	public void SetUp() {
		_options = new Mock<IOptions<DynamoDbOptions<AmazonDynamoDbContextTests>>>( MockBehavior.Strict );
		_credentialsProvider = new Mock<ICredentialsProvider>( MockBehavior.Strict );
	}

	[TearDown]
	public void TearDown() {
		_credentialsProvider?.VerifyAll();
		_options?.VerifyAll();

		_context?.Dispose();
		_context = null;
	}

	[Test]
	public void Ctor_NullOptions_ThrowsException() {
		Assert.Throws<ArgumentException>( () => new AmazonDynamoDb<AmazonDynamoDbContextTests>(
			_credentialsProvider!.Object,
			new NullOptions<DynamoDbOptions<AmazonDynamoDbContextTests>>()
		) );
	}

	[Test]
	public void Ctor_NoProfile_DefaultContextCreated() {
		BasicAWSCredentials credentials = new BasicAWSCredentials( "key", "secret" );
		_credentialsProvider!
			.Setup( cp => cp.GetCredentials( null ) )
			.Returns( credentials );
		AWSConfigs.AWSRegion = "us-east-1";
		SetupContext();

		Assert.That( _context!.Client, Is.Not.Null );
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

		Assert.That( _context!.Client, Is.Not.Null );
	}

	private void SetupContext(
		string? credentialsProfile = null,
		string? regionEndpoint = null,
		string? role = null
	) {
		DynamoDbOptions<AmazonDynamoDbContextTests> options = new DynamoDbOptions<AmazonDynamoDbContextTests> {
			CredentialsProfile = credentialsProfile,
			RegionEndpoint = regionEndpoint,
			Role = role
		};
		_options!
			.Setup( o => o.Value )
			.Returns( options );

		_context = new AmazonDynamoDb<AmazonDynamoDbContextTests>(
			_credentialsProvider!.Object,
			_options!.Object
		);
	}
}
