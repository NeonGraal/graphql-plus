//HintName: test_generic-value+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

internal class testGnrcValueDualEncoder : IEncoder<ItestGnrcValueDualObject>
{
  public Structured Encode(ItestGnrcValueDualObject input)
    => Structured.Empty();
}

internal class testRefGnrcValueDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcValueDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefGnrcValueDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcValueDualEncoder : IEncoder<testEnumGnrcValueDual>
{
  public Structured Encode(testEnumGnrcValueDual input)
    => new(input.ToString(), "_EnumGnrcValueDual");
}
