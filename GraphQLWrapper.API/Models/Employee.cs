using Newtonsoft.Json;

namespace GraphQLWrapper.API.Models
{
    /// <summary>
    /// Employee Class: This class contains the model data for the Employee endpoint of the Rest API 
    /// </summary>
    public class Employee
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "employee_name")]
        public string EmployeeName { get; set; }

        [JsonProperty(PropertyName = "employee_salary")]
        public string EmployeeSalary { get; set; }

        [JsonProperty(PropertyName = "employee_age")]
        public string EmployeeAge { get; set; }

        [JsonProperty(PropertyName = "profile_image")]
        public string ProfileImage { get; set; }
    }
}
