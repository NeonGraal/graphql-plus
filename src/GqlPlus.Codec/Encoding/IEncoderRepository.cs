namespace GqlPlus.Encoding;

internal interface IEncoderRepository
{
  IEncoder<T> EncoderFor<T>()
    where T : IModelBase;

  IEnumerable<ITypeEncoder> TypeEncoders { get; }
}
