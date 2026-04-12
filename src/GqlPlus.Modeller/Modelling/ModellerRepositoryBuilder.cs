namespace GqlPlus.Modelling;

internal class ModellerRepositoryBuilder
  : BaseFactory<IModellerRepository>, IModellerRepositoryBuilder
{
  // Keyed by typeof(IModeller<TAst, TModel>)
  internal readonly FactoryDict Modellers = [];
  internal readonly FactoryList TypeModellerFactories = [];
  internal Factory<IModifierModeller, IModellerRepository>? ModifierFactory;
  internal Factory<ITypesModeller, IModellerRepository>? TypesFactory;

  public IModellerRepositoryBuilder AddModeller<TAst, TModel>(Factory<IModeller<TAst, TModel>, IModellerRepository> factory)
    where TAst : IAstError
    where TModel : IModelBase
    => this.FluentAction(b => b.Modellers[typeof(IModeller<TAst, TModel>)] = factory);

  public IModellerRepositoryBuilder AddTypeModeller<TAst, TModel>(Factory<ITypeModeller, IModellerRepository> factory)
    where TAst : IAstError
    where TModel : IModelBase
    => this.FluentAction(b => {
      b.Modellers[typeof(IModeller<TAst, TModel>)] = factory;
      b.TypeModellerFactories.Add(r => (ITypeModeller)(object)r.ModellerFor<TAst, TModel>());
    });

  public IModellerRepositoryBuilder AddModifierModeller(Factory<IModifierModeller, IModellerRepository> factory)
    => this.FluentAction(b => b.ModifierFactory = factory);

  public IModellerRepositoryBuilder AddTypesModeller(Factory<ITypesModeller, IModellerRepository> factory)
    => this.FluentAction(b => b.TypesFactory = factory);
}
