using System.Runtime.CompilerServices;
using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Ast.Schema;
using GqlPlus.Matching;
using GqlPlus.Merging;
using GqlPlus.Verifying;
using GqlPlus.Verifying.Operation;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;
using Microsoft.Extensions.Logging;

namespace GqlPlus;

public class VerifierRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact]
  public void SchemaVerifiers()
    => VerifierRepoWrapper.WriteTree("SchemaVerifier", outputHelper.ToLoggerFactory(),
      v => v.AddSchemaVerifiers(),
      m => m.AddConstraintMatchers(),
      m => m.AddSchemaMergers());
}

internal sealed class VerifierRepoWrapper(
  IVerifierRepository repo
) : RepoWrapperBase<IVerifierRepository, VerifierRepoWrapper>(repo)
  , IVerifierRepository
{
  public override IVerifierRepository Wrapper => this;

  public ILoggerFactory LoggerFactory => repo.LoggerFactory;

  public static void WriteTree(string label, ILoggerFactory loggerFactory,
    Action<IVerifierRepositoryBuilder> configureVerifiers,
    Action<IMatcherRepositoryBuilder> configureMatchers,
    Action<IMergerRepositoryBuilder> configureMergers)
  {
    VerifierRepositoryBuilder repoBuilder = new();
    configureVerifiers(repoBuilder);

    MatcherRepositoryBuilder matcherBuilder = new();
    configureMatchers(matcherBuilder);

    MergerRepositoryBuilder mergerBuilder = new();
    configureMergers(mergerBuilder);

    MatcherRepository matchers = new(matcherBuilder, loggerFactory);
    MergerRepository mergers = new(mergerBuilder, loggerFactory);
    VerifierRepoWrapper repo = new(new VerifierRepository(repoBuilder, loggerFactory, matchers, mergers));
    repo.WriteFactories(label, repoBuilder.AllFactories);
  }

  public IVerifyAliased<T> AliasedFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased
    => AddRelationship<T>(callerName)
      .AliasedFor<T>(callerName);
  public IEnumerable<IVerifyDomain> GetDomains([CallerMemberName] string callerName = "")
    => AddRelationship<IVerifyDomain>(callerName)
      .GetDomains(callerName);
  public IVerifyIdentified<TUsage, TIdentified> IdentifiedFor<TUsage, TIdentified>([CallerMemberName] string callerName = "")
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
  public IMerge<T> MergerFor<T>([CallerMemberName] string callerName = "")
    where T : IAstError
    => AddRelationship<T>(callerName)
      .MergerFor<T>(callerName);
  public IVerifyUsage<T> UsageFor<T>([CallerMemberName] string callerName = "")
    where T : IAstAliased
    => AddRelationship<T>(callerName)
      .UsageFor<T>(callerName);
  public IVerify<T> VerifierFor<T>([CallerMemberName] string callerName = "")
    => AddRelationship<T>(callerName)
      .VerifierFor<T>(callerName);
}
