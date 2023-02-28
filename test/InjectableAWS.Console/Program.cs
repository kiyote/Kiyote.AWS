using InjectableAWS.Console;
using InjectableAWS.Console.Repositories;
using InjectableAWS.DynamoDb;
using InjectableAWS.DynamoDb.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder( args )
	.UseDefaultServiceProvider( ( context, options ) => {
		options.ValidateOnBuild = context.HostingEnvironment.IsDevelopment();
		options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
	} )
	.ConfigureServices( ( context, services ) => {
		services
			.AddDynamoDb<App>( ( options ) => {
				context.Configuration.Bind( "AppDynamoDbContext", options );
			} )
			.AddDynamoDbRepository<App>( ( options ) => {
				context.Configuration.Bind( "AppDynamoDbRepository", options );
			} )
			.AddSingleton<UserDynamoDbRepository>()
			.AddSingleton<App>();
	} )
	.Build();

App app = host.Services.GetRequiredService<App>();
await app.ExecuteAsync( CancellationToken.None ).ConfigureAwait( false );
