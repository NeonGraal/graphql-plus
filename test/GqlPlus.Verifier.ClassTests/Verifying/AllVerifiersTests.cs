using GqlPlus.Matching;
using GqlPlus.Merging;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Verifying;

public class AllVerifiersTests
{
  [Fact]
  public void AllVerifiers_Repository_IsRegistered()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddMergers(b => b.AddSchemaMergers())
      .AddMatchers(b => b.ConstraintMatchers())
      .AddVerifiers(b => b.AddSchemaVerifiers())
      .BuildServiceProvider();

    services.GetService<IVerifierRepository>()
      .ShouldNotBeNull();
  }

  [Fact]
  public void AllVerifiers_Repository_ProvidesVerifySchema()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddMergers(b => b.AddSchemaMergers())
      .AddMatchers(b => b.ConstraintMatchers())
      .AddVerifiers(b => b.AddSchemaVerifiers())
      .BuildServiceProvider();

    services.GetRequiredService<IVerifierRepository>()
      .VerifierFor<IGqlpSchema>()
      .ShouldNotBeNull();
  }
}
