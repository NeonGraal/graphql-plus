namespace GqlPlus.Structures;

public interface IEncoderRepositoryBuilder
{
  IEncoderRepositoryBuilder AddEncoder<TModel>(Factory<IEncoder<TModel>, IEncoderRepository> factory);
  IEncoderRepositoryBuilder AddListEncoder<TList, TEncoder, TModel>(Factory<TEncoder, IEncoderRepository> factory)
    where TEncoder : class, IEncoder<TModel>, TList;
}
