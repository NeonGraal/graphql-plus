//HintName: test_domain-enum-all-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-all-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all_descr;

internal class testDmnEnumAllDescrDecoder
{
}

internal class testEnumDmnEnumAllDescrDecoder
{
  public string dmnEnumAllDescr { get; set; }
  public string enum_dmnEnumAllDescr { get; set; }
  public string dmnEnumAllDescrValue { get; set; }
}

internal static class test_domain_enum_all_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_all_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumAllDescr>(_ => new testDmnEnumAllDescrDecoder())
      .AddDecoder<testEnumDmnEnumAllDescr>(_ => new testEnumDmnEnumAllDescrDecoder());
}
