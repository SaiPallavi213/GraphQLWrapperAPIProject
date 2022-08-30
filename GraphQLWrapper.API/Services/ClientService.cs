using GraphQLWrapper.API.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GraphQLWrapper.API.Services
{
    /// <summary>
    ///  ClientService Class: This class implements interface IClientService
    /// </summary>
    public class ClientService : IClientService
    {
        //Public Rest Api to be accessed using GraphQL
        private string sBaseUrl = "https://dummy.restapiexample.com";

        //Employee Endpoint of the Public Rest Api containg the JSON data
        private string sEndpoint = "/api/v1/employees";

        //Http Client obejct to send request and recieve response from Employee Rest Api 
        public readonly HttpClient httpClientEmployee;       


        //Contructor to set the HttpClient object
        public ClientService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(sBaseUrl);

            httpClientEmployee = httpClient;
        }

        /// <summary>
        /// This method gets the queried data from the Public Rest Api
        /// </summary>        
        /// <returns>EmployeeList(asynchronously)</returns>
        public async Task<EmployeeList> GetAllAsync()
        {
            //getting the reponse from Public RestAPI endpoint
            var response = await httpClientEmployee.GetAsync(sEndpoint);

            //Checking of Http response was successfull
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();

                //Converting the JSON data from response to the Employee List data
                EmployeeList employees = JsonConvert.DeserializeObject<EmployeeList>(responseString);
                return employees;
            }
            //Returing empty list data in case response was unsuccessfull
            return new EmployeeList();

        }
    }
}
