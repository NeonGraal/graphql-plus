using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Modelling;

internal sealed class ModellerRepoWrapper(
  IModellerRepository repo
) : RepositoryWrapperBase<IModellerRepository, ModellerRepoWrapper>(repo)
  , IModellerRepository
{
  public override IModellerRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public IEnumerable<ITypeModeller> TypeModellers
    => AddRelationship<ITypeModeller>(CallerName)
      .TypeModellers;

  public IModifierModeller ModifierModeller
    => AddRelationship<IModifierModeller>(CallerName)
      .ModifierModeller;

  public ITypesModeller TypesModeller
    => AddRelationship<ITypesModeller>(CallerName)
      .TypesModeller;

  public static void WriteTree(ILoggerFactory loggerFactory,
    Action<IModellerRepositoryBuilder> configureModellers)
  {
    ModellerRepositoryBuilder repoBuilder = new();
    configureModellers(repoBuilder);

    ModellerRepoWrapper repo = new(new ModellerRepository(repoBuilder, loggerFactory));
    repo.WriteFactories("Modeller", repoBuilder.AllFactories);
  }

  public IModeller<TAst, TModel> ModellerFor<TAst, TModel>([CallerMemberName] string callerName = "")
    where TAst : IAstError
    where TModel : IModelBase
    => AddRelationship<TModel>(callerName)
      .ModellerFor<TAst, TModel>(callerName);
}
