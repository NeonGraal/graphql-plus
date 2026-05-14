using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Modelling;

internal class ModellerRepository
  : BaseRepository<IModellerRepository>
  , IModellerRepository
{
  private readonly ModellerRepositoryBuilder _builder;
  private readonly Lazy<IModifierModeller> _modifier;
  private readonly Lazy<ITypesModeller> _types;

  public ModellerRepository(ModellerRepositoryBuilder builder, ILoggerFactory loggerFactory)
    : base(loggerFactory)
  {
    _builder = builder;
    _modifier = new(() => builder._modifierFactory is not null
      ? builder._modifierFactory(this)
      : new ModifierModeller());
    _types = new(() => builder._typesFactory is not null
      ? builder._typesFactory(this)
      : new TypesModeller(this));
  }

  public Modeller<TAst, TModel>.D ModellerFor<TAst, TModel>([CallerMemberName] string callerName = "")
    where TAst : IAstError
    where TModel : IModelBase
    => () => Cached<IModeller<TAst, TModel>, IModeller<TAst, TModel>>(_builder.Modellers, "modeller for " + callerName, this);

  public DeferOne<IModifierModeller>.D ModifierModeller([CallerMemberName] string callerName = "")
    => () => _modifier.Value;
  public DeferOne<ITypesModeller>.D TypesModeller([CallerMemberName] string callerName = "")
    => () => _types.Value;
  public DeferList<ITypeModeller>.D TypeModellers([CallerMemberName] string callerName = "")
    => () => InstancesFor<ITypeModeller>(_builder.TypeModellerFactories, this);
}
