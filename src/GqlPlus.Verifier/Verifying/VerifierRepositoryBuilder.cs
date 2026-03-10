using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Operation;
using GqlPlus.Verifying.Schema;
using GqlPlus.Verifying.Schema.Simple;

namespace GqlPlus.Verifying;

internal class VerifierRepositoryBuilder
  : BaseFactory<IVerifierRepository>, IVerifierRepositoryBuilder
{
  internal readonly FactoryDict Verifiers = [];
  internal readonly FactoryDict Aliased = [];
  internal readonly FactoryDict Usages = [];
  internal readonly FactoryDict Identified = [];
  internal readonly List<Factory<object, IVerifierRepository>> Domains = [];

  public IVerifierRepositoryBuilder AddVerify<T>(Factory<IVerify<T>, IVerifierRepository> factory)
    => this.FluentAction(b => b.Verifiers[typeof(T)] = factory);

  public IVerifierRepositoryBuilder TryAddVerify<T>(Factory<IVerify<T>, IVerifierRepository> factory)
    => this.FluentAction(b => {
      if (!b.Verifiers.ContainsKey(typeof(T))) {
        b.Verifiers[typeof(T)] = factory;
      }
    });

  public IVerifierRepositoryBuilder AddAliased<T>(Factory<IVerifyAliased<T>, IVerifierRepository> factory)
    where T : IGqlpAliased
    => this.FluentAction(b => b.Aliased[typeof(T)] = factory);

  public IVerifierRepositoryBuilder AddUsage<T>(Factory<IVerifyUsage<T>, IVerifierRepository> factory)
    where T : IGqlpAliased
    => this.FluentAction(b => b.Usages[typeof(T)] = factory);

  public IVerifierRepositoryBuilder AddIdentified<TUsage, TIdentified>(Factory<IVerifyIdentified<TUsage, TIdentified>, IVerifierRepository> factory)
    where TUsage : IGqlpError
    where TIdentified : IGqlpIdentified
    => this.FluentAction(b => b.Identified[typeof((TUsage, TIdentified))] = factory);

  public IVerifierRepositoryBuilder AddDomain(Factory<IVerifyDomain, IVerifierRepository> factory)
    => this.FluentAction(b => b.Domains.Add(factory));

  internal VerifierRepositoryState Build()
    => new(Verifiers, Aliased, Usages, Identified, Domains);
}

internal sealed class VerifierRepositoryState
  : BaseFactory<IVerifierRepository>
{
  internal FactoryDict Verifiers { get; }
  internal FactoryDict Aliased { get; }
  internal FactoryDict Usages { get; }
  internal FactoryDict Identified { get; }
  internal List<Factory<object, IVerifierRepository>> Domains { get; }

  public VerifierRepositoryState(
    FactoryDict verifiers,
    FactoryDict aliased,
    FactoryDict usages,
    FactoryDict identified,
    List<Factory<object, IVerifierRepository>> domains)
  {
    Verifiers = verifiers;
    Aliased = aliased;
    Usages = usages;
    Identified = identified;
    Domains = domains;
  }
}
