using Microsoft.Extensions.Logging;

namespace GqlPlus.Modelling;

internal class ModellerRepository
  : BaseRepository<IModellerRepository>
  , IModellerRepository
{
  private readonly ModellerRepositoryBuilder _builder;
  private readonly Lazy<IModifierModeller> _modifier;
  private readonly Lazy<ITypesModeller> _types;
  private readonly Lazy<IEnumerable<ITypeModeller>> _typeModellers;

  public ModellerRepository(ModellerRepositoryBuilder builder, ILoggerFactory loggerFactory)
    : base(loggerFactory)
  {
    _builder = builder;
    _modifier = new(() => builder.ModifierFactory is not null
      ? builder.ModifierFactory(this)
      : new ModifierModeller());
    _types = new(() => builder.TypesFactory is not null
      ? builder.TypesFactory(this)
      : new TypesModeller(this));
    _typeModellers = new(() => [.. builder.TypeModellerFactories.Select(f => (ITypeModeller)f(this))]);
  }

  public IModeller<TAst, TModel> ModellerFor<TAst, TModel>()
    where TAst : IAstError
    where TModel : IModelBase
    => Cached<IModeller<TAst, TModel>, IModeller<TAst, TModel>>(_builder.Modellers, "modeller", this);

  public IModifierModeller ModifierModeller => _modifier.Value;
  public ITypesModeller TypesModeller => _types.Value;
  public IEnumerable<ITypeModeller> TypeModellers => _typeModellers.Value;
}
