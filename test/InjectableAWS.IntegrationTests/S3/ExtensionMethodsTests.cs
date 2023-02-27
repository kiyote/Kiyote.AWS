using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InjectableAWS.S3.IntegrationTests;

[TestFixture]
public sealed class ExtensionMethodsTests {

	[Test]
	public void AddS3_OptionsConfigured_ConfiguredObjectPassedToAction() {
		string credentialsProfile = "credentials_profile";
		string role = "role";
		string regionEndpoint = "region_endpoint";
		var serviceCollection = new ServiceCollection();
		S3Options<ExtensionMethodsTests>? configuredOptions = null;

		serviceCollection.AddS3<ExtensionMethodsTests>( ( opts ) => {
			Assert.IsNotNull( opts );
			opts.CredentialsProfile = credentialsProfile;
			opts.Role = role;
			opts.RegionEndpoint = regionEndpoint;
			configuredOptions = opts;
		} );
		IServiceProvider services = serviceCollection.BuildServiceProvider();

		IOptions<S3Options<ExtensionMethodsTests>> options = services.GetRequiredService<IOptions<S3Options<ExtensionMethodsTests>>>();
		Assert.AreEqual( credentialsProfile, options.Value.CredentialsProfile );
		Assert.AreEqual( role, options.Value.Role );
		Assert.AreEqual( regionEndpoint, options.Value.RegionEndpoint );
		Assert.AreSame( configuredOptions, options.Value );
	}
}

