namespace LearnCSharp.Solutions
{
    public class Iteration
    {
        private const int RepeatCount = 3;

        public static string Repeat(string character)
        {
            var repeated = "";

            for (var i = 0; i <= RepeatCount; i++)
            {
                repeated += character;
            }

            return repeated;
        }
    }
}
