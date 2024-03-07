using Microsoft.Extensions.Options;

namespace Kiyote.AWS.Tests;

internal sealed class NullOptions<T> : IOptions<T> where T : class {
	T IOptions<T>.Value => null!;
}

