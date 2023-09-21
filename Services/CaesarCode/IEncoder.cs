namespace ShiftAPI.Services.CaesarCode
{
    public interface IEncoder
    {
        public string Decode(CaesarDTO data);
        public string Encode(CaesarDTO data);
    }
}
