using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class chatbot
    {
        class Chatbot
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Welcome to the Chatbot!");

                while (true)
                {
                    Console.Write("User: ");
                    string input = Console.ReadLine();

                    string response = GetResponse(input);
                    Console.WriteLine("Chatbot: " + response);
                }
            }

            static string GetResponse(string input)
            {
                string response = "";
                if (input.ToLower().Contains("hello"))
                {
                    response = "Hello! How can I assist you today?";
                }
                else if (input.ToLower().Contains("goodbye"))
                {
                    response = "Goodbye! Have a great day!";
                }
                else if (input.ToLower().Contains("thank you"))
                {
                    response = "You're welcome! It was my pleasure to help.";
                }
                else
                {
                    response = "I'm sorry, I didn't understand. Can you please rephrase?";
                }

                return response;
            }
        }
    }
}
