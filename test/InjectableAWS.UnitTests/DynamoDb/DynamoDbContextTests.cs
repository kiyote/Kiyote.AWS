using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using InjectableAWS.Credentials;
using InjectableAWS.Tests;
using Microsoft.Extensions.Options;

namespace InjectableAWS.DynamoDb.UnitTests;

[TestFixture]
public sealed class DynamoDbContextTests {

	private Mock<ICredentialsProvider>? _credentialsProvider;
	private Mock<IOptions<DynamoDbOptions<DynamoDbContextTests>>>? _options;
	private DynamoDbContext<DynamoDbContextTests>? _context;

	[SetUp]
	public void SetUp() {
		_options = new Mock<IOptions<DynamoDbOptions<DynamoDbContextTests>>>( MockBehavior.Strict );
		_credentialsProvider = new Mock<ICredentialsProvider>( MockBehavior.Strict );
	}

	[TearDown]
	public void TearDown() {
		_credentialsProvider?.VerifyAll();
		_options?.VerifyAll();

		_context?.Dispose();
		_context = null;
	}

	[Test]
	public void Ctor_NullOptions_ThrowsException() {
		Assert.Throws<ArgumentException>( () => new DynamoDbContext<DynamoDbContextTests>(
			_credentialsProvider!.Object,
			new NullOptions<DynamoDbOptions<DynamoDbContextTests>>()
		) );
	}

	[Test]
	public void Ctor_NoProfile_DefaultContextCreated() {
		BasicAWSCredentials credentials = new BasicAWSCredentials( "key", "secret" );
		_credentialsProvider!
			.Setup( cp => cp.GetCredentials( null ) )
			.Returns( credentials );
		AWSConfigs.AWSRegion = "us-east-1";
		SetupContext();

		Assert.That( _context!.Client, Is.Not.Null );
		Assert.That( _context!.Context, Is.Not.Null );
	}

	[Test]
	public void Ctor_UseProfileAndRegion_ContextWithAssumedRoleCreated() {
		string profile = "profile";
		string role = "role";
		string region = "us-east-1";
		BasicAWSCredentials creds1 = new BasicAWSCredentials( "1", "1" );
		_credentialsProvider!
			.Setup( cp => cp.GetCredentials( profile ) )
			.Returns( creds1 );
		BasicAWSCredentials creds2 = new BasicAWSCredentials( "2", "2" );
		_credentialsProvider!
			.Setup( cp => cp.AssumeRole( creds1, role ) )
			.Returns( creds2 );

		SetupContext(
			credentialsProfile: profile,
			regionEndpoint: region,
			role: role
		);

		Assert.That( _context!.Client, Is.Not.Null );
		Assert.That( _context!.Context, Is.Not.Null );
	}

	private void SetupContext(
		string? credentialsProfile = null,
		string? regionEndpoint = null,
		string? role = null
	) {
		DynamoDbOptions<DynamoDbContextTests> options = new DynamoDbOptions<DynamoDbContextTests> {
			CredentialsProfile = credentialsProfile,
			RegionEndpoint = regionEndpoint,
			Role = role
		};
		_options!
			.Setup( o => o.Value )
			.Returns( options );

		_context = new DynamoDbContext<DynamoDbContextTests>(
			_credentialsProvider!.Object,
			_options!.Object
		);
	}
}
