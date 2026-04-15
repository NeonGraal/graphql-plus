//HintName: test_enum-parent-dup_Dec.gen.cs
// Generated from {CurrentDirectory}enum-parent-dup.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_dup;

internal class testEnumPrntDupDecoder
{
  public string prnt_enumPrntDup { get; set; }
  public string enumPrntDup { get; set; }
  public string enumPrntDup { get; set; }
}

internal class testPrntEnumPrntDupDecoder
{
  public string prnt_enumPrntDup { get; set; }
  public string enumPrntDup { get; set; }
}

internal static class test_enum_parent_dupDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_parent_dupDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumPrntDup>(_ => new testEnumPrntDupDecoder())
      .AddDecoder<testPrntEnumPrntDup>(_ => new testPrntEnumPrntDupDecoder());
}
