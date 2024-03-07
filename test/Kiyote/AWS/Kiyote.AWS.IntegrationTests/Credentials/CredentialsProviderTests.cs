using Amazon.Runtime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kiyote.AWS.Credentials.IntegrationTests;

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

		Assert.That( credentials, Is.Not.Null );
	}

	[Test]
	public void GetCredentials_DefaultProfile_DefaultCredentialsReturned() {
		ConfigureProvider( "dummycreds.txt" );

		AWSCredentials? credentials = _credentialsProvider!.GetCredentials();

		Assert.That( credentials, Is.Not.Null );
		ImmutableCredentials creds = credentials.GetCredentials();
		Assert.That( creds.SecretKey, Is.EqualTo( @"wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY" ) );
		Assert.That( creds.AccessKey, Is.EqualTo( @"AKIAIOSFODNN7EXAMPLE" ) );
	}

	[Test]
	public void GetCredentials_SpecificProfile_TestCredentialsReturned() {
		ConfigureProvider( "dummycreds.txt" );

		AWSCredentials? credentials = _credentialsProvider!.GetCredentials( "test" );

		Assert.That( credentials, Is.Not.Null );
		ImmutableCredentials creds = credentials.GetCredentials();
		Assert.That( creds.SecretKey, Is.EqualTo( @"wJalrXUtnFEMI/K7MDENG/bPxRfiCYTESTKEY" ) );
		Assert.That( creds.AccessKey, Is.EqualTo( @"AKIAIOSFODNN7TEST" ) );
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
