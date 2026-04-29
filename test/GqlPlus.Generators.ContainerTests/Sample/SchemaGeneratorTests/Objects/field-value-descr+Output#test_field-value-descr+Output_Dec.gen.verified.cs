//HintName: test_field-value-descr+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Output;

internal class testEnumFieldValueDescrOutpDecoder : IDecoder<testEnumFieldValueDescrOutp?>
{
  public IMessages Decoder(IValue input, out testEnumFieldValueDescrOutp? output)
    => input.DecodeEnum("EnumFieldValueDescrOutp", out output);

  internal static testEnumFieldValueDescrOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_value_descr_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_descr_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumFieldValueDescrOutp?>(testEnumFieldValueDescrOutpDecoder.Factory);
}
