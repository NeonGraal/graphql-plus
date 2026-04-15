//HintName: test_domain-enum-value-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-value-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_value_parent;

internal class testDmnEnumValuePrntDecoder
{
}

internal class testEnumDmnEnumValuePrntDecoder
{
  public string prnt_dmnEnumValuePrnt { get; set; }
  public string dmnEnumValuePrnt { get; set; }
}

internal class testPrntDmnEnumValuePrntDecoder
{
  public string prnt_dmnEnumValuePrnt { get; set; }
}

internal static class test_domain_enum_value_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_value_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumValuePrnt>(_ => new testDmnEnumValuePrntDecoder())
      .AddDecoder<testEnumDmnEnumValuePrnt>(_ => new testEnumDmnEnumValuePrntDecoder())
      .AddDecoder<testPrntDmnEnumValuePrnt>(_ => new testPrntDmnEnumValuePrntDecoder());
}
