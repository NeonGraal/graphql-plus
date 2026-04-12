namespace GqlPlus.Encoding;

public interface IEncoderRepository
{
  IEncoder<T> EncoderFor<T>()
    where T : IModelBase;

  IEnumerable<ITypeEncoder> TypeEncoders { get; }
}
