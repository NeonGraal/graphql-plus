using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Decoding;

public class AllDecodersTests
{
  [Fact]
  public void AllDecoders_Repository_IsRegistered()
    => _services.GetService<IDecoderRepository>()
      .ShouldNotBeNull();

  [Fact]
  public void AllDecoders_DecoderForCategoryFilterModel_IsRegistered()
    => _services.GetRequiredService<IDecoderRepository>()
      .DecoderFor<CategoryFilterModel>()
      .ShouldNotBeNull();

  private readonly IServiceProvider _services = new ServiceCollection()
    .AddLogging()
    .AddDecoders()
    .BuildServiceProvider();
}
