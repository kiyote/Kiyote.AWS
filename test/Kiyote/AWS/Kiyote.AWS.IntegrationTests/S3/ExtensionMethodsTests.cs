namespace Kiyote.AWS.S3.IntegrationTests;

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
			Assert.That( opts, Is.Not.Null );
			opts.CredentialsProfile = credentialsProfile;
			opts.Role = role;
			opts.RegionEndpoint = regionEndpoint;
			configuredOptions = opts;
		} );
		IServiceProvider services = serviceCollection.BuildServiceProvider();

		IOptions<S3Options<ExtensionMethodsTests>> options = services.GetRequiredService<IOptions<S3Options<ExtensionMethodsTests>>>();
		Assert.That( options.Value.CredentialsProfile, Is.EqualTo( credentialsProfile ) );
		Assert.That( options.Value.Role, Is.EqualTo( role ) );
		Assert.That( options.Value.RegionEndpoint, Is.EqualTo( regionEndpoint ) );
		Assert.That( options.Value, Is.SameAs( configuredOptions ) );
	}
}

