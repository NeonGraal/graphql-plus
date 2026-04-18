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

  [Fact]
  public void AllEncoders_EncoderFactories_ReturnNotNull()
  {
    IEncoderRepository repo = _services.GetRequiredService<IEncoderRepository>();
    EncoderRepositoryBuilder builder = _services.GetRequiredService<EncoderRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Encoders.Values.Select(CheckEncoder)]);
  }

  [Fact]
  public void AllEncoders_EncodersForFactories_ReturnNotNull()
  {
    IEncoderRepository repo = _services.GetRequiredService<IEncoderRepository>();

    repo.ShouldSatisfyAllConditions([.. repo.EncodersFor<ITypeEncoder>().Select(CheckTypeEncoder)]);
  }

  private static Action<IEncoderRepository> CheckEncoder(Factory<object, IEncoderRepository> factory)
    => r => factory(r)
        .ShouldNotBeNull($"Encoder for {factory.GetType().ExpandTypeName()} should not be null");

  private static Action<IEncoderRepository> CheckTypeEncoder(ITypeEncoder encoder)
    => r => encoder
        .ShouldNotBeNull($"Type encoder for {encoder.GetType().ExpandTypeName()} should not be null");

  private readonly IServiceProvider _services = new ServiceCollection()
    .AddLogging()
    .AddEncoders()
    .BuildServiceProvider();
}
