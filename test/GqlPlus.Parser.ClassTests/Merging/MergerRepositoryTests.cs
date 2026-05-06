using GqlPlus.Ast.Schema;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Merging;

public class MergerRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact]
  public void SchemaMergers()
    => MergerRepoWrapper.WriteTree("SchemaMerger", outputHelper.ToLoggerFactory(), b => b.AddSchemaMergers());
}

internal sealed class MergerRepoWrapper(
  IMergerRepository repo
) : RepositoryWrapperBase<IMergerRepository, MergerRepoWrapper>(repo)
  , IMergerRepository
{
  public override IMergerRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public static void WriteTree(string label, ILoggerFactory loggerFactory, Action<IMergerRepositoryBuilder> configure)
  {
    MergerRepositoryBuilder repoBuilder = new();
    configure(repoBuilder);

    MergerRepoWrapper repo = new(new MergerRepository(repoBuilder, loggerFactory));
    repo.WriteFactories(label, repoBuilder.AllFactories);
  }

  public IEnumerable<IMergeAll<T>> AllMergersFor<T>([CallerMemberName] string callerName = "")
    where T : IAstType
    => AddRelationship<T>(callerName)
      .AllMergersFor<T>(callerName);
  public IMerge<T> MergerFor<T>(string callerName)
    where T : IAstError
    => AddRelationship<T>(callerName)
      .MergerFor<T>(callerName);
}
