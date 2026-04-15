//HintName: test_domain-enum-all-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-all-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all_parent;

internal class testDmnEnumAllPrntDecoder
{
}

internal class testEnumDmnEnumAllPrntDecoder
{
  public string prnt_dmnEnumAllPrnt { get; set; }
  public string dmnEnumAllPrntPrnt { get; set; }
  public string dmnEnumAllPrnt { get; set; }
  public string dmnEnumAllPrntValue { get; set; }
}

internal class testPrntDmnEnumAllPrntDecoder
{
  public string prnt_dmnEnumAllPrnt { get; set; }
  public string dmnEnumAllPrntPrnt { get; set; }
}

internal static class test_domain_enum_all_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_all_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumAllPrnt>(_ => new testDmnEnumAllPrntDecoder())
      .AddDecoder<testEnumDmnEnumAllPrnt>(_ => new testEnumDmnEnumAllPrntDecoder())
      .AddDecoder<testPrntDmnEnumAllPrnt>(_ => new testPrntDmnEnumAllPrntDecoder());
}
