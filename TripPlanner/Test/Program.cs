using Persistency.Implementations;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TripPlannerContext())
            {
                Console.WriteLine("it works");

                //db.Todos.Add(new Todo
                //{
                //    Id = Guid.NewGuid(),
                //    Description = "To solve the lab 4 - second shot",
                //    IsCompleted = false
                //});
                //var saveChanges = db.SaveChanges();
                //Console.WriteLine($"{saveChanges} recorded have been added");
            }
        }
    }
}
