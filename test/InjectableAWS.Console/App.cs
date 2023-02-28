using InjectableAWS.Console.Model;
using InjectableAWS.Console.Repositories;

namespace InjectableAWS.Console;

public sealed class App {

	private readonly UserDynamoDbRepository _userRepository;

	public App(
		UserDynamoDbRepository userRepository
	) {
		_userRepository = userRepository;
	}

	public async Task ExecuteAsync(
		CancellationToken cancellationToken
	) {
		User? user = await _userRepository.GetUserAsync( "test", cancellationToken ).ConfigureAwait( false );
		if (user is not null) {
			System.Console.WriteLine( $"{user.FirstName} {user.LastName}" );
		}
	}
}
