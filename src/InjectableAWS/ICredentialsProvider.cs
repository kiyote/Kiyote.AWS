using Amazon.Runtime;

namespace InjectableAWS {
	public interface ICredentialsProvider {

		AWSCredentials GetCredentials();

		AWSCredentials GetCredentials( string? profile );

		AWSCredentials AssumeRole( AWSCredentials credentials, string role );
	}
}
