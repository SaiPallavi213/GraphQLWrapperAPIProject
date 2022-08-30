using GraphQLWrapper.API.Models;
using System.Collections.Generic;

namespace MockGraphQLApiTest.MockData
{
    /// <summary>
    /// EmployeeMock Class: This class contains the mock data for the Employee endpoint of the Rest API 
    /// </summary>
    public class EmployeeMock
    {
        public static EmployeeList Get()
        {
            return new EmployeeList
            {                
                Data = new List<Employee>
            {
                new Employee
                {
                     Id="123",
                     EmployeeName ="TestEmployee",
                     EmployeeSalary="65000",
                     EmployeeAge="45",
                     ProfileImage=""
                }
            }
            };
        }
    }
}
