using System.Runtime.CompilerServices;

namespace GqlPlus.Structures;

public interface IDecoderRepository
  : IRepository
{
  Defer<IDecoder<T>>.D DecoderFor<T>([CallerMemberName] string callerName = "");
  Defer<TDecoder>.D DecoderFor<TDecoder, TBase>([CallerMemberName] string callerName = "")
    where TDecoder : class, IDecoder<TBase>;
}
