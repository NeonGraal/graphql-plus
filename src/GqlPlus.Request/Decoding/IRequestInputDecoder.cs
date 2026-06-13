namespace GqlPlus.Request.Decoding;

public interface IRequestInputDecoder
{
  DecodedRequest Decode(string input);
}
