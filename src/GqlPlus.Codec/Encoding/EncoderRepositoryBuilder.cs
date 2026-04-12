namespace GqlPlus.Encoding;

internal class EncoderRepositoryBuilder
  : BaseFactory<IEncoderRepository>, IEncoderRepositoryBuilder
{
  internal readonly FactoryDict Encoders = [];
  internal readonly FactoryList TypeEncoderFactories = [];

  public IEncoderRepositoryBuilder AddEncoder<TModel>(Factory<IEncoder<TModel>, IEncoderRepository> factory)
    where TModel : IModelBase
    => this.FluentAction(b => b.Encoders[typeof(TModel)] = factory);

  public IEncoderRepositoryBuilder AddTypeEncoder<TModel>(Factory<ITypeEncoder, IEncoderRepository> factory)
    where TModel : IModelBase
    => this.FluentAction(b => {
      b.Encoders[typeof(TModel)] = factory;
      b.TypeEncoderFactories.Add(r => r.EncoderFor<TModel>());
    });
}
