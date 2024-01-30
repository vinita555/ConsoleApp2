using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class RecommendationSystem
    {
        static void Main()
        {
            // Sample user-item preference data
            Dictionary<string, Dictionary<string, int>> userPreferences = new Dictionary<string, Dictionary<string, int>>
        {
            {"User1", new Dictionary<string, int> { {"Movie1", 5}, {"Movie2", 4}, {"Movie3", 0}, {"Movie4", 2} }},
            {"User2", new Dictionary<string, int> { {"Movie1", 0}, {"Movie2", 5}, {"Movie3", 4}, {"Movie4", 0} }},
            {"User3", new Dictionary<string, int> { {"Movie1", 2}, {"Movie2", 0}, {"Movie3", 5}, {"Movie4", 4} }},
            {"User4", new Dictionary<string, int> { {"Movie1", 4}, {"Movie2", 2}, {"Movie3", 0}, {"Movie4", 5} }}
        };

            string targetUser = "User1";
            Dictionary<string, double> recommendations = GetRecommendations(userPreferences, targetUser);

            Console.WriteLine($"Recommendations for {targetUser}:");
            foreach (var recommendation in recommendations.OrderByDescending(r => r.Value))
            {
                Console.WriteLine($"{recommendation.Key}: {recommendation.Value}");
            }
        }

        static Dictionary<string, double> GetRecommendations(Dictionary<string, Dictionary<string, int>> userPreferences, string targetUser)
        {
            // Calculate cosine similarity between users
            Dictionary<string, double> userSimilarity = new Dictionary<string, double>();
            foreach (var user in userPreferences.Keys)
            {
                if (user != targetUser)
                {
                    double similarity = CalculateCosineSimilarity(userPreferences[targetUser], userPreferences[user]);
                    userSimilarity[user] = similarity;
                }
            }

            // Identify unrated items and recommend the top ones
            Dictionary<string, double> recommendations = new Dictionary<string, double>();
            foreach (var item in userPreferences[targetUser].Keys)
            {
                if (userPreferences[targetUser][item] == 0)
                {
                    double weightedSum = 0;
                    double similaritySum = 0;

                    foreach (var otherUser in userSimilarity.Keys)
                    {
                        if (userPreferences[otherUser].ContainsKey(item))
                        {
                            weightedSum += userSimilarity[otherUser] * userPreferences[otherUser][item];
                            similaritySum += Math.Abs(userSimilarity[otherUser]);
                        }
                    }

                    double weightedAverage = (similaritySum == 0) ? 0 : weightedSum / similaritySum;
                    recommendations[item] = weightedAverage;
                }
            }

            return recommendations;
        }

        static double CalculateCosineSimilarity(Dictionary<string, int> user1, Dictionary<string, int> user2)
        {
            // Calculate cosine similarity between two users
            double dotProduct = 0;
            double normUser1 = 0;
            double normUser2 = 0;

            foreach (var item in user1.Keys)
            {
                if (user2.ContainsKey(item))
                {
                    dotProduct += user1[item] * user2[item];
                }
                normUser1 += Math.Pow(user1[item], 2);
            }

            foreach (var rating in user2.Values)
            {
                normUser2 += Math.Pow(rating, 2);
            }

            double similarity = (normUser1 == 0 || normUser2 == 0) ? 0 : dotProduct / (Math.Sqrt(normUser1) * Math.Sqrt(normUser2));
            return similarity;
        }
    }


}
