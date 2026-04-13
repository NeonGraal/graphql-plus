//HintName: test_field-value+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Output;

internal class testFieldValueOutpEncoder : IEncoder<ItestFieldValueOutpObject>
{
  public Structured Encode(ItestFieldValueOutpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldValueOutpEncoder : IEncoder<testEnumFieldValueOutp>
{
  public Structured Encode(testEnumFieldValueOutp input)
    => new(input.ToString(), "_EnumFieldValueOutp");
}
