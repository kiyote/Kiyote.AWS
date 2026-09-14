using Amazon.SecretsManager;

namespace Kiyote.AWS.SecretsManager;

public interface IAmazonSecretsManager<T>: IAmazonSecretsManager where T: class {
}
