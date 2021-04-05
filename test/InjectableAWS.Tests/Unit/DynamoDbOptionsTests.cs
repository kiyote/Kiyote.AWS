using NUnit.Framework;

namespace InjectableAWS.Tests.Unit {

	[TestFixture]
	public sealed class DynamoDbOptionsTests {

		[Test]
		public void Equals_SameInstance_ReturnsTrue() {
			var options = new DynamoDbOptions<DynamoDbOptionsTests> {
				CredentialsProfile = "credentialsProfile",
				RegionEndpoint = "regionEndpoint",
				Role = "role",
				ServiceUrl = "serviceUrl"
			};

			Assert.IsTrue( options.Equals( options ) );
		}

		[Test]
		public void Equals_DifferentInstanceSameValues_ReturnsTrue() {
			var options1 = new DynamoDbOptions<DynamoDbOptionsTests> {
				CredentialsProfile = "credentialsProfile",
				RegionEndpoint = "regionEndpoint",
				Role = "role",
				ServiceUrl = "serviceUrl"
			};

			var options2 = new DynamoDbOptions<DynamoDbOptionsTests> {
				CredentialsProfile = "credentialsProfile",
				RegionEndpoint = "regionEndpoint",
				Role = "role",
				ServiceUrl = "serviceUrl"
			};

			Assert.IsTrue( options1.Equals( options2 ) );
		}

		[Test]
		public void Equals_DifferentInstanceDifferentValues_ReturnsTrue() {
			var options1 = new DynamoDbOptions<DynamoDbOptionsTests> {
				CredentialsProfile = "credentialsProfile1",
				RegionEndpoint = "regionEndpoint1",
				Role = "role1",
				ServiceUrl = "serviceUrl1"
			};

			var options2 = new DynamoDbOptions<DynamoDbOptionsTests> {
				CredentialsProfile = "credentialsProfile2",
				RegionEndpoint = "regionEndpoint2",
				Role = "role2",
				ServiceUrl = "serviceUrl2"
			};

			Assert.IsFalse( options1.Equals( options2 ) );
		}

		[Test]
		public void Equals_NullInstance_ReturnsFalse() {
			var options1 = new DynamoDbOptions<DynamoDbOptionsTests> {
				CredentialsProfile = "credentialsProfile",
				RegionEndpoint = "regionEndpoint",
				Role = "role",
				ServiceUrl = "serviceUrl"
			};

			DynamoDbOptions<DynamoDbOptionsTests>? options2 = null;
			Assert.IsFalse( options1.Equals( options2 ) );
		}

		[Test]
		public void Equals_DifferentGenericTypeSameValues_ReturnsFalse() {
			var options1 = new DynamoDbOptions<DynamoDbOptionsTests> {
				CredentialsProfile = "credentialsProfile",
				RegionEndpoint = "regionEndpoint",
				Role = "role",
				ServiceUrl = "serviceUrl"
			};

			var options2 = new DynamoDbOptions<int> {
				CredentialsProfile = "credentialsProfile",
				RegionEndpoint = "regionEndpoint",
				Role = "role",
				ServiceUrl = "serviceUrl"
			};

			Assert.IsFalse( options1.Equals( options2 ) );
		}

		[Test]
		public void Equals_DifferentType_ReturnsFalse() {
			var options1 = new DynamoDbOptions<DynamoDbOptionsTests> {
				CredentialsProfile = "credentialsProfile",
				RegionEndpoint = "regionEndpoint",
				Role = "role",
				ServiceUrl = "serviceUrl"
			};

			int options2 = 10;

			Assert.IsFalse( options1.Equals( options2 ) );

		}

	}
}
