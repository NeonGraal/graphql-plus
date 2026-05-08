using System.Runtime.CompilerServices;
using GqlPlus.Factories;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Matching;

internal sealed class MatcherRepoWrapper(
  IMatcherRepository repo
) : RepositoryWrapperBase<IMatcherRepository, MatcherRepoWrapper>(repo)
  , IMatcherRepository
{
  protected override IMatcherRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public IEnumerable<Factory<ITypeMatcher, IMatcherRepository>> TypeMatchers
    => repo.TypeMatchers;

  public static void WriteTree(ILoggerFactory loggerFactory,
    Action<IMatcherRepositoryBuilder> configureMatchers)
  {
    MatcherRepositoryBuilder repoBuilder = new();
    configureMatchers(repoBuilder);

    MatcherRepoWrapper wrapper = new(new MatcherRepository(repoBuilder, loggerFactory));
    wrapper.WriteFactories("Matcher", repoBuilder.Matchers,
      wrapper.FactoriesKeyValue(wrapper.TypeMatchers));
  }

  public Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "")
    => AddRelationship<T>(callerName)
      .MatcherFor<T>(callerName);
}
