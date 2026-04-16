//HintName: test_generic-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

internal class testGnrcEnumOutpEncoder : IEncoder<ItestGnrcEnumOutpObject>
{
  public Structured Encode(ItestGnrcEnumOutpObject input)
    => Structured.Empty();

  internal static testGnrcEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcEnumOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcEnumOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefGnrcEnumOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcEnumOutpEncoder : IEncoder<testEnumGnrcEnumOutp>
{
  public Structured Encode(testEnumGnrcEnumOutp input)
    => new(input.ToString(), "_EnumGnrcEnumOutp");

  internal static testEnumGnrcEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_enum_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_enum_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcEnumOutpObject>(testGnrcEnumOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcEnumOutp>(testEnumGnrcEnumOutpEncoder.Factory);
}
