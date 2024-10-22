using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IAuthService
	{
		IEnumerable<IdentityRole> Roles { get; }
		IEnumerable<IdentityUser> GettAllUsers();
		Task<UserDtoForUpdate> GetOneUserDtoForUpdate(string userName);
		Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
		Task<IdentityUser> GetOneUser(string username);
		Task Update(UserDtoForUpdate userDto);
		Task<IdentityResult> ResetPassword(ResetPaswordDto model);
		Task<IdentityResult> UserDelete(string userName);
	}
}