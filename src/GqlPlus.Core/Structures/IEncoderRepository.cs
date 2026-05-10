using System.Runtime.CompilerServices;

namespace GqlPlus.Structures;

public interface IEncoderRepository
  : IRepository
{
  Defer<IEncoder<T>>.D EncoderFor<T>([CallerMemberName] string callerName = "");
  Defer<TList>.DA EncodersFor<TList>([CallerMemberName] string callerName = "")
    where TList : class;
}
