﻿using Microsoft.Extensions.DependencyInjection;
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
			Assert.IsNotNull( opts );
			opts.CredentialsProfile = credentialsProfile;
			opts.Role = role;
			opts.RegionEndpoint = regionEndpoint;
			configuredOptions = opts;
		} );
		IServiceProvider services = serviceCollection.BuildServiceProvider();

		IOptions<DynamoDbOptions<ExtensionMethodsTests>> options = services.GetRequiredService<IOptions<DynamoDbOptions<ExtensionMethodsTests>>>();
		Assert.AreEqual( credentialsProfile, options.Value.CredentialsProfile );
		Assert.AreEqual( role, options.Value.Role );
		Assert.AreEqual( regionEndpoint, options.Value.RegionEndpoint );
		Assert.AreSame( configuredOptions, options.Value );
	}
}
