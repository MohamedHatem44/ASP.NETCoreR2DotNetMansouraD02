using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreD02.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        //[Range(1000, 3000)]
        //[Required] => Day 4
        public decimal Salary { get; set; }
    }
}
