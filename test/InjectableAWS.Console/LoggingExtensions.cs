using Microsoft.Extensions.Logging;

namespace InjectableAWS.Console;

public static class LoggingExtensions {

	private readonly static Action<ILogger, string, Exception?> _debugMessage =
		LoggerMessage.Define<string>(
			LogLevel.Debug,
			eventId: new EventId( id: 0, name: "DEBUG" ),
			formatString: "{Message}"
		);

	public static void LogDebug(
		this ILogger logger,
		string message
	) {
		_debugMessage( logger, message, null );
	}
}

