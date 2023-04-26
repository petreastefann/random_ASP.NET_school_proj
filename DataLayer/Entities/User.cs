﻿using DataLayer.Enums;

namespace DataLayer.Entities {
	public class User : BaseEntity {
		public string Username {
			get; set;
		}
		public string PasswordHash {
			get; set;
		}
		public string Email {
			get; set;
		}
		public int RoleId {
			get; set;
		}
		public Role Role {
			get; set;
		}
	}
}
