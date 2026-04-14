using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Encoding;

public class AllEncodersTests
{
  [Fact]
  public void AllEncoders_Repository_IsRegistered()
    => _services.GetService<IEncoderRepository>()
      .ShouldNotBeNull();

  [Fact]
  public void AllEncoders_EncoderForSimple_IsRegistered()
    => _services.GetRequiredService<IEncoderRepository>()
      .EncoderFor<SimpleModel>()
      .ShouldNotBeNull();

  [Fact]
  public void AllEncoders_TypeEncoders_ReturnNotEmpty()
    => _services.GetRequiredService<IEncoderRepository>()
      .EncodersFor<ITypeEncoder>()
      .ShouldNotBeEmpty();

  private readonly IServiceProvider _services = new ServiceCollection()
    .AddLogging()
    .AddEncoders()
    .BuildServiceProvider();
}
