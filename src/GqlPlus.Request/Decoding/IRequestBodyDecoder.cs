namespace GqlPlus.Decoding;

public interface IRequestBodyDecoder
{
  RequestBodyInput Decode(Structured body);
}
