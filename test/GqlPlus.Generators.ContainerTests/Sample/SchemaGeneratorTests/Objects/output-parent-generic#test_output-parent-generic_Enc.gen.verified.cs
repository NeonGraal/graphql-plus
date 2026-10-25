//HintName: test_output-parent-generic_Enc.gen.cs
// Generated from {CurrentDirectory}output-parent-generic.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

internal class testOutpPrntGnrcEncoder : IEncoder<ItestOutpPrntGnrcObject>
{
  public IGqlpValue Encode(ItestOutpPrntGnrcObject input)
    => new GqlpUnit();

  internal static testOutpPrntGnrcEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefOutpPrntGnrcEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefOutpPrntGnrcObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefOutpPrntGnrcObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumOutpPrntGnrcEncoder : IEncoder<testEnumOutpPrntGnrc>
{
  public IGqlpValue Encode(testEnumOutpPrntGnrc input)
    => input.EncodeEnum("EnumOutpPrntGnrc");

  internal static testEnumOutpPrntGnrcEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntOutpPrntGnrcEncoder : IEncoder<testPrntOutpPrntGnrc>
{
  public IGqlpValue Encode(testPrntOutpPrntGnrc input)
    => input.EncodeEnum("PrntOutpPrntGnrc");

  internal static testPrntOutpPrntGnrcEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_output_parent_genericEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_output_parent_genericEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestOutpPrntGnrcObject>(testOutpPrntGnrcEncoder.Factory)
      .AddEncoder<testEnumOutpPrntGnrc>(testEnumOutpPrntGnrcEncoder.Factory)
      .AddEncoder<testPrntOutpPrntGnrc>(testPrntOutpPrntGnrcEncoder.Factory);
}
