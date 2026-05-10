using System.Runtime.CompilerServices;
using GqlPlus.Ast.Operation;
using GqlPlus.Matching;
using GqlPlus.Merging;
using GqlPlus.Verifying.Operation;
using GqlPlus.Verifying.Schema.Simple;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Verifying;

internal sealed class VerifierRepoWrapper(
  IVerifierRepository repo
) : RepositoryWrapperBase<IVerifierRepository, VerifierRepoWrapper>(repo)
  , IVerifierRepository
{
  protected override IVerifierRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public static void WriteTree(string label,
    ILoggerFactory loggerFactory,
    Action<IVerifierRepositoryBuilder> configureVerifiers,
    Action<IMatcherRepositoryBuilder>? configureMatchers = null,
    Action<IMergerRepositoryBuilder>? configureMergers = null)
  {
    VerifierRepositoryBuilder repoBuilder = new();
    configureVerifiers(repoBuilder);

    MatcherRepositoryBuilder matcherBuilder = new();
    configureMatchers?.Invoke(matcherBuilder);

    MergerRepositoryBuilder mergerBuilder = new();
    configureMergers?.Invoke(mergerBuilder);

    MatcherRepository matchers = new(matcherBuilder, loggerFactory);
    MergerRepository mergers = new(mergerBuilder, loggerFactory);
    VerifierRepoWrapper repo = new(new VerifierRepository(repoBuilder, loggerFactory, matchers, mergers));
    repo.WriteFactories(label + "Verifier", repoBuilder.AllFactories);
  }

  public DeferOne<IVerifyAliased<T>>.D AliasedFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased
    => AddRelationship<T>(callerName)
      .AliasedFor<T>(callerName);
  public DeferList<IVerifyDomain>.D GetDomains([CallerMemberName] string callerName = "")
    => AddRelationship<IVerifyDomain>(callerName)
      .GetDomains(callerName);
  public DeferOne<IVerifyIdentified<TUsage, TIdentified>>.D IdentifiedFor<TUsage, TIdentified>([CallerMemberName] string callerName = "")
    where TUsage : IAstError
    where TIdentified : IAstIdentified
  {
    AddRelationship<TUsage>(callerName);
    return AddRelationship<TIdentified>(callerName)
        .IdentifiedFor<TUsage, TIdentified>(callerName);
  }

  public Matcher<T>.D MatcherFor<T>([CallerMemberName] string callerName = "")
    => AddRelationship<T>(callerName)
      .MatcherFor<T>(callerName);
  public DeferOne<IMerge<T>>.D MergerFor<T>([CallerMemberName] string callerName = "")
    where T : IAstError
    => AddRelationship<T>(callerName)
      .MergerFor<T>(callerName);
  public DeferOne<IVerifyUsage<T>>.D UsageFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased
    => AddRelationship<T>(callerName)
      .UsageFor<T>(callerName);
  public DeferOne<IVerify<T>>.D VerifierFor<T>([CallerMemberName] string callerName = "")
    => AddRelationship<T>(callerName)
      .VerifierFor<T>(callerName);
}
