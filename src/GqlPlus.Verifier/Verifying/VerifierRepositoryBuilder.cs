using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Matching;
using GqlPlus.Merging;
using GqlPlus.Verifying.Operation;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Verifying;

internal class VerifierRepositoryBuilder
  : IVerifierRepositoryBuilder
{
  internal readonly VerifierFactoryDict Verifiers = [];
  internal readonly VerifierFactoryDict Aliased = [];
  internal readonly VerifierFactoryDict Usages = [];
  internal readonly IdentifiedFactoryDict Identified = [];
  internal readonly List<VerifierFactory<object>> Domains = [];

  public IVerifierRepositoryBuilder AddVerify<T>(VerifierFactory<IVerify<T>> factory)
    => this.FluentAction(b => b.Verifiers[typeof(T)] = factory);

  public IVerifierRepositoryBuilder TryAddVerify<T>(VerifierFactory<IVerify<T>> factory)
    => this.FluentAction(b => {
      if (!b.Verifiers.ContainsKey(typeof(T))) {
        b.Verifiers[typeof(T)] = factory;
      }
    });

  public IVerifierRepositoryBuilder AddAliased<T>(VerifierFactory<IVerifyAliased<T>> factory)
    where T : IGqlpAliased
    => this.FluentAction(b => b.Aliased[typeof(T)] = factory);

  public IVerifierRepositoryBuilder AddUsage<T>(VerifierFactory<IVerifyUsage<T>> factory)
    where T : IGqlpAliased
    => this.FluentAction(b => b.Usages[typeof(T)] = factory);

  public IVerifierRepositoryBuilder AddIdentified<TUsage, TIdentified>(VerifierFactory<IVerifyIdentified<TUsage, TIdentified>> factory)
    where TUsage : IGqlpError
    where TIdentified : IGqlpIdentified
    => this.FluentAction(b => b.Identified[(typeof(TUsage), typeof(TIdentified))] = factory);

  public IVerifierRepositoryBuilder AddDomain(VerifierFactory<IVerifyDomain> factory)
    => this.FluentAction(b => b.Domains.Add(factory));

  internal VerifierRepositoryState Build(
      ILoggerFactory loggerFactory,
      IMatcherRepository matchers,
      Func<Type, object> mergerFor,
      Func<Type, object> fieldKindFor)
    => new(Verifiers, Aliased, Usages, Identified, Domains, loggerFactory, matchers, mergerFor, fieldKindFor);
}

internal sealed class VerifierRepositoryState(
  VerifierFactoryDict verifiers,
  VerifierFactoryDict aliased,
  VerifierFactoryDict usages,
  IdentifiedFactoryDict identified,
  List<VerifierFactory<object>> domains,
  ILoggerFactory loggerFactory,
  IMatcherRepository matchers,
  Func<Type, object> mergerFor,
  Func<Type, object> fieldKindFor)
{
  internal VerifierFactoryDict Verifiers { get; } = verifiers;
  internal VerifierFactoryDict Aliased { get; } = aliased;
  internal VerifierFactoryDict Usages { get; } = usages;
  internal IdentifiedFactoryDict Identified { get; } = identified;
  internal List<VerifierFactory<object>> Domains { get; } = domains;
  internal ILoggerFactory LoggerFactory { get; } = loggerFactory;
  internal IMatcherRepository Matchers { get; } = matchers;
  internal Func<Type, object> MergerFor { get; } = mergerFor;
  internal Func<Type, object> FieldKindFor { get; } = fieldKindFor;
}

internal class VerifierFactoryDict : Dictionary<Type, VerifierFactory<object>>;

internal class IdentifiedFactoryDict : Dictionary<(Type, Type), VerifierFactory<object>>;
