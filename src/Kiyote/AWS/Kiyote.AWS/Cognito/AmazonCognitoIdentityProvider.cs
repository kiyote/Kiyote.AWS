using System.Diagnostics.CodeAnalysis;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Runtime;
using Amazon.Runtime.Endpoints;
using Kiyote.AWS.Credentials;
using Microsoft.Extensions.Options;

namespace Kiyote.AWS.Cognito;

internal sealed class AmazonCognitoIdentityProvider<T> : IAmazonCognitoIdentityProvider<T> where T : class {

	private bool _disposed;

	public AmazonCognitoIdentityProvider(
		ICredentialsProvider credentialsProvider,
		IOptions<CognitoOptions<T>> options
	) {
		if( options.Value is null ) {
			throw new ArgumentException( $"{nameof( options )} must not be null.", nameof( options ) );
		}

		Provider = CreateCognitoProvider( credentialsProvider, options.Value );
	}

	public IAmazonCognitoIdentityProvider Provider { get; }

	private static IAmazonCognitoIdentityProvider CreateCognitoProvider(
		ICredentialsProvider credentialsProvider,
		CognitoOptions<T> options
	) {
		AWSCredentials credentials = credentialsProvider.GetCredentials( options.CredentialsProfile );
		if( !string.IsNullOrWhiteSpace( options.Role ) ) {
			credentials = credentialsProvider.AssumeRole(
				credentials,
				options.Role
			);
		}

		if( !string.IsNullOrWhiteSpace( options.RegionEndpoint ) ) {
			AmazonCognitoIdentityProviderConfig config = new AmazonCognitoIdentityProviderConfig {
				RegionEndpoint = RegionEndpoint.GetBySystemName( options.RegionEndpoint )
			};
			return new AmazonCognitoIdentityProviderClient( credentials, config );
		}

		return new AmazonCognitoIdentityProviderClient( credentials );
	}

	public void Dispose() {
		Dispose( true );
		GC.SuppressFinalize( this );
	}

	private void Dispose( bool disposing ) {
		if( _disposed ) {
			return;
		}

		if( disposing ) {
			Provider.Dispose();
		}

		_disposed = true;
	}

	[ExcludeFromCodeCoverage]
	ICognitoIdentityProviderPaginatorFactory IAmazonCognitoIdentityProvider.Paginators => Provider.Paginators;

	[ExcludeFromCodeCoverage]
	IClientConfig IAmazonService.Config => Provider.Config;

	[ExcludeFromCodeCoverage]
	Task<AddCustomAttributesResponse> IAmazonCognitoIdentityProvider.AddCustomAttributesAsync( AddCustomAttributesRequest request, CancellationToken cancellationToken ) {
		return Provider.AddCustomAttributesAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminAddUserToGroupResponse> IAmazonCognitoIdentityProvider.AdminAddUserToGroupAsync( AdminAddUserToGroupRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminAddUserToGroupAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminConfirmSignUpResponse> IAmazonCognitoIdentityProvider.AdminConfirmSignUpAsync( AdminConfirmSignUpRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminConfirmSignUpAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminCreateUserResponse> IAmazonCognitoIdentityProvider.AdminCreateUserAsync( AdminCreateUserRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminCreateUserAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminDeleteUserResponse> IAmazonCognitoIdentityProvider.AdminDeleteUserAsync( AdminDeleteUserRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminDeleteUserAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminDeleteUserAttributesResponse> IAmazonCognitoIdentityProvider.AdminDeleteUserAttributesAsync( AdminDeleteUserAttributesRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminDeleteUserAttributesAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminDisableProviderForUserResponse> IAmazonCognitoIdentityProvider.AdminDisableProviderForUserAsync( AdminDisableProviderForUserRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminDisableProviderForUserAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminDisableUserResponse> IAmazonCognitoIdentityProvider.AdminDisableUserAsync( AdminDisableUserRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminDisableUserAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminEnableUserResponse> IAmazonCognitoIdentityProvider.AdminEnableUserAsync( AdminEnableUserRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminEnableUserAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminForgetDeviceResponse> IAmazonCognitoIdentityProvider.AdminForgetDeviceAsync( AdminForgetDeviceRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminForgetDeviceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminGetDeviceResponse> IAmazonCognitoIdentityProvider.AdminGetDeviceAsync( AdminGetDeviceRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminGetDeviceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminGetUserResponse> IAmazonCognitoIdentityProvider.AdminGetUserAsync( AdminGetUserRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminGetUserAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminInitiateAuthResponse> IAmazonCognitoIdentityProvider.AdminInitiateAuthAsync( AdminInitiateAuthRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminInitiateAuthAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminLinkProviderForUserResponse> IAmazonCognitoIdentityProvider.AdminLinkProviderForUserAsync( AdminLinkProviderForUserRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminLinkProviderForUserAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminListDevicesResponse> IAmazonCognitoIdentityProvider.AdminListDevicesAsync( AdminListDevicesRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminListDevicesAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminListGroupsForUserResponse> IAmazonCognitoIdentityProvider.AdminListGroupsForUserAsync( AdminListGroupsForUserRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminListGroupsForUserAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminListUserAuthEventsResponse> IAmazonCognitoIdentityProvider.AdminListUserAuthEventsAsync( AdminListUserAuthEventsRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminListUserAuthEventsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminRemoveUserFromGroupResponse> IAmazonCognitoIdentityProvider.AdminRemoveUserFromGroupAsync( AdminRemoveUserFromGroupRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminRemoveUserFromGroupAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminResetUserPasswordResponse> IAmazonCognitoIdentityProvider.AdminResetUserPasswordAsync( AdminResetUserPasswordRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminResetUserPasswordAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminRespondToAuthChallengeResponse> IAmazonCognitoIdentityProvider.AdminRespondToAuthChallengeAsync( AdminRespondToAuthChallengeRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminRespondToAuthChallengeAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminSetUserMFAPreferenceResponse> IAmazonCognitoIdentityProvider.AdminSetUserMFAPreferenceAsync( AdminSetUserMFAPreferenceRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminSetUserMFAPreferenceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminSetUserPasswordResponse> IAmazonCognitoIdentityProvider.AdminSetUserPasswordAsync( AdminSetUserPasswordRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminSetUserPasswordAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminSetUserSettingsResponse> IAmazonCognitoIdentityProvider.AdminSetUserSettingsAsync( AdminSetUserSettingsRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminSetUserSettingsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminUpdateAuthEventFeedbackResponse> IAmazonCognitoIdentityProvider.AdminUpdateAuthEventFeedbackAsync( AdminUpdateAuthEventFeedbackRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminUpdateAuthEventFeedbackAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminUpdateDeviceStatusResponse> IAmazonCognitoIdentityProvider.AdminUpdateDeviceStatusAsync( AdminUpdateDeviceStatusRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminUpdateDeviceStatusAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminUpdateUserAttributesResponse> IAmazonCognitoIdentityProvider.AdminUpdateUserAttributesAsync( AdminUpdateUserAttributesRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminUpdateUserAttributesAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AdminUserGlobalSignOutResponse> IAmazonCognitoIdentityProvider.AdminUserGlobalSignOutAsync( AdminUserGlobalSignOutRequest request, CancellationToken cancellationToken ) {
		return Provider.AdminUserGlobalSignOutAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<AssociateSoftwareTokenResponse> IAmazonCognitoIdentityProvider.AssociateSoftwareTokenAsync( AssociateSoftwareTokenRequest request, CancellationToken cancellationToken ) {
		return Provider.AssociateSoftwareTokenAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ChangePasswordResponse> IAmazonCognitoIdentityProvider.ChangePasswordAsync( ChangePasswordRequest request, CancellationToken cancellationToken ) {
		return Provider.ChangePasswordAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ConfirmDeviceResponse> IAmazonCognitoIdentityProvider.ConfirmDeviceAsync( ConfirmDeviceRequest request, CancellationToken cancellationToken ) {
		return Provider.ConfirmDeviceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ConfirmForgotPasswordResponse> IAmazonCognitoIdentityProvider.ConfirmForgotPasswordAsync( ConfirmForgotPasswordRequest request, CancellationToken cancellationToken ) {
		return Provider.ConfirmForgotPasswordAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ConfirmSignUpResponse> IAmazonCognitoIdentityProvider.ConfirmSignUpAsync( ConfirmSignUpRequest request, CancellationToken cancellationToken ) {
		return Provider.ConfirmSignUpAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateGroupResponse> IAmazonCognitoIdentityProvider.CreateGroupAsync( CreateGroupRequest request, CancellationToken cancellationToken ) {
		return Provider.CreateGroupAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateIdentityProviderResponse> IAmazonCognitoIdentityProvider.CreateIdentityProviderAsync( CreateIdentityProviderRequest request, CancellationToken cancellationToken ) {
		return Provider.CreateIdentityProviderAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateResourceServerResponse> IAmazonCognitoIdentityProvider.CreateResourceServerAsync( CreateResourceServerRequest request, CancellationToken cancellationToken ) {
		return Provider.CreateResourceServerAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateUserImportJobResponse> IAmazonCognitoIdentityProvider.CreateUserImportJobAsync( CreateUserImportJobRequest request, CancellationToken cancellationToken ) {
		return Provider.CreateUserImportJobAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateUserPoolResponse> IAmazonCognitoIdentityProvider.CreateUserPoolAsync( CreateUserPoolRequest request, CancellationToken cancellationToken ) {
		return Provider.CreateUserPoolAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateUserPoolClientResponse> IAmazonCognitoIdentityProvider.CreateUserPoolClientAsync( CreateUserPoolClientRequest request, CancellationToken cancellationToken ) {
		return Provider.CreateUserPoolClientAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateUserPoolDomainResponse> IAmazonCognitoIdentityProvider.CreateUserPoolDomainAsync( CreateUserPoolDomainRequest request, CancellationToken cancellationToken ) {
		return Provider.CreateUserPoolDomainAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteGroupResponse> IAmazonCognitoIdentityProvider.DeleteGroupAsync( DeleteGroupRequest request, CancellationToken cancellationToken ) {
		return Provider.DeleteGroupAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteIdentityProviderResponse> IAmazonCognitoIdentityProvider.DeleteIdentityProviderAsync( DeleteIdentityProviderRequest request, CancellationToken cancellationToken ) {
		return Provider.DeleteIdentityProviderAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteResourceServerResponse> IAmazonCognitoIdentityProvider.DeleteResourceServerAsync( DeleteResourceServerRequest request, CancellationToken cancellationToken ) {
		return Provider.DeleteResourceServerAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteUserResponse> IAmazonCognitoIdentityProvider.DeleteUserAsync( DeleteUserRequest request, CancellationToken cancellationToken ) {
		return Provider.DeleteUserAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteUserAttributesResponse> IAmazonCognitoIdentityProvider.DeleteUserAttributesAsync( DeleteUserAttributesRequest request, CancellationToken cancellationToken ) {
		return Provider.DeleteUserAttributesAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteUserPoolResponse> IAmazonCognitoIdentityProvider.DeleteUserPoolAsync( DeleteUserPoolRequest request, CancellationToken cancellationToken ) {
		return Provider.DeleteUserPoolAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteUserPoolClientResponse> IAmazonCognitoIdentityProvider.DeleteUserPoolClientAsync( DeleteUserPoolClientRequest request, CancellationToken cancellationToken ) {
		return Provider.DeleteUserPoolClientAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteUserPoolDomainResponse> IAmazonCognitoIdentityProvider.DeleteUserPoolDomainAsync( DeleteUserPoolDomainRequest request, CancellationToken cancellationToken ) {
		return Provider.DeleteUserPoolDomainAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeIdentityProviderResponse> IAmazonCognitoIdentityProvider.DescribeIdentityProviderAsync( DescribeIdentityProviderRequest request, CancellationToken cancellationToken ) {
		return Provider.DescribeIdentityProviderAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeResourceServerResponse> IAmazonCognitoIdentityProvider.DescribeResourceServerAsync( DescribeResourceServerRequest request, CancellationToken cancellationToken ) {
		return Provider.DescribeResourceServerAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeRiskConfigurationResponse> IAmazonCognitoIdentityProvider.DescribeRiskConfigurationAsync( DescribeRiskConfigurationRequest request, CancellationToken cancellationToken ) {
		return Provider.DescribeRiskConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeUserImportJobResponse> IAmazonCognitoIdentityProvider.DescribeUserImportJobAsync( DescribeUserImportJobRequest request, CancellationToken cancellationToken ) {
		return Provider.DescribeUserImportJobAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeUserPoolResponse> IAmazonCognitoIdentityProvider.DescribeUserPoolAsync( DescribeUserPoolRequest request, CancellationToken cancellationToken ) {
		return Provider.DescribeUserPoolAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeUserPoolClientResponse> IAmazonCognitoIdentityProvider.DescribeUserPoolClientAsync( DescribeUserPoolClientRequest request, CancellationToken cancellationToken ) {
		return Provider.DescribeUserPoolClientAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeUserPoolDomainResponse> IAmazonCognitoIdentityProvider.DescribeUserPoolDomainAsync( DescribeUserPoolDomainRequest request, CancellationToken cancellationToken ) {
		return Provider.DescribeUserPoolDomainAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Endpoint IAmazonCognitoIdentityProvider.DetermineServiceOperationEndpoint( AmazonWebServiceRequest request ) {
		return Provider.DetermineServiceOperationEndpoint( request );
	}

	[ExcludeFromCodeCoverage]
	Task<ForgetDeviceResponse> IAmazonCognitoIdentityProvider.ForgetDeviceAsync( ForgetDeviceRequest request, CancellationToken cancellationToken ) {
		return Provider.ForgetDeviceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ForgotPasswordResponse> IAmazonCognitoIdentityProvider.ForgotPasswordAsync( ForgotPasswordRequest request, CancellationToken cancellationToken ) {
		return Provider.ForgotPasswordAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetCSVHeaderResponse> IAmazonCognitoIdentityProvider.GetCSVHeaderAsync( GetCSVHeaderRequest request, CancellationToken cancellationToken ) {
		return Provider.GetCSVHeaderAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetDeviceResponse> IAmazonCognitoIdentityProvider.GetDeviceAsync( GetDeviceRequest request, CancellationToken cancellationToken ) {
		return Provider.GetDeviceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetGroupResponse> IAmazonCognitoIdentityProvider.GetGroupAsync( GetGroupRequest request, CancellationToken cancellationToken ) {
		return Provider.GetGroupAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetIdentityProviderByIdentifierResponse> IAmazonCognitoIdentityProvider.GetIdentityProviderByIdentifierAsync( GetIdentityProviderByIdentifierRequest request, CancellationToken cancellationToken ) {
		return Provider.GetIdentityProviderByIdentifierAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetLogDeliveryConfigurationResponse> IAmazonCognitoIdentityProvider.GetLogDeliveryConfigurationAsync( GetLogDeliveryConfigurationRequest request, CancellationToken cancellationToken ) {
		return Provider.GetLogDeliveryConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetSigningCertificateResponse> IAmazonCognitoIdentityProvider.GetSigningCertificateAsync( GetSigningCertificateRequest request, CancellationToken cancellationToken ) {
		return Provider.GetSigningCertificateAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetTokensFromRefreshTokenResponse> IAmazonCognitoIdentityProvider.GetTokensFromRefreshTokenAsync( GetTokensFromRefreshTokenRequest request, CancellationToken cancellationToken ) {
		return Provider.GetTokensFromRefreshTokenAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetUICustomizationResponse> IAmazonCognitoIdentityProvider.GetUICustomizationAsync( GetUICustomizationRequest request, CancellationToken cancellationToken ) {
		return Provider.GetUICustomizationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetUserResponse> IAmazonCognitoIdentityProvider.GetUserAsync( GetUserRequest request, CancellationToken cancellationToken ) {
		return Provider.GetUserAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetUserAttributeVerificationCodeResponse> IAmazonCognitoIdentityProvider.GetUserAttributeVerificationCodeAsync( GetUserAttributeVerificationCodeRequest request, CancellationToken cancellationToken ) {
		return Provider.GetUserAttributeVerificationCodeAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetUserPoolMfaConfigResponse> IAmazonCognitoIdentityProvider.GetUserPoolMfaConfigAsync( GetUserPoolMfaConfigRequest request, CancellationToken cancellationToken ) {
		return Provider.GetUserPoolMfaConfigAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GlobalSignOutResponse> IAmazonCognitoIdentityProvider.GlobalSignOutAsync( GlobalSignOutRequest request, CancellationToken cancellationToken ) {
		return Provider.GlobalSignOutAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<InitiateAuthResponse> IAmazonCognitoIdentityProvider.InitiateAuthAsync( InitiateAuthRequest request, CancellationToken cancellationToken ) {
		return Provider.InitiateAuthAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListDevicesResponse> IAmazonCognitoIdentityProvider.ListDevicesAsync( ListDevicesRequest request, CancellationToken cancellationToken ) {
		return Provider.ListDevicesAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListGroupsResponse> IAmazonCognitoIdentityProvider.ListGroupsAsync( ListGroupsRequest request, CancellationToken cancellationToken ) {
		return Provider.ListGroupsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListIdentityProvidersResponse> IAmazonCognitoIdentityProvider.ListIdentityProvidersAsync( ListIdentityProvidersRequest request, CancellationToken cancellationToken ) {
		return Provider.ListIdentityProvidersAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListResourceServersResponse> IAmazonCognitoIdentityProvider.ListResourceServersAsync( ListResourceServersRequest request, CancellationToken cancellationToken ) {
		return Provider.ListResourceServersAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListTagsForResourceResponse> IAmazonCognitoIdentityProvider.ListTagsForResourceAsync( ListTagsForResourceRequest request, CancellationToken cancellationToken ) {
		return Provider.ListTagsForResourceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListUserImportJobsResponse> IAmazonCognitoIdentityProvider.ListUserImportJobsAsync( ListUserImportJobsRequest request, CancellationToken cancellationToken ) {
		return Provider.ListUserImportJobsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListUserPoolClientsResponse> IAmazonCognitoIdentityProvider.ListUserPoolClientsAsync( ListUserPoolClientsRequest request, CancellationToken cancellationToken ) {
		return Provider.ListUserPoolClientsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListUserPoolsResponse> IAmazonCognitoIdentityProvider.ListUserPoolsAsync( ListUserPoolsRequest request, CancellationToken cancellationToken ) {
		return Provider.ListUserPoolsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListUsersResponse> IAmazonCognitoIdentityProvider.ListUsersAsync( ListUsersRequest request, CancellationToken cancellationToken ) {
		return Provider.ListUsersAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListUsersInGroupResponse> IAmazonCognitoIdentityProvider.ListUsersInGroupAsync( ListUsersInGroupRequest request, CancellationToken cancellationToken ) {
		return Provider.ListUsersInGroupAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ResendConfirmationCodeResponse> IAmazonCognitoIdentityProvider.ResendConfirmationCodeAsync( ResendConfirmationCodeRequest request, CancellationToken cancellationToken ) {
		return Provider.ResendConfirmationCodeAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<RespondToAuthChallengeResponse> IAmazonCognitoIdentityProvider.RespondToAuthChallengeAsync( RespondToAuthChallengeRequest request, CancellationToken cancellationToken ) {
		return Provider.RespondToAuthChallengeAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<RevokeTokenResponse> IAmazonCognitoIdentityProvider.RevokeTokenAsync( RevokeTokenRequest request, CancellationToken cancellationToken ) {
		return Provider.RevokeTokenAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<SetLogDeliveryConfigurationResponse> IAmazonCognitoIdentityProvider.SetLogDeliveryConfigurationAsync( SetLogDeliveryConfigurationRequest request, CancellationToken cancellationToken ) {
		return Provider.SetLogDeliveryConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<SetRiskConfigurationResponse> IAmazonCognitoIdentityProvider.SetRiskConfigurationAsync( SetRiskConfigurationRequest request, CancellationToken cancellationToken ) {
		return Provider.SetRiskConfigurationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<SetUICustomizationResponse> IAmazonCognitoIdentityProvider.SetUICustomizationAsync( SetUICustomizationRequest request, CancellationToken cancellationToken ) {
		return Provider.SetUICustomizationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<SetUserMFAPreferenceResponse> IAmazonCognitoIdentityProvider.SetUserMFAPreferenceAsync( SetUserMFAPreferenceRequest request, CancellationToken cancellationToken ) {
		return Provider.SetUserMFAPreferenceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<SetUserPoolMfaConfigResponse> IAmazonCognitoIdentityProvider.SetUserPoolMfaConfigAsync( SetUserPoolMfaConfigRequest request, CancellationToken cancellationToken ) {
		return Provider.SetUserPoolMfaConfigAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<SetUserSettingsResponse> IAmazonCognitoIdentityProvider.SetUserSettingsAsync( SetUserSettingsRequest request, CancellationToken cancellationToken ) {
		return Provider.SetUserSettingsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<SignUpResponse> IAmazonCognitoIdentityProvider.SignUpAsync( SignUpRequest request, CancellationToken cancellationToken ) {
		return Provider.SignUpAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<StartUserImportJobResponse> IAmazonCognitoIdentityProvider.StartUserImportJobAsync( StartUserImportJobRequest request, CancellationToken cancellationToken ) {
		return Provider.StartUserImportJobAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<StopUserImportJobResponse> IAmazonCognitoIdentityProvider.StopUserImportJobAsync( StopUserImportJobRequest request, CancellationToken cancellationToken ) {
		return Provider.StopUserImportJobAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<TagResourceResponse> IAmazonCognitoIdentityProvider.TagResourceAsync( TagResourceRequest request, CancellationToken cancellationToken ) {
		return Provider.TagResourceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UntagResourceResponse> IAmazonCognitoIdentityProvider.UntagResourceAsync( UntagResourceRequest request, CancellationToken cancellationToken ) {
		return Provider.UntagResourceAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateAuthEventFeedbackResponse> IAmazonCognitoIdentityProvider.UpdateAuthEventFeedbackAsync( UpdateAuthEventFeedbackRequest request, CancellationToken cancellationToken ) {
		return Provider.UpdateAuthEventFeedbackAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateDeviceStatusResponse> IAmazonCognitoIdentityProvider.UpdateDeviceStatusAsync( UpdateDeviceStatusRequest request, CancellationToken cancellationToken ) {
		return Provider.UpdateDeviceStatusAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateGroupResponse> IAmazonCognitoIdentityProvider.UpdateGroupAsync( UpdateGroupRequest request, CancellationToken cancellationToken ) {
		return Provider.UpdateGroupAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateIdentityProviderResponse> IAmazonCognitoIdentityProvider.UpdateIdentityProviderAsync( UpdateIdentityProviderRequest request, CancellationToken cancellationToken ) {
		return Provider.UpdateIdentityProviderAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateResourceServerResponse> IAmazonCognitoIdentityProvider.UpdateResourceServerAsync( UpdateResourceServerRequest request, CancellationToken cancellationToken ) {
		return Provider.UpdateResourceServerAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateUserAttributesResponse> IAmazonCognitoIdentityProvider.UpdateUserAttributesAsync( UpdateUserAttributesRequest request, CancellationToken cancellationToken ) {
		return Provider.UpdateUserAttributesAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateUserPoolResponse> IAmazonCognitoIdentityProvider.UpdateUserPoolAsync( UpdateUserPoolRequest request, CancellationToken cancellationToken ) {
		return Provider.UpdateUserPoolAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateUserPoolClientResponse> IAmazonCognitoIdentityProvider.UpdateUserPoolClientAsync( UpdateUserPoolClientRequest request, CancellationToken cancellationToken ) {
		return Provider.UpdateUserPoolClientAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateUserPoolDomainResponse> IAmazonCognitoIdentityProvider.UpdateUserPoolDomainAsync( UpdateUserPoolDomainRequest request, CancellationToken cancellationToken ) {
		return Provider.UpdateUserPoolDomainAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<VerifySoftwareTokenResponse> IAmazonCognitoIdentityProvider.VerifySoftwareTokenAsync( VerifySoftwareTokenRequest request, CancellationToken cancellationToken ) {
		return Provider.VerifySoftwareTokenAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<VerifyUserAttributeResponse> IAmazonCognitoIdentityProvider.VerifyUserAttributeAsync( VerifyUserAttributeRequest request, CancellationToken cancellationToken ) {
		return Provider.VerifyUserAttributeAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CompleteWebAuthnRegistrationResponse> IAmazonCognitoIdentityProvider.CompleteWebAuthnRegistrationAsync( CompleteWebAuthnRegistrationRequest request, CancellationToken cancellationToken ) {
		return Provider.CompleteWebAuthnRegistrationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateManagedLoginBrandingResponse> IAmazonCognitoIdentityProvider.CreateManagedLoginBrandingAsync( CreateManagedLoginBrandingRequest request, CancellationToken cancellationToken ) {
		return Provider.CreateManagedLoginBrandingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteManagedLoginBrandingResponse> IAmazonCognitoIdentityProvider.DeleteManagedLoginBrandingAsync( DeleteManagedLoginBrandingRequest request, CancellationToken cancellationToken ) {
		return Provider.DeleteManagedLoginBrandingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteWebAuthnCredentialResponse> IAmazonCognitoIdentityProvider.DeleteWebAuthnCredentialAsync( DeleteWebAuthnCredentialRequest request, CancellationToken cancellationToken ) {
		return Provider.DeleteWebAuthnCredentialAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeManagedLoginBrandingResponse> IAmazonCognitoIdentityProvider.DescribeManagedLoginBrandingAsync( DescribeManagedLoginBrandingRequest request, CancellationToken cancellationToken ) {
		return Provider.DescribeManagedLoginBrandingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeManagedLoginBrandingByClientResponse> IAmazonCognitoIdentityProvider.DescribeManagedLoginBrandingByClientAsync( DescribeManagedLoginBrandingByClientRequest request, CancellationToken cancellationToken ) {
		return Provider.DescribeManagedLoginBrandingByClientAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<GetUserAuthFactorsResponse> IAmazonCognitoIdentityProvider.GetUserAuthFactorsAsync( GetUserAuthFactorsRequest request, CancellationToken cancellationToken ) {
		return Provider.GetUserAuthFactorsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListWebAuthnCredentialsResponse> IAmazonCognitoIdentityProvider.ListWebAuthnCredentialsAsync( ListWebAuthnCredentialsRequest request, CancellationToken cancellationToken ) {
		return Provider.ListWebAuthnCredentialsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<StartWebAuthnRegistrationResponse> IAmazonCognitoIdentityProvider.StartWebAuthnRegistrationAsync( StartWebAuthnRegistrationRequest request, CancellationToken cancellationToken ) {
		return Provider.StartWebAuthnRegistrationAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateManagedLoginBrandingResponse> IAmazonCognitoIdentityProvider.UpdateManagedLoginBrandingAsync( UpdateManagedLoginBrandingRequest request, CancellationToken cancellationToken ) {
		return Provider.UpdateManagedLoginBrandingAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<CreateTermsResponse> IAmazonCognitoIdentityProvider.CreateTermsAsync( CreateTermsRequest request, CancellationToken cancellationToken ) {
		return Provider.CreateTermsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DeleteTermsResponse> IAmazonCognitoIdentityProvider.DeleteTermsAsync( DeleteTermsRequest request, CancellationToken cancellationToken ) {
		return Provider.DeleteTermsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<DescribeTermsResponse> IAmazonCognitoIdentityProvider.DescribeTermsAsync( DescribeTermsRequest request, CancellationToken cancellationToken ) {
		return Provider.DescribeTermsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<ListTermsResponse> IAmazonCognitoIdentityProvider.ListTermsAsync( ListTermsRequest request, CancellationToken cancellationToken ) {
		return Provider.ListTermsAsync( request, cancellationToken );
	}

	[ExcludeFromCodeCoverage]
	Task<UpdateTermsResponse> IAmazonCognitoIdentityProvider.UpdateTermsAsync( UpdateTermsRequest request, CancellationToken cancellationToken ) {
		return Provider.UpdateTermsAsync( request, cancellationToken );
	}
}
