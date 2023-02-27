using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InjectableAWS.Cognito.IntegrationTests;

[TestFixture]
public sealed class ExtensionMethodsTests {

	[Test]
	public void AddCognito_OptionsConfigured_ConfiguredObjectPassedToAction() {
		string credentialsProfile = "credentials_profile";
		string role = "role";
		string regionEndpoint = "region_endpoint";
		string clientId = "client_id";
		var serviceCollection = new ServiceCollection();
		CognitoOptions<ExtensionMethodsTests>? configuredOptions = null;

		serviceCollection.AddCognito<ExtensionMethodsTests>( ( opts ) => {
			Assert.IsNotNull( opts );
			opts.CredentialsProfile = credentialsProfile;
			opts.Role = role;
			opts.RegionEndpoint = regionEndpoint;
			opts.ClientId = clientId;
			configuredOptions = opts;
		} );
		IServiceProvider services = serviceCollection.BuildServiceProvider();

		IOptions<CognitoOptions<ExtensionMethodsTests>> options = services.GetRequiredService<IOptions<CognitoOptions<ExtensionMethodsTests>>>();
		Assert.AreEqual( credentialsProfile, options.Value.CredentialsProfile );
		Assert.AreEqual( role, options.Value.Role );
		Assert.AreEqual( regionEndpoint, options.Value.RegionEndpoint );
		Assert.AreEqual( clientId, options.Value.ClientId );
		Assert.AreSame( configuredOptions, options.Value );
	}
}

