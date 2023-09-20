using JsonDerivedType.Models;
using System.Text.Json;

namespace JsonDerivedType
{
    public class Program
    {
        static void Main(string[] args)
        {
            Member member = new Member() { BirthDate = DateTime.Now, Name = "Jhon"};
            var memberSerializer = JsonSerializer.Serialize(member);
            Member memberDeserialize = JsonSerializer.Deserialize<Member>(memberSerializer)!;

            Member student = new Student() { Name="Jhon",BirthDate=DateTime.Now,Courses = new List<string> {"PHP"},RegistrationYear=2023};    
            var studentSerializer = JsonSerializer.Serialize(student);
            Student studentDeserialize = JsonSerializer.Deserialize<Student>(studentSerializer)!;

            Console.ReadKey();
        }
    }
}