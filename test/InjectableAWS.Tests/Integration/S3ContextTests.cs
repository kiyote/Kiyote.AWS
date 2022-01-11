using System;
using NUnit.Framework;

namespace InjectableAWS.Tests.Integration {

	[TestFixture]
	[Ignore( "Only need to run this when testing actual allocation." )]
	public sealed class S3ContextTests {

		private S3Context<S3ContextTests>? _context;

		[SetUp]
		public void SetUp() {
			var credentialsOptions = new CredentialsOptions();
			var credentialsProvider = new CredentialsProvider( credentialsOptions );
			var options = new S3Options<S3ContextTests>();
			_context = new S3Context<S3ContextTests>( credentialsProvider, options );
		}

		[TearDown]
		public void TearDown() {
			if( _context != null ) {
				( (IDisposable)_context ).Dispose();
			}
		}

		[Test]
		public void Ctor_ValidParameters_ContextCreated() {
			Assert.IsNotNull( _context );
		}
	}
}
