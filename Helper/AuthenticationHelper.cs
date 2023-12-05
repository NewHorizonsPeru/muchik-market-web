using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using muchik.market.web.Models;
using System.Security.Claims;

namespace muchik.market.web.Helper
{
	public class AuthenticationHelper : AuthenticationStateProvider
	{
		private readonly ISessionStorageService _sessionStorageService;
		private ClaimsPrincipal claimEmpty = new ClaimsPrincipal(new ClaimsIdentity());

		public AuthenticationHelper(ISessionStorageService sessionStorageService)
		{
			_sessionStorageService = sessionStorageService;
		}

		public async Task UpdateStateFromAuthentication(User? currentUser) 
		{
			ClaimsPrincipal claimsPrincipal;

			if(currentUser == null)
			{
				claimsPrincipal = claimEmpty;
				await _sessionStorageService.RemoveItemAsync("userData");
			}
			else
			{
				claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
				{
					new Claim(ClaimTypes.Email, currentUser.Email),
					new Claim(ClaimTypes.Sid, currentUser.Id),
					new Claim(ClaimTypes.Role, currentUser.Role.Name),
				}, "JwtAuth"));

				await _sessionStorageService.AddValueToSessionStorage<User>("userData", currentUser);
			}

			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var currentUser = await _sessionStorageService.GetValueFromSessionStorage<User>("userData");
			if (currentUser == null) { 
				return await Task.FromResult(new AuthenticationState(claimEmpty)); 
			}

			var claimIdentity = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
			{
				new Claim(ClaimTypes.Email, currentUser.Email),
				new Claim(ClaimTypes.Sid, currentUser.Id),
				new Claim(ClaimTypes.Role, currentUser.Role.Name),
			}, "JwtAuth"));

			return await Task.FromResult(new AuthenticationState(claimIdentity));
		}
	}
}
