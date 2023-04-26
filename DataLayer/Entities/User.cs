using DataLayer.Enums;

namespace DataLayer.Entities {
	public class User : BaseEntity {
		public string Name {
			get; set;
		}
		public string PasswordHash {
			get; set;
		}
		public string Email {
			get; set;
		}
		public Role Role {
			get; set;
		}
	}
}
