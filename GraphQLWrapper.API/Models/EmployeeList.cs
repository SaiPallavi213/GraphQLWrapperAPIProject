using Newtonsoft.Json;
using System.Collections.Generic;


namespace GraphQLWrapper.API.Models
{
    /// <summary>
    ///  EmployeeList Class: This class contains the List of Employee class data
    /// </summary>
    public class EmployeeList
    {
        [JsonProperty(PropertyName = "data")]
        public List<Employee> Data { get; set; }
    }
}
