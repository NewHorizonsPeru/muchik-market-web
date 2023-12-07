using Blazored.SessionStorage;
using muchik.market.web.Helper;
using muchik.market.web.Models;

namespace muchik.market.web.HttpHandlers
{
	public class CustomHeaderHandler : DelegatingHandler
	{
		private readonly ISessionStorageService _sessionStorageService;

		public CustomHeaderHandler(ISessionStorageService sessionStorageService)
		{
			_sessionStorageService = sessionStorageService;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) 
		{
			var absolutePath = request.RequestUri?.AbsolutePath.ToLower();

			if(absolutePath!.Contains("signin") || absolutePath.Contains("signup"))
				return await base.SendAsync(request, cancellationToken);

			var currentUser = await _sessionStorageService.GetValueFromSessionStorage<User>("userData");

			if(currentUser != null)
			{
				request.Headers.Add("Authorization", $"Bearer {currentUser.Token}");
			}

			return await base.SendAsync (request, cancellationToken);
		}
	}
}
