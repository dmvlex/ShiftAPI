namespace ShiftAPI.Services.CaesarCode
{
    public interface IEncoder
    {
        public string Decode(string input, string alphabetKey);
        public string Encode(string input, string alphabetKey)
    }
}
