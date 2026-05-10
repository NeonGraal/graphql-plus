using GqlPlus.Factories;
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
  {
    Defer<IEncoder<SimpleModel>>.L encoder = _services.GetRequiredService<IEncoderRepository>()
      .EncoderFor<SimpleModel>();

    encoder.I.ShouldNotBeNull();
  }

  [Fact]
  public void AllEncoders_TypeEncoders_ReturnNotEmpty()
  {
    Defer<ITypeEncoder>.LA encoders = _services.GetRequiredService<IEncoderRepository>()
      .EncodersFor<ITypeEncoder>();

    encoders.IA.ShouldNotBeEmpty();
  }

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
    Defer<ITypeEncoder>.LA encoders = repo.EncodersFor<ITypeEncoder>();

    repo.ShouldSatisfyAllConditions([.. encoders.IA.Select(CheckTypeEncoder)]);
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
