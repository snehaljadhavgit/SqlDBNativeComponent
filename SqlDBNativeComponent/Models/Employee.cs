using System;
using Newtonsoft.Json;
namespace SqlDBNativeComponent
{
    public class Employee
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Email")]
        public string EmailId { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("DOB")]
        public string DOB { get; set; }

        [JsonIgnore]
        public string EmployeeDOB
        {
            get
            {
                if (!string.IsNullOrEmpty(DOB))
                {
                    try
                    {
                        var employeeDOB = Convert.ToDateTime(DOB).ToString("dd MMM yyyy");

                        if (!string.IsNullOrEmpty(employeeDOB))
                            return employeeDOB;
                    }
                    catch (FormatException)
                    {
                        return string.Empty;
                    }
                }

                return string.Empty;
            }
        }
    }
}