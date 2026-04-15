//HintName: test_domain-enum-unique-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-unique-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_unique_parent;

internal class testDmnEnumUnqPrntDecoder
{
}

internal class testEnumDmnEnumUnqPrntDecoder
{
  public string dmnEnumUnqPrnt { get; set; }
  public string prnt_dmnEnumUnqPrnt { get; set; }
  public string dmnEnumUnqPrntPrnt { get; set; }
  public string enum_dmnEnumUnqPrnt { get; set; }
  public string dmnEnumUnqPrntValue { get; set; }
}

internal class testPrntDmnEnumUnqPrntDecoder
{
  public string dmnEnumUnqPrnt { get; set; }
  public string prnt_dmnEnumUnqPrnt { get; set; }
  public string dmnEnumUnqPrntPrnt { get; set; }
}

internal class testDupDmnEnumUnqPrntDecoder
{
  public string dmnEnumUnqPrnt { get; set; }
  public string dup_dmnEnumUnqPrnt { get; set; }
  public string dmnEnumUnqPrntDup { get; set; }
}

internal static class test_domain_enum_unique_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_unique_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumUnqPrnt>(_ => new testDmnEnumUnqPrntDecoder())
      .AddDecoder<testEnumDmnEnumUnqPrnt>(_ => new testEnumDmnEnumUnqPrntDecoder())
      .AddDecoder<testPrntDmnEnumUnqPrnt>(_ => new testPrntDmnEnumUnqPrntDecoder())
      .AddDecoder<testDupDmnEnumUnqPrnt>(_ => new testDupDmnEnumUnqPrntDecoder());
}
