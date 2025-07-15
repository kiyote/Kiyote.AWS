namespace Kiyote.AWS.DynamoDb.UnitTests;

[TestFixture]
public sealed class DynamoDbContextContextTests {

	private Mock<IAmazonDynamoDB<DynamoDbContextContextTests>>? _dynamoDb;
	private DynamoDbContext<DynamoDbContextContextTests>? _context;

	[SetUp]
	public void SetUp() {
		_dynamoDb = new Mock<IAmazonDynamoDB<DynamoDbContextContextTests>>( MockBehavior.Strict );
	}

	[TearDown]
	public void TearDown() {
		_dynamoDb?.VerifyAll();

		_context?.Dispose();
		_context = null;
	}

	[Test]
	public void Ctor_ValidDynamoDb_ContextCreated() {
		DynamoDbContext<DynamoDbContextContextTests> context = new DynamoDbContext<DynamoDbContextContextTests>(
			_dynamoDb!.Object
		);

		Assert.That( context.Context, Is.Not.Null );
	}
}
