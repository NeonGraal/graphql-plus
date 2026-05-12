using GqlPlus.Matching;
using GqlPlus.Merging;
using GqlPlus.Verifying;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class VerifierRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact, Trait("Generate", "Html")]
  public void Matchers()
    => MatcherRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(),
      v => v.AddSchemaMatchers());

  [Fact, Trait("Generate", "Html")]
  public void OperationVerifiers()
    => VerifierRepoWrapper.WriteTree("Operation", outputHelper.ToLoggerFactory(),
      v => v.AddOperationVerifiers());

  [Fact, Trait("Generate", "Html")]
  public void SchemaVerifiers()
    => VerifierRepoWrapper.WriteTree("Schema", outputHelper.ToLoggerFactory(),
      v => v.AddSchemaVerifiers(),
      m => m.AddSchemaMatchers(),
      m => m.AddSchemaMergers());

  [Fact]
  public void MatcherRepository()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddMatchers(b => { })
      .BuildServiceProvider();

    services.GetService<IMatcherRepository>()
        .ShouldNotBeNull();
  }

  [Fact]
  public void EnumMatcherCreated()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddMatchers(b => b.AddSchemaMatchers())
      .BuildServiceProvider();

    IMatcherRepository repository = services.GetService<IMatcherRepository>().ShouldNotBeNull();
    Matcher<IAstEnum>.D enumFactory = repository.MatcherFor<IAstEnum>().ShouldNotBeNull();
    enumFactory.Invoke().ShouldNotBeNull();
  }

  [Fact]
  public void VerifierRepository()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddVerifiers(b => { })
      .AddMatchers(b => { })
      .AddMergers(b => { })
      .BuildServiceProvider();

    services.GetService<IVerifierRepository>()
        .ShouldNotBeNull();
  }
}
