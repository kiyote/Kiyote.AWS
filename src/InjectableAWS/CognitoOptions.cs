using System;

namespace InjectableAWS {
	public sealed class CognitoOptions<T> : IEquatable<CognitoOptions<T>> {

		public string? CredentialsProfile { get; set; }

		public string? ClientId { get; set; }

		public string? RegionEndpoint { get; set; }

		public string? ServiceUrl { get; set; }

		public string? Role { get; set; }

		public bool Equals( CognitoOptions<T>? other ) {
			if( other is null ) {
				return false;
			}

			if( ReferenceEquals( other, this ) ) {
				return true;
			}

			return string.Equals( CredentialsProfile, other.CredentialsProfile, StringComparison.Ordinal )
				&& string.Equals( ClientId, other.ClientId, StringComparison.Ordinal )
				&& string.Equals( RegionEndpoint, other.RegionEndpoint, StringComparison.Ordinal )
				&& string.Equals( ServiceUrl, other.ServiceUrl, StringComparison.Ordinal )
				&& string.Equals( Role, other.Role, StringComparison.Ordinal );
		}

		public override bool Equals( object? obj ) {
			if(  obj is not CognitoOptions<T> target ) {
				return false;
			}

			return Equals( target );
		}

		public override int GetHashCode() {
			return HashCode.Combine( CredentialsProfile, ClientId, RegionEndpoint, ServiceUrl, Role );
		}
	}

}
