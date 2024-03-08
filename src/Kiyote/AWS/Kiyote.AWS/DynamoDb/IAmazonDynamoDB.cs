using Amazon.DynamoDBv2;

namespace Kiyote.AWS.DynamoDb;

public interface IAmazonDynamoDB<T>: IAmazonDynamoDB where T: class {
}
