//HintName: test_field-value-descr+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Input;

internal class testEnumFieldValueDescrInpEncoder : IEncoder<testEnumFieldValueDescrInp>
{
  public Structured Encode(testEnumFieldValueDescrInp input)
    => new(input.ToString(), "_EnumFieldValueDescrInp");
}

internal static class test_field_value_descr_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_value_descr_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumFieldValueDescrInp>(_ => new testEnumFieldValueDescrInpEncoder());
}
