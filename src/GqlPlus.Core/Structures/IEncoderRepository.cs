using System.Runtime.CompilerServices;

namespace GqlPlus.Structures;

public interface IEncoderRepository
{
  IEncoder<T> EncoderFor<T>([CallerMemberName] string callerName = "");
  IEnumerable<TList> EncodersFor<TList>([CallerMemberName] string callerName = "")
    where TList : class;
}
