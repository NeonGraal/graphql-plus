//HintName: test_Enum_Dec.gen.cs
// Generated from {CurrentDirectory}Enum.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Enum;

internal class test_EnumLabelDecoder
{
  public Itest_Name EnumType { get; set; }

  internal static test_EnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_EnumDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_EnumDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_EnumLabelObject>(test_EnumLabelDecoder.Factory);
}
