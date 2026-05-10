using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Matching;

internal sealed class MatcherRepoWrapper(
  IMatcherRepository repo
) : RepositoryWrapperBase<IMatcherRepository, MatcherRepoWrapper>(repo)
  , IMatcherRepository
{
  protected override IMatcherRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public DeferList<ITypeMatcher>.D TypeMatchers([CallerMemberName] string callerName = "")
    => AddRelationship<ITypeMatcher>(callerName)
      .TypeMatchers(callerName);

  public static void WriteTree(ILoggerFactory loggerFactory,
    Action<IMatcherRepositoryBuilder> configureMatchers)
  {
    MatcherRepositoryBuilder repoBuilder = new();
    configureMatchers(repoBuilder);

    MatcherRepoWrapper wrapper = new(new MatcherRepository(repoBuilder, loggerFactory));
    wrapper.WriteFactories("Matcher", repoBuilder.Matchers);
    // wrapper.FactoriesKeyValue<ITypeMatcher>());
  }

  public Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "")
    => AddRelationship<T>(callerName)
      .MatcherFor<T>(callerName);
}
