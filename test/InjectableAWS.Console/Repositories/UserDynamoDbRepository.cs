using Amazon.DynamoDBv2.DataModel;
using InjectableAWS.Console.Model;
using InjectableAWS.DynamoDb;
using InjectableAWS.DynamoDb.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InjectableAWS.Console.Repositories;

public sealed class UserDynamoDbRepository : DynamoDbRepository<App> {

	private readonly ILogger _logger;

	private sealed record UserRecord {
		[DynamoDBHashKey( "PK" )]
		public string? PK { get; init; }
		[DynamoDBRangeKey( "SK" )]
		public string? SK { get; init; }
		[DynamoDBProperty]
		public string? FirstName { get; init; }
		[DynamoDBProperty]
		public string? LastName { get; init; }
	}

	public UserDynamoDbRepository(
		IOptions<DynamoDbRepositoryOptions<App>> options,
		DynamoDbContext<App> context,
		ILogger<UserDynamoDbRepository> logger
	) : base( options, context ) {
		_logger = logger;
	}

	public async Task<User?> GetUserAsync(
		string userId,
		CancellationToken cancellationToken
	) {
		_logger.LogDebug( "Loading user record." );

		// The structure of the record isn't important, just trying to show
		// how to get an object and return it.
		UserRecord? record = await LoadAsync<UserRecord>( userId, userId, cancellationToken ).ConfigureAwait( false );

		if( record is null ) {
			_logger.LogDebug( "User record not found." );
			return null;
		}

		_logger.LogDebug( "Loaded user record." );

		return new User( record.PK ?? "", record.FirstName ?? "", record.LastName ?? "" );
	}
}
