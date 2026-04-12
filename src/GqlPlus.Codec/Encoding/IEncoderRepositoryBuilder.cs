namespace GqlPlus.Encoding;

internal interface IEncoderRepositoryBuilder
{
  IEncoderRepositoryBuilder AddEncoder<TModel>(Factory<IEncoder<TModel>, IEncoderRepository> factory)
    where TModel : IModelBase;

  IEncoderRepositoryBuilder AddTypeEncoder<TModel>(Factory<ITypeEncoder<TModel>, IEncoderRepository> factory)
    where TModel : IModelBase;
}
