//HintName: test_field-value-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Output;

internal class testFieldValueDescrOutpEncoder : IEncoder<ItestFieldValueDescrOutpObject>
{
  public Structured Encode(ItestFieldValueDescrOutpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldValueDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueDescrOutpEncoder : IEncoder<testEnumFieldValueDescrOutp>
{
  public Structured Encode(testEnumFieldValueDescrOutp input)
    => input.EncodeEnum("EnumFieldValueDescrOutp");

  internal static testEnumFieldValueDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_value_descr_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_value_descr_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldValueDescrOutpObject>(testFieldValueDescrOutpEncoder.Factory)
      .AddEncoder<testEnumFieldValueDescrOutp>(testEnumFieldValueDescrOutpEncoder.Factory);
}
