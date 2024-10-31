namespace Evolve.ITR.ServiceContract.Abstractions
{
    public interface IDbResultCacheService
    {
        T GetDataForQuery<T>(string query);
        void StoreDataForQuery<T>(string query, T resultJson, TimeSpan? ttl);
    }
}
