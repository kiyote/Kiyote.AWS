using Amazon.S3;

namespace Kiyote.AWS.S3;

public interface IAmazonS3<T>: IAmazonS3 where T: class {
}
