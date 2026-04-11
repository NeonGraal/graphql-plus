using GqlPlus.Ast.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Merging;

public class AllMergersTests
{
  [Fact]
  public void AllMergers_Repository_IsRegistered()
    => _services.GetService<IMergerRepository>()
      .ShouldNotBeNull();

  [Fact]
  public void AllMergers_MergerForSchema_IsRegistered()
    => _services.GetRequiredService<IMergerRepository>()
      .MergerFor<IAstSchema>()
      .ShouldNotBeNull();

  [Fact]
  public void AllMergers_MergerFactories_ReturnNotNull()
  {
    IMergerRepository repo = _services.GetRequiredService<IMergerRepository>();
    MergerRepositoryBuilder builder = _services.GetRequiredService<MergerRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Mergers.Values.Select(CheckMerger)]);
  }

  [Fact]
  public void AllMergers_AllMergerFactories_ReturnNotNull()
  {
    IMergerRepository repo = _services.GetRequiredService<IMergerRepository>();
    MergerRepositoryBuilder builder = _services.GetRequiredService<MergerRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.AllMergers.Values.Select(CheckMerger)]);
  }

  private static Action<IMergerRepository> CheckMerger(Factory<object, IMergerRepository> factory)
    => r => factory(r)
        .ShouldNotBeNull($"Merger for {factory.GetType().ExpandTypeName()} should not be null");

  private readonly IServiceProvider _services = new ServiceCollection()
    .AddLogging()
    .AddMergers(b => b.AddSchemaMergers())
    .BuildServiceProvider();
}
