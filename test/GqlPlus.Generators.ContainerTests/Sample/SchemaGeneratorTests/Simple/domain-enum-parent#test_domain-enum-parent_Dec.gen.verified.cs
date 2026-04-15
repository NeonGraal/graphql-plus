//HintName: test_domain-enum-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent;

internal class testDmnEnumPrntDecoder
{
}

internal class testPrntDmnEnumPrntDecoder
{
}

internal class testEnumDmnEnumPrntDecoder
{
  public string enum_dmnEnumPrnt { get; set; }
  public string prnt_dmnEnumPrnt { get; set; }
}

internal static class test_domain_enum_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumPrnt>(_ => new testDmnEnumPrntDecoder())
      .AddDecoder<ItestPrntDmnEnumPrnt>(_ => new testPrntDmnEnumPrntDecoder())
      .AddDecoder<testEnumDmnEnumPrnt>(_ => new testEnumDmnEnumPrntDecoder());
}
