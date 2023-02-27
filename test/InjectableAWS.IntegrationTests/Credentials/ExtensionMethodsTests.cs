using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InjectableAWS.Credentials.IntegrationTests;

[TestFixture]
public sealed class ExtensionMethodsTests {

	[Test]
	public void AddDefaultCredentials_OptionsConfigured_ConfiguredObjectPassedToAction() {
		string filename = "testfile.txt";
		var serviceCollection = new ServiceCollection();
		CredentialsProviderOptions? configuredOptions = null;
		serviceCollection.AddDefaultCredentials( ( opts ) => {
			Assert.IsNotNull( opts );
			opts.CredentialsFile = filename;
			configuredOptions = opts;
		} );
		IServiceProvider services = serviceCollection.BuildServiceProvider();
		IOptions<CredentialsProviderOptions> options = services.GetRequiredService<IOptions<CredentialsProviderOptions>>();
		Assert.AreEqual( filename, options.Value.CredentialsFile );
		Assert.AreSame( configuredOptions, options.Value );
	}
}

