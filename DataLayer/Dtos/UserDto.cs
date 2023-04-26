﻿namespace DataLayer.Dtos {
	internal class UserDto {
		public int Id {
			get; set;
		}
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
		public string RoleName {
			get; set;
		}
	}
}
