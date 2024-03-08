
namespace Kiyote.AWS.UnitTests;

internal sealed class NullOptions<T> : IOptions<T> where T : class {
	T IOptions<T>.Value => null!;
}

