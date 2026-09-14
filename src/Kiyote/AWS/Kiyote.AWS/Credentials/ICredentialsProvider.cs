using Amazon.Runtime;

namespace Kiyote.AWS.Credentials;

public interface ICredentialsProvider {

	AWSCredentials GetCredentials();

	AWSCredentials GetCredentials( string? profile );

	AWSCredentials AssumeRole( AWSCredentials credentials, string role );
}
