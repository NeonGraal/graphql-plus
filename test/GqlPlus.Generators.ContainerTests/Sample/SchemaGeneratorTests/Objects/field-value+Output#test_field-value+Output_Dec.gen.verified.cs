//HintName: test_field-value+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Output;

internal class testEnumFieldValueOutpDecoder
{
  public string fieldValueOutp { get; set; }

  internal static testEnumFieldValueOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_value_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumFieldValueOutp>(testEnumFieldValueOutpDecoder.Factory);
}
