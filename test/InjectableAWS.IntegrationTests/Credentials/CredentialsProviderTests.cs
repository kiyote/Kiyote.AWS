using Amazon.Runtime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InjectableAWS.Credentials.IntegrationTests;

[TestFixture]
public sealed class CredentialsProviderTests {

	private IServiceScope? _scope;
	private ICredentialsProvider? _credentialsProvider;

	[SetUp]
	public void SetUp() {
		var serviceCollection = new ServiceCollection();
		serviceCollection.AddDefaultCredentials();
		IServiceProvider services = serviceCollection.BuildServiceProvider();
		_scope = services.CreateAsyncScope();

		_credentialsProvider = _scope.ServiceProvider.GetRequiredService<ICredentialsProvider>();
	}

	[TearDown]
	public void TearDown() {
		_scope?.Dispose();
		_scope = null;
	}

	[Test]
	public void GetCredentials_NoProfileFile_EnvironmentVariablesAWSCredentialsReturned() {
		AWSCredentials? credentials = _credentialsProvider!.GetCredentials();

		Assert.IsNotNull( credentials );
	}

	[Test]
	public void GetCredentials_DefaultProfile_DefaultCredentialsReturned() {
		ConfigureProvider( "dummycreds.txt" );

		AWSCredentials? credentials = _credentialsProvider!.GetCredentials();

		Assert.IsNotNull( credentials );
		ImmutableCredentials creds = credentials.GetCredentials();
		Assert.AreEqual( @"wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY", creds.SecretKey );
		Assert.AreEqual( @"AKIAIOSFODNN7EXAMPLE", creds.AccessKey );
	}

	[Test]
	public void GetCredentials_SpecificProfile_TestCredentialsReturned() {
		ConfigureProvider( "dummycreds.txt" );

		AWSCredentials? credentials = _credentialsProvider!.GetCredentials( "test" );

		Assert.IsNotNull( credentials );
		ImmutableCredentials creds = credentials.GetCredentials();
		Assert.AreEqual( @"wJalrXUtnFEMI/K7MDENG/bPxRfiCYTESTKEY", creds.SecretKey );
		Assert.AreEqual( @"AKIAIOSFODNN7TEST", creds.AccessKey );
	}

	[Test]
	public void GetCredentials_InvalidProfile_ThrowsInvalidOperationException() {
		ConfigureProvider( "dummycreds.txt" );

		Assert.Throws<InvalidOperationException>( () => _credentialsProvider!.GetCredentials( "invalid" ) );
	}

	private void ConfigureProvider(
		string filename
	) {
		IOptions<CredentialsProviderOptions> options = _scope!.ServiceProvider.GetRequiredService<IOptions<CredentialsProviderOptions>>();
		string folder = Path.Combine( TestContext.CurrentContext.TestDirectory, "Credentials" );
		string credentialsFile = Path.Combine( folder, filename );
		options.Value.CredentialsFile = credentialsFile;
	}
}
