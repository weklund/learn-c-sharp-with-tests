using System.Collections.Generic;

namespace LearnCSharp.Solutions
{
    public static class HelloWorld
    {

        private static string Greeting(string language)
        {
            var greetings = new Dictionary<string, string>{
                ["Spanish"] = "Hola",
                ["French"] = "Bonjour"
            };

            if (greetings.ContainsKey(language))
            {
                return greetings[language];
            }

            return "Hello";
        }

        public static string Greet(string name, string language)
        {
	        return name == "" ? $"{Greeting(language)}, World" : $"{Greeting(language)}, {name}";
        }

    }
}
