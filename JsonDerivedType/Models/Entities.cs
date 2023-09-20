using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JsonDerivedType.Models
{
    [JsonDerivedType(typeof(Student),"student")]
    [JsonDerivedType(typeof(Professor),"professor")]
    public class Member
    {
        public string? Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
    public class Student : Member
    {
        public int RegistrationYear { get; set; }

        public List<string> Courses { get; set; } = new List<string>();
    }
    public class Professor : Member
    {
        public string? Rank { get; set; }

        public bool IsTenured { get; set; }
    }
}
