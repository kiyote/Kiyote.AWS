using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InjectableAWS.DynamoDb.IntegrationTests;

[TestFixture]
public sealed class ExtensionMethodsTests {

	[Test]
	public void AddCognito_OptionsConfigured_ConfiguredObjectPassedToAction() {
		string credentialsProfile = "credentials_profile";
		string role = "role";
		string regionEndpoint = "region_endpoint";
		var serviceCollection = new ServiceCollection();
		DynamoDbOptions<ExtensionMethodsTests>? configuredOptions = null;

		serviceCollection.AddDynamoDb<ExtensionMethodsTests>( ( opts ) => {
			Assert.That( opts, Is.Not.Null );
			opts.CredentialsProfile = credentialsProfile;
			opts.Role = role;
			opts.RegionEndpoint = regionEndpoint;
			configuredOptions = opts;
		} );
		IServiceProvider services = serviceCollection.BuildServiceProvider();

		IOptions<DynamoDbOptions<ExtensionMethodsTests>> options = services.GetRequiredService<IOptions<DynamoDbOptions<ExtensionMethodsTests>>>();
		Assert.That( options.Value.CredentialsProfile, Is.EqualTo( credentialsProfile ) );
		Assert.That( options.Value.Role, Is.EqualTo( role ) );
		Assert.That( options.Value.RegionEndpoint, Is.EqualTo( regionEndpoint ) );
		Assert.That( options.Value, Is.SameAs( configuredOptions ) );
	}
}

