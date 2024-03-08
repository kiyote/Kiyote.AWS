using Amazon.DynamoDBv2.DataModel;

namespace Kiyote.AWS.DynamoDb;

internal sealed partial class DynamoDbContextContext<T> : IDynamoDBContext<T> where T: class {

	private bool _disposed;

	public DynamoDbContextContext(
		IAmazonDynamoDB<T> dynamoDB
	) {
		Context = new DynamoDBContext( dynamoDB );
	}

	public IDynamoDBContext Context { get; }

	public void Dispose() {
		Dispose( true );
		GC.SuppressFinalize( this );
	}

	private void Dispose( bool disposing ) {
		if( _disposed ) {
			return;
		}

		if( disposing ) {
			Context.Dispose();
		}

		_disposed = true;
	}

}
