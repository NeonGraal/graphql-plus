using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Merging;

public class AllMergersTests
{
  private readonly IServiceProvider _services;

  public AllMergersTests()
    => _services = new ServiceCollection()
      .AddLogging()
      .AddMergers()
      .BuildServiceProvider();

  [Fact]
  public void AllMergers_Repository_IsRegistered()
    => _services
      .GetService<IMergerRepository>()
      .ShouldNotBeNull();

  [Fact]
  public void AllMergers_Repository_ProvidesConstant()
    => _services
      .GetRequiredService<IMergerRepository>()
      .MergerFor<IGqlpConstant>()
      .ShouldNotBeNull();

  [Fact]
  public void AllMergers_Repository_ProvidesSchema()
    => _services
      .GetRequiredService<IMergerRepository>()
      .MergerFor<IGqlpSchema>()
      .ShouldNotBeNull();

  [Fact]
  public void AllMergers_Repository_ProvidesType()
    => _services
      .GetRequiredService<IMergerRepository>()
      .MergerFor<IGqlpType>()
      .ShouldNotBeNull();

  [Fact]
  public void AllMergers_Repository_ProvidesAllTypes()
    => _services
      .GetRequiredService<IMergerRepository>()
      .AllMergersFor<IGqlpType>()
      .ShouldNotBeEmpty();

  [Fact]
  public void AllMergers_Repository_UnregisteredType_ThrowsInvalidOperation()
    => Should.Throw<InvalidOperationException>(
      () => _services.GetRequiredService<IMergerRepository>().MergerFor<UnregisteredError>());

  private sealed class UnregisteredError : IGqlpError
  {
    public IMessages MakeError(string message) => Messages.New;
  }

  [Fact]
  public void AllMergers_Service_IsRegistered()
    => _services
      .GetService<IMerge<IGqlpSchema>>()
      .ShouldNotBeNull();
}
