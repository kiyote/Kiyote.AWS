using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kiyote.AWS.Credentials.IntegrationTests;

[TestFixture]
public sealed class ExtensionMethodsTests {

	[Test]
	public void AddDefaultCredentials_OptionsConfigured_ConfiguredObjectPassedToAction() {
		string filename = "testfile.txt";
		var serviceCollection = new ServiceCollection();
		CredentialsProviderOptions? configuredOptions = null;
		serviceCollection.AddDefaultCredentials( ( opts ) => {
			Assert.That( opts, Is.Not.Null );
			opts.CredentialsFile = filename;
			configuredOptions = opts;
		} );
		IServiceProvider services = serviceCollection.BuildServiceProvider();
		IOptions<CredentialsProviderOptions> options = services.GetRequiredService<IOptions<CredentialsProviderOptions>>();
		Assert.That( options.Value.CredentialsFile, Is.EqualTo( filename ) );
		Assert.That( options.Value, Is.SameAs( configuredOptions ) );
	}
}

