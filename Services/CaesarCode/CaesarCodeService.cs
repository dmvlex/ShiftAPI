using Microsoft.Extensions.Options;
using System.Text;

namespace ShiftAPI.Services.CaesarCode
{
    public class CaesarCodeService : IEncoder
    {
        /// <summary>
        /// Набор доступных алфавитов
        /// </summary>
        public Dictionary<string, string> Alphabet { get => alphabets; }

        private Dictionary<string, string> alphabets;

        /// <summary>
        /// Дешифрует сообщение
        /// </summary>
        public string Decode(CaesarDTO data)
        {
            data.Key *= -1;
            string decodedString = Encode(data);
            data.Key *= -1;
            return decodedString;
        }

        /// <summary>
        /// Шифрует сообщение
        /// </summary>
        public string Encode(CaesarDTO data)
        {
            StringBuilder output = new StringBuilder();

            string currentAlphabet = Alphabet[data.AlphabetKey];

            foreach (char character in data.Input)
            {
                if (currentAlphabet.Contains(character))
                {
                    output.Append(currentAlphabet[NewIndex(currentAlphabet, character,data.Key)]);
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
        private int NewIndex(string alphabet, char shiftedChar, int key)
        {
            int rawIndex = alphabet.IndexOf(shiftedChar) + key;


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
            alphabets = options.Alphabets;
        }

    }
}
