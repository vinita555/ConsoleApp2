using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class recommendations_system
    {
        public List<string> GetRecommendations(string userId)
        {
            // Implementation logic for generating recommendations based on user ID
            if (userId == "user123")
            {
                List<string> obj = new List<string>() { "Book,movies,or products" };
                Console.Write("Recommended items: ");
                foreach (string item in obj)
                {
                    Console.Write(item + ", ");
                }
            }
            else
                Console.WriteLine("Invalid UserId");
            return new List<string>();
        }
    }

    public class PProgram
    {
        public static void Main(string[] args)
        {
            recommendations_system recommendationSystem = new recommendations_system();
            Console.WriteLine("Enter user id: ");
            string id = Console.ReadLine();
            // Get recommendations for a specific user
            List<string> recommendations = recommendationSystem.GetRecommendations(id);


            // Display the recommendations
            //foreach (string item in recommendations)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
