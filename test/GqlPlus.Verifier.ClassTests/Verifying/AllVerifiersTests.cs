using GqlPlus.Abstractions.Operation;
using GqlPlus.Matching;
using GqlPlus.Merging;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifying;

public class AllVerifiersTests
{
  [Fact]
  public void AllVerifiers_Repository_IsRegistered()
    => _services.GetService<IVerifierRepository>()
      .ShouldNotBeNull();

  [Fact]
  public void AllVerifiers_VerifierForSchema_IsRegistered()
    => _services.GetRequiredService<IVerifierRepository>()
      .VerifierFor<IAstSchema>()
      .ShouldNotBeNull();

  [Fact]
  public void AllVerifiers_VerifierFactories_ReturnNotNull()
  {
    IVerifierRepository repo = _services.GetRequiredService<IVerifierRepository>();
    VerifierRepositoryBuilder builder = _services.GetRequiredService<VerifierRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Verifiers.Values.Select(CheckVerifier)]);
  }

  [Fact]
  public void AllVerifiers_AliasedFactories_ReturnNotNull()
  {
    IVerifierRepository repo = _services.GetRequiredService<IVerifierRepository>();
    VerifierRepositoryBuilder builder = _services.GetRequiredService<VerifierRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Aliased.Values.Select(CheckVerifier)]);
  }

  [Fact]
  public void AllVerifiers_UsagesFactories_ReturnNotNull()
  {
    IVerifierRepository repo = _services.GetRequiredService<IVerifierRepository>();
    VerifierRepositoryBuilder builder = _services.GetRequiredService<VerifierRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Usages.Values.Select(CheckVerifier)]);
  }

  [Fact]
  public void AllVerifiers_IdentifiedFactories_ReturnNotNull()
  {
    IVerifierRepository repo = _services.GetRequiredService<IVerifierRepository>();
    VerifierRepositoryBuilder builder = _services.GetRequiredService<VerifierRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Identified.Values.Select(CheckVerifier)]);
  }

  [Fact]
  public void AllVerifiers_DomainsFactories_ReturnNotNull()
  {
    IVerifierRepository repo = _services.GetRequiredService<IVerifierRepository>();
    VerifierRepositoryBuilder builder = _services.GetRequiredService<VerifierRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Domains.Select(CheckVerifier)]);
  }

  private static Action<IVerifierRepository> CheckVerifier(Factory<object, IVerifierRepository> factory)
    => r => factory(r)
        .ShouldNotBeNull($"Verifier for {factory.GetType().ExpandTypeName()} should not be null");

  private readonly IServiceProvider _services = new ServiceCollection()
      .AddLogging()
      .AddMergers(b => b.AddSchemaMergers())
      .AddMatchers(b => b.AddConstraintTypeMatchers())
      .AddVerifiers(b => b
        .AddSchemaVerifiers()
        .AddOperationVerifiers())
      .BuildServiceProvider();
}
