using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Matching;

internal sealed class MatcherRepoWrapper(
  IMatcherRepository repo
) : RepositoryWrapperBase<IMatcherRepository, MatcherRepoWrapper>(repo)
  , IMatcherRepository
{
  public override IMatcherRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public IEnumerable<ITypeMatcher> TypeMatchers => repo.TypeMatchers;

  public static void WriteTree(ILoggerFactory loggerFactory,
    Action<IMatcherRepositoryBuilder> configureMatchers)
  {
    MatcherRepositoryBuilder repoBuilder = new();
    configureMatchers(repoBuilder);

    MatcherRepoWrapper repo = new(new MatcherRepository(repoBuilder, loggerFactory));
    repo.WriteFactories("Matcher", repoBuilder.AllFactories);
  }

  public Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "")
    => AddRelationship<T>(callerName)
      .MatcherFor<T>(callerName);
}
