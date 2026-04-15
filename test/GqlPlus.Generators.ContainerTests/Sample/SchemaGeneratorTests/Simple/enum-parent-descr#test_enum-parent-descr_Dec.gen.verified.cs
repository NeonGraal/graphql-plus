//HintName: test_enum-parent-descr_Dec.gen.cs
// Generated from {CurrentDirectory}enum-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_descr;

internal class testEnumPrntDescrDecoder
{
  public string prnt_enumPrntDescr { get; set; }
  public string enumPrntDescr { get; set; }
}

internal class testPrntEnumPrntDescrDecoder
{
  public string prnt_enumPrntDescr { get; set; }
}

internal static class test_enum_parent_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_parent_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumPrntDescr>(_ => new testEnumPrntDescrDecoder())
      .AddDecoder<testPrntEnumPrntDescr>(_ => new testPrntEnumPrntDescrDecoder());
}
