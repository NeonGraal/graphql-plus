namespace GqlPlus.Decoding;

public interface IRequestInputDecoder
{
  DecodedRequest Decode(string input);
}
