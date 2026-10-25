namespace GqlPlus.Decoding;

public interface IRequestBodyDecoder
{
  RequestBodyInput Decode(IGqlpValue body);
}
