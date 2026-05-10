namespace GqlPlus.Modelling;

internal class ModellerRepositoryBuilder
  : BaseFactory<IModellerRepository>, IModellerRepositoryBuilder
{
  // Keyed by typeof(IModeller<TAst, TModel>)
  internal readonly FactoryDict Modellers = [];
  internal readonly FactoryList TypeModellerFactories = [];
  internal Factory<IModifierModeller, IModellerRepository>? _modifierFactory;
  internal Factory<ITypesModeller, IModellerRepository>? _typesFactory;

  public IEnumerable<KeyValuePair<Type, Factory<object, IModellerRepository>>> AllFactories
    => [.. Modellers,
      FactoryKeyValue<IModifierModeller>(_modifierFactory!),
      FactoryKeyValue<ITypesModeller>(_typesFactory!),
      .. TypeModellerFactories.Select(FactoryKeyValue<ITypeModeller>)];

  public IModellerRepositoryBuilder AddModeller<TAst, TModel>(Factory<IModeller<TAst, TModel>, IModellerRepository> factory)
    where TAst : IAstError
    where TModel : IModelBase
    => this.FluentAction(b => b.Modellers[typeof(IModeller<TAst, TModel>)] = factory);

  public IModellerRepositoryBuilder AddTypeModeller<TAst, TModel>(Factory<ITypeModeller<TAst, TModel>, IModellerRepository> factory)
    where TAst : IAstError
    where TModel : IModelBase
    => this.FluentAction(b => {
      b.Modellers[typeof(IModeller<TAst, TModel>)] = factory;
      b.TypeModellerFactories.Add(r => (ITypeModeller)(object)(Modeller<TAst, TModel>)r.ModellerFor<TAst, TModel>());
    });

  public IModellerRepositoryBuilder AddModifierModeller(Factory<IModifierModeller, IModellerRepository> factory)
    => this.FluentAction(b => b._modifierFactory = factory);

  public IModellerRepositoryBuilder AddTypesModeller(Factory<ITypesModeller, IModellerRepository> factory)
    => this.FluentAction(b => b._typesFactory = factory);
}
