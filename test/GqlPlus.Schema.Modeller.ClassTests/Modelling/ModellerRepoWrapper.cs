using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Modelling;

internal sealed class ModellerRepoWrapper(
  IModellerRepository repo
) : RepositoryWrapperBase<IModellerRepository, ModellerRepoWrapper>(repo)
  , IModellerRepository
{
  protected override IModellerRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public Defer<ITypeModeller>.DA TypeModellers([CallerMemberName] string callerName = "")
    => AddRelationship<ITypeModeller>(callerName)
      .TypeModellers(callerName);

  public Defer<IModifierModeller>.D ModifierModeller([CallerMemberName] string callerName = "")
    => AddRelationship<IModifierModeller>(callerName)
      .ModifierModeller(callerName);

  public Defer<ITypesModeller>.D TypesModeller([CallerMemberName] string callerName = "")
    => AddRelationship<ITypesModeller>(callerName)
      .TypesModeller(callerName);

  public static void WriteTree(ILoggerFactory loggerFactory,
    Action<IModellerRepositoryBuilder> configureModellers)
  {
    ModellerRepositoryBuilder repoBuilder = new();
    configureModellers(repoBuilder);

    ModellerRepoWrapper repo = new(new ModellerRepository(repoBuilder, loggerFactory));
    repo.WriteFactories("Modeller", repoBuilder.AllFactories);
  }

  public Defer<IModeller<TAst, TModel>>.D ModellerFor<TAst, TModel>([CallerMemberName] string callerName = "")
    where TAst : IAstError
    where TModel : IModelBase
    => AddRelationship<TModel>(callerName)
      .ModellerFor<TAst, TModel>(callerName);
}
