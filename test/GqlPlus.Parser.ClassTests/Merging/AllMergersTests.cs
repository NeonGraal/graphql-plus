using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.Logging.Abstractions;

namespace GqlPlus.Merging;

public class AllMergersTests
{
  private readonly MergerRepository _merger;

  public AllMergersTests()
  {
    MergerRepositoryBuilder builder = new();
    builder.AddSchemaMergers();
    _merger = new MergerRepository(builder.Build(), NullLoggerFactory.Instance);
  }

  [Fact]
  public void AllMergers_Repository_ProvidesConstant()
    => _merger
      .MergerFor<IGqlpConstant>()
      .ShouldNotBeNull();

  [Fact]
  public void AllMergers_Repository_ProvidesSchema()
    => _merger
      .MergerFor<IGqlpSchema>()
      .ShouldNotBeNull();

  [Fact]
  public void AllMergers_Repository_ProvidesType()
    => _merger
      .MergerFor<IGqlpType>()
      .ShouldNotBeNull();

  [Fact]
  public void AllMergers_Repository_ProvidesAllTypes()
    => _merger
      .AllMergersFor<IGqlpType>()
      .ShouldNotBeEmpty();

  [Fact]
  public void AllMergers_Repository_UnregisteredType_ThrowsInvalidOperation()
    => Should.Throw<InvalidOperationException>(
      () => _merger.MergerFor<UnregisteredError>());

  private sealed class UnregisteredError : IGqlpError
  {
    public IMessages MakeError(string message) => Messages.New;
  }
}
