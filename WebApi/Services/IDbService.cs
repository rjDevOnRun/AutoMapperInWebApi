using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IDbService
    {
        Task<List<T>> GetData<T>(string QUERY) where T : class;
    }
}