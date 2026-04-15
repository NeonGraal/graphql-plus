//HintName: test_generic-value+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

internal class testGnrcValueOutpEncoder : IEncoder<ItestGnrcValueOutpObject>
{
  public Structured Encode(ItestGnrcValueOutpObject input)
    => Structured.Empty();

  internal static testGnrcValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcValueOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcValueOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefGnrcValueOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcValueOutpEncoder : IEncoder<testEnumGnrcValueOutp>
{
  public Structured Encode(testEnumGnrcValueOutp input)
    => new(input.ToString(), "_EnumGnrcValueOutp");

  internal static testEnumGnrcValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_value_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_value_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcValueOutpObject>(testGnrcValueOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcValueOutp>(testEnumGnrcValueOutpEncoder.Factory);
}
