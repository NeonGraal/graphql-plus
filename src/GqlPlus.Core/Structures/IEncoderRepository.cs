using System.Runtime.CompilerServices;

namespace GqlPlus.Structures;

public interface IEncoderRepository
  : IRepository
{
  Encoder<T>.D EncoderFor<T>([CallerMemberName] string callerName = "");
  DeferList<TList>.D EncodersFor<TList>([CallerMemberName] string callerName = "")
    where TList : class;
}
