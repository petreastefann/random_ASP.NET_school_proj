using Core.Dtos;
using DataLayer;
using DataLayer.Entities;

namespace Core.Services {
	public class UserService {
		private readonly UnitOfWork unitOfWork;

		private AuthService authService {
			get; set;
		}

		public UserService(UnitOfWork unitOfWork, AuthService authService) {
			this.unitOfWork = unitOfWork;
			this.authService = authService;
		}
		public void Register(RegisterDto registerData) {
			if(registerData == null) {
				return;
			}

			var hashedPassword = authService.HashPassword(registerData.Password);

			var user = new User {
				Name = registerData.Name,
				Email = registerData.Email,
				PasswordHash = hashedPassword,
			};

			unitOfWork.Users.Insert(user);
			unitOfWork.SaveChanges();
		}

		public string GetRole(User user) {
			return user.Role.ToString();
		}

		public string Validate(LoginDto payload) {
			var student = unitOfWork.Users.GetByEmail(payload.Email);

			var passwordFine = authService.VerifyHashedPassword(student.PasswordHash, payload.Password);

			if(passwordFine) {
				var role = GetRole(student);

				return authService.GetToken(student, role);
			}
			else {
				return null;
			}

		}
	}
}
