//HintName: test_field-value-descr+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Input;

internal class testFieldValueDescrInpEncoder : IEncoder<ItestFieldValueDescrInpObject>
{
  public Structured Encode(ItestFieldValueDescrInpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldValueDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueDescrInpEncoder : IEncoder<testEnumFieldValueDescrInp>
{
  public Structured Encode(testEnumFieldValueDescrInp input)
    => input.EncodeEnum("EnumFieldValueDescrInp");

  internal static testEnumFieldValueDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_value_descr_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_value_descr_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldValueDescrInpObject>(testFieldValueDescrInpEncoder.Factory)
      .AddEncoder<testEnumFieldValueDescrInp>(testEnumFieldValueDescrInpEncoder.Factory);
}
