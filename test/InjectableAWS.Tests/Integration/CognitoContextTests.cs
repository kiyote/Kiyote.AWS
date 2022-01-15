namespace InjectableAWS.Tests.Integration;

[TestFixture]
[Ignore( "Only need to run this when testing actual allocation." )]
public sealed class CognitoContextTests {

	private CognitoContext<CognitoContextTests>? _context;

	[SetUp]
	public void SetUp() {
		var credentialsOptions = new CredentialsOptions();
		var credentialsProvider = new CredentialsProvider( credentialsOptions );
		var options = new CognitoOptions<CognitoContextTests>(
			ClientId: "",
			RegionEndpoint: "",
			CredentialsProfile: "",
			Role: ""
		);
		_context = new CognitoContext<CognitoContextTests>( credentialsProvider, options );
	}

	[TearDown]
	public void TearDown() {
		if( _context != null ) {
			( (IDisposable)_context ).Dispose();
		}
	}

	[Test]
	public void Ctor_ValidParameters_ContextCreated() {
		Assert.IsNotNull( _context );
	}
}
