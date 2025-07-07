namespace Orders.Frontend.Repositories
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<T>> GetAsycn<T>(string url);
        Task<HttpResponseWrapper<object>> PostAsycn<T>(string url, T model);
        Task<HttpResponseWrapper<TActionResponse>> PostAsycn<T, TActionResponse>(string url, T model);
    }
}
