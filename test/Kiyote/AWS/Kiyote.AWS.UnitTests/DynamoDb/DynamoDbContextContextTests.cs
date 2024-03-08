namespace Kiyote.AWS.DynamoDb.UnitTests;

[TestFixture]
public sealed class DynamoDbContextContextTests {

	private Mock<IAmazonDynamoDB<DynamoDbContextContextTests>>? _dynamoDb;
	private DynamoDbContextContext<DynamoDbContextContextTests>? _context;

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
		DynamoDbContextContext<DynamoDbContextContextTests> context = new DynamoDbContextContext<DynamoDbContextContextTests>(
			_dynamoDb!.Object
		);

		Assert.That( context.Context, Is.Not.Null );
	}
}
