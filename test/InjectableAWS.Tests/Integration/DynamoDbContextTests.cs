using System;
using NUnit.Framework;

namespace InjectableAWS.Tests.Integration {

	[TestFixture]
	[Ignore( "Only need to run this when testing actual allocation." )]
	public sealed class DynamoDbContextTests {

		private DynamoDbContext<DynamoDbContextTests>? _context;

		[SetUp]
		public void SetUp() {
			var credentialsOptions = new CredentialsOptions();
			var credentialsProvider = new CredentialsProvider( credentialsOptions );
			var options = new DynamoDbOptions<DynamoDbContextTests>();
			_context = new DynamoDbContext<DynamoDbContextTests>( credentialsProvider, options );
		}

		[TearDown]
		public void TearDown() {
			if (_context != null) {
				( (IDisposable)_context ).Dispose();
			}
		}

		[Test]
		public void Ctor_ValidParameters_ContextCreated() {
			Assert.IsNotNull( _context );
		}
	}
}
