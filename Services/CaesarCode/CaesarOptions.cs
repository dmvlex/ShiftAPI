using Microsoft.Extensions.Options;

namespace ShiftAPI.Services.CaesarCode
{
    public class CaesarOptions
    {
        /// <summary>
        /// Aphabets KEY - Aplphabet Name, Value - Alphabet string
        /// </summary>
        public Dictionary<string, string> Alphabets = new Dictionary<string, string>();
        private const string SYMBOLS = @"!?*()$%#@<>/\[]{}.,^;:№-_+=~` ";

        public CaesarOptions AddAlphabet(string key,string alphabetString)
        {
            Alphabets[key] = SYMBOLS+alphabetString;

            return this;
        }
    }
}
