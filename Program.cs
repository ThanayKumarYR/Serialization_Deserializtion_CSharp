

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace SerializationDeserialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee() 
            {
                FirstName = "Thanay",
                LastName = "Kumar",
                Gender = "Male",
                Salary = 5000,
                Joined = new DateTime(2020,03,02)
            };

            Employee employee2 = new Employee()
            {
                FirstName = "Supritha",
                LastName = "Reddy",
                Gender = "Female",
                Salary = 7000,
                Joined = new DateTime(2018,07,28)
            };

            Employee employee3 = new Employee()
            {
                FirstName = "Lalitha",
                LastName = "Achar",
                Gender = "Female",
                Salary = 6000,
                Joined = new DateTime(2017,11,11)
            };

            List<Employee> employees = new List<Employee>() { employee1, employee2, employee3 };

            //To print the Json in its format (pretty printed) we use options
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;

            //Serialization : Converts Object to Json
            string JsonList = JsonSerializer.Serialize(employees,options);
            Console.WriteLine(JsonList);

            //Serialization : Converts Objects to UTF - 8 for better performance. 
            byte[] IncreasedPerformance = JsonSerializer.SerializeToUtf8Bytes(employees);
            foreach (byte item in IncreasedPerformance)
            {
                Console.Write(item + ", ");
            }

            File.WriteAllText("employees.json", JsonList);
        }
    }
}
