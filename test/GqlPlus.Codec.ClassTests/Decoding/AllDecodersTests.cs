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

  [Fact]
  public void AllDecoders_DecoderFactories_ReturnNotNull()
  {
    IDecoderRepository repo = _services.GetRequiredService<IDecoderRepository>();
    DecoderRepositoryBuilder builder = _services.GetRequiredService<DecoderRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Decoders.Values.Select(CheckDecoder)]);
  }

  private static Action<IDecoderRepository> CheckDecoder(Factory<object, IDecoderRepository> factory)
    => r => factory(r)
        .ShouldNotBeNull($"Decoder for {factory.GetType().ExpandTypeName()} should not be null");

  private readonly IServiceProvider _services = new ServiceCollection()
    .AddLogging()
    .AddDecoders()
    .BuildServiceProvider();
}
