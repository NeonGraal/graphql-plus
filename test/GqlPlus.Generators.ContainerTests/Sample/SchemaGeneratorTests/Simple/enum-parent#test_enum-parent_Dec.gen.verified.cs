//HintName: test_enum-parent_Dec.gen.cs
// Generated from {CurrentDirectory}enum-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent;

internal class testEnumPrntDecoder
{
  public string prnt_enumPrnt { get; set; }
  public string enumPrnt { get; set; }
}

internal class testPrntEnumPrntDecoder
{
  public string prnt_enumPrnt { get; set; }
}

internal static class test_enum_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumPrnt>(_ => new testEnumPrntDecoder())
      .AddDecoder<testPrntEnumPrnt>(_ => new testPrntEnumPrntDecoder());
}
