namespace StoreApp.Infrastructure.Extensions
{

	// Bu yöntem, bir HTTP isteği (request) aldığında, isteğin yolunu (path) ve sorgu dizesini (query string) birleştirerek döndürür.
	public static class HttpRequestExtension
	{
		public static string PathAndQuery(this HttpRequest request)
		{
			return request.QueryString.HasValue
				? $"{request.Path}{request.QueryString}"
				: request.Path.ToString();
		}
	}
}
