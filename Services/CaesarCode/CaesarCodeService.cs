using System.Text;

namespace ShiftAPI.Services.CaesarCode
{
    public class CaesarCodeService : IEncoder
    {
        /// <summary>
        /// Набор доступных алфавитов
        /// </summary>
        public Dictionary<string, string> Alphabet { get => alphabets; }
        /// <summary>
        /// Ключ шифра - число сдвига (стандартный - 1)
        /// </summary>
        public int Key { get; set; } = 1;

        private Dictionary<string, string> alphabets;

        /// <summary>
        /// Дешифрует сообщение
        /// </summary>
        public string Decode(string input, string alphabetKey)
        {
            Key *= -1;
            string decodedString = Encode(input, alphabetKey);
            Key *= -1;
            return decodedString;
        }

        /// <summary>
        /// Шифрует сообщение
        /// </summary>
        public string Encode(string input, string alphabetKey)
        {
            StringBuilder output = new StringBuilder();

            string currentAlphabet = Alphabet[alphabetKey];

            foreach (char character in input)
            {
                if (currentAlphabet.Contains(character))
                {
                    output.Append(currentAlphabet[NewIndex(currentAlphabet, character)]);
                }
                else
                {
                    output.Append(character);
                }
            }

            return output.ToString();
        }

        /// <summary>
        /// Возвращает новый индекс сдвинутого символа
        /// </summary>
        private int NewIndex(string alphabet, char shiftedChar)
        {
            int rawIndex = alphabet.IndexOf(shiftedChar) + Key;


            if (rawIndex > alphabet.Length)
            {
                return rawIndex - alphabet.Length;
            }
            else if (rawIndex < 0)
            {
                int newIndex = rawIndex + alphabet.Length;
                while (newIndex < 0)
                {
                    newIndex += alphabet.Length;
                }
                return newIndex;
            }
            else
            {
                return rawIndex;
            }
        }

        public CaesarCodeService(CaesarOptions options)
        {
        }

    }
}
