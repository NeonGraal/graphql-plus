//HintName: test_field-simple+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Dual;

internal class testFieldSmplDualEncoder : IEncoder<ItestFieldSmplDualObject>
{
  public Structured Encode(ItestFieldSmplDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}
