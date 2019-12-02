using System.Collections.Generic;

namespace LearnCSharp.Solutions
{
    public static class HelloWorld
    {
            
        private static string Greeting(string language) 
        {
            var greetings = new Dictionary<string, string>{
                ["es"] = "Hola",
                ["fr"] = "Bonjour"
            };
            
            if (greetings.ContainsKey(language))
            {
                return greetings[language];
            }
    
            return "Hello";
        }
        
        public static string Greet(string language, string name = "World")
        {
            return $"{Greeting(language)}, {name}";
        }

    }
}
