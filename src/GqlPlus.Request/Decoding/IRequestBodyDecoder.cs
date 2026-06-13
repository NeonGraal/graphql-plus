using GqlPlus.Structures;

namespace GqlPlus.Request.Decoding;

public interface IRequestBodyDecoder
{
  RequestBodyInput Decode(Structured body);
}
