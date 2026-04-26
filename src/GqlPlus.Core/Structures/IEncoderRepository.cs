namespace GqlPlus.Structures;

public interface IEncoderRepository
{
  IEncoder<T> EncoderFor<T>();
  IEnumerable<TList> EncodersFor<TList>()
    where TList : class;
}
