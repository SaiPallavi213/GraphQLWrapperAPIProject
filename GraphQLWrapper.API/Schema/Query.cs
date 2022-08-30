using System.Threading;
using System.Threading.Tasks;
using GraphQLWrapper.API.Models;
using GraphQLWrapper.API.Services;
using HotChocolate;

namespace GraphQLWrapper.API.Schema
{
    /// <summary>
    ///  Query Class: This class has the GraphQL query call the Rest API
    /// </summary>
    public class Query
    {
        /// <summary>
        /// This method uses Hot Chocolate server to Query the Rest API Client service
        /// and get the data asynchronously
        /// </summary>
        /// <param name="service">Client Service</param>
        /// <param name="cancellationToken">Notification that the operation should be cancelled</param>
        /// <returns>EmployeeList(asynchronously)</returns>
        public async Task<EmployeeList> GetEmployeeAsync([Service] ClientService service,CancellationToken cancellationToken)
        {
            return await service.GetAllAsync();
        }
    }
}
