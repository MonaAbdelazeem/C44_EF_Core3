using EF_Core3.Data;
using EF_Core3.Models;

namespace EF_Core3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ITIDbContext();

            context.Students.Add(new Student { FName = "Mona", LName = "Ahmed", Age = 21 });
            context.SaveChanges();

            Console.WriteLine("Student added successfully!");
        }
    }
}
