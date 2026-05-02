using System.Runtime.CompilerServices;

namespace GqlPlus.Structures;

public interface IDecoderRepository
{
  IDecoder<T> DecoderFor<T>([CallerMemberName] string callerName = "");
  TDecoder DecoderFor<TDecoder, TBase>([CallerMemberName] string callerName = "")
    where TDecoder : class, IDecoder<TBase>;
}
