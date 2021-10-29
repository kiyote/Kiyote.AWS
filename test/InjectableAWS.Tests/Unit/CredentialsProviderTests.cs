using Amazon.Runtime;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace InjectableAWS.Tests.Unit {
	[TestFixture]
	internal class CredentialsProviderTests {

		private Mock<ICredentialsOptions>? _options;
		private ICredentialsProvider? _provider;

		[SetUp]
		public void SetUp() {
			_options = new Mock<ICredentialsOptions>( MockBehavior.Strict );
			_provider = new CredentialsProvider( _options.Object );
		}

		[Test]
		public void AssumeRole_ValidCredentials_NewCredentialsReturned() {
			var credentials = new BasicAWSCredentials(
				"accessKey",
				"secretKey"
			);
			string? role = "role";
			AWSCredentials? assumedCredentials = _provider!.AssumeRole( credentials, role );

			Assert.IsAssignableFrom<AssumeRoleAWSCredentials>( assumedCredentials );
		}
	}
}
