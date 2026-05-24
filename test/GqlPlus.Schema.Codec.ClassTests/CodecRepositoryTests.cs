using GqlPlus.Decoding;
using GqlPlus.Encoding;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class CodecRepositoryTests(
  ITestOutputHelper outputHelper
) : SubstituteBase
{
  [Fact, Trait("Generate", "Html")]
  public void Decoders()
    => DecoderRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(),
      v => v.AddSchemaDecoders());

  [Fact, Trait("Generate", "Html")]
  public void Encoders()
    => EncoderRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(),
      v => v.AddSchemaEncoders());

  [Fact]
  public void DecoderRepository()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddDecoders(b => b.AddSchemaDecoders())
      .BuildServiceProvider();

    services.GetService<IDecoderRepository>()
        .ShouldNotBeNull();
  }

  [Fact]
  public void EncoderRepository()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddEncoders(b => b.AddSchemaEncoders())
      .BuildServiceProvider();

    services.GetService<IEncoderRepository>()
        .ShouldNotBeNull();
  }

  [Fact]
  public void DecodeTypeFilter()
  {
    // Arrange
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddDecoders(b => b.AddSchemaDecoders())
      .BuildServiceProvider();

    Decoder<TypeFilterModel> factory = services
      .GetService<IDecoderRepository>()
      .ShouldNotBeNull()
      .DecoderFor<TypeFilterModel>();

    IValue input = "Test".Encode();

    // Act
    IMessages result = factory.Decode(input, out TypeFilterModel? output);

    // Assert
    result.ShouldNotBeNull();
    output.ShouldNotBeNull();
  }

  [Fact]
  public void EncodeSchema()
  {
    // Arrange
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddEncoders(b => b.AddSchemaEncoders())
      .BuildServiceProvider();

    Encoder<SchemaModel> factory = services
      .GetService<IEncoderRepository>()
      .ShouldNotBeNull()
      .EncoderFor<SchemaModel>();

    SchemaModel input = new("Test", "");

    // Act
    Structured result = factory.Encode(input);

    // Assert
    result.ShouldNotBeNull();
  }
}
