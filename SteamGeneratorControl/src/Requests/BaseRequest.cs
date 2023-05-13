using System.Text;
using Newtonsoft.Json;

namespace SteamGeneratorControl.Requests;

public abstract class BaseRequest<TEntity, TCreate, TUpdate, TRequest> : Singletone<TRequest> where TRequest : new()
{
	protected abstract string Endpoint { get; }
	private static TRequest? _instance;
	private HttpClient _httpClient = new();

	public new static TRequest GetInstance()
	{
		if (_instance == null)
			_instance = new TRequest();
		return _instance;
	}

	public async Task<TEntity[]?> Get()
	{
		var url = $"{Utils.URL}{Endpoint}";
		var response = await _httpClient.GetAsync(url);

		if (!response.IsSuccessStatusCode)
			return null;

		var jsonResponse = await response.Content.ReadAsStringAsync();
		var deserializedProduct = JsonConvert.DeserializeObject<TEntity[]>(jsonResponse);
		return deserializedProduct;
	}

	public async Task Post(TCreate entity)
	{
		var url = $"{Utils.URL}{Endpoint}";
		var json = JsonConvert.SerializeObject(entity);
		var content = new StringContent(json, Encoding.UTF8, "application/json");
		var response = await _httpClient.PostAsync(url, content);

		if (!response.IsSuccessStatusCode)
			return;
	}

	public async Task Put(TUpdate entity, Guid guid)
	{
		var url = $"{Utils.URL}{Endpoint}/{guid}";
		var json = JsonConvert.SerializeObject(entity);
		var content = new StringContent(json, Encoding.UTF8, "application/json");
		var response = await _httpClient.PutAsync(url, content);

		if (!response.IsSuccessStatusCode)
			return;
	}

	public async Task Delete(Guid guid)
	{
		var url = $"{Utils.URL}{Endpoint}/{guid}";
		Console.WriteLine($"Server: Удаление {guid}");
		var response = await _httpClient.DeleteAsync(url);
		if (!response.IsSuccessStatusCode)
			return;
	}
}