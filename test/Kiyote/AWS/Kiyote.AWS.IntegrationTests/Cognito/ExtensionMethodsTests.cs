namespace Kiyote.AWS.Cognito.IntegrationTests;

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
			Assert.That( opts, Is.Not.Null );
			opts.CredentialsProfile = credentialsProfile;
			opts.Role = role;
			opts.RegionEndpoint = regionEndpoint;
			opts.ClientId = clientId;
			configuredOptions = opts;
		} );
		IServiceProvider services = serviceCollection.BuildServiceProvider();

		IOptions<CognitoOptions<ExtensionMethodsTests>> options = services.GetRequiredService<IOptions<CognitoOptions<ExtensionMethodsTests>>>();
		Assert.That( options.Value.CredentialsProfile, Is.EqualTo( credentialsProfile ) );
		Assert.That( options.Value.Role, Is.EqualTo( role ) );
		Assert.That( options.Value.RegionEndpoint, Is.EqualTo( regionEndpoint ) );
		Assert.That( options.Value.ClientId, Is.EqualTo( clientId ) );
		Assert.That( options.Value, Is.SameAs( configuredOptions ) );
	}
}

