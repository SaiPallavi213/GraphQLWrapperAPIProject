using GraphQLWrapper.API.Models;
using System.Threading.Tasks;

namespace GraphQLWrapper.API.Services
{
    /// <summary>
    ///  Interface for Client Services
    /// </summary>
    interface IClientService
    {
        Task<EmployeeList> GetAllAsync();
    }
}
