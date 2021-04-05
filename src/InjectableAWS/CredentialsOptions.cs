using System;

namespace InjectableAWS {
	public sealed class CredentialsOptions : IEquatable<CredentialsOptions> {

		public string? CredentialsFile { get; set; }

		public bool Equals( CredentialsOptions? other ) {
			if( other is null ) {
				return false;
			}

			if( ReferenceEquals( other, this ) ) {
				return true;
			}

			return string.Equals( CredentialsFile, other.CredentialsFile, StringComparison.Ordinal );
		}

		public override bool Equals( object? obj ) {
			if( obj is not CredentialsOptions target ) {
				return false;
			}

			return Equals( target );
		}

		public override int GetHashCode() {
			return HashCode.Combine( CredentialsFile );
		}
	}
}
