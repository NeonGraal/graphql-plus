using System.Runtime.CompilerServices;

namespace GqlPlus.Structures;

public interface IDecoderRepository
  : IRepository
{
  Decoder<T>.D DecoderFor<T>([CallerMemberName] string callerName = "");
  DeferOne<TDecoder>.D DecoderFor<TDecoder, TBase>([CallerMemberName] string callerName = "")
    where TDecoder : class, IDecoder<TBase>;
}
