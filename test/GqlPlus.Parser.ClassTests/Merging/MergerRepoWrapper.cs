using GqlPlus.Ast.Schema;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Merging;

internal sealed class MergerRepoWrapper(
  IMergerRepository repo
) : RepositoryWrapperBase<IMergerRepository, MergerRepoWrapper>(repo)
  , IMergerRepository
{
  protected override IMergerRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public static void WriteTree(ILoggerFactory loggerFactory, Action<IMergerRepositoryBuilder> configure)
  {
    MergerRepositoryBuilder repoBuilder = new();
    configure(repoBuilder);

    MergerRepoWrapper repo = new(new MergerRepository(repoBuilder, loggerFactory));
    repo.WriteFactories("Merger", repoBuilder.AllFactories);
  }

  public MergerList<T>.D AllMergersFor<T>([CallerMemberName] string callerName = "")
    where T : IAstType
    => AddRelationship<T>(callerName)
      .AllMergersFor<T>(callerName);
  public MergerOne<T>.D MergerFor<T>([CallerMemberName] string callerName = "")
    where T : IAstError
    => AddRelationship<T>(callerName)
      .MergerFor<T>(callerName);
}
