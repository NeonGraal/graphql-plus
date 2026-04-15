//HintName: test_domain-bool-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-bool-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_bool_parent;

internal class testDmnBoolPrntDecoder
{
}

internal class testPrntDmnBoolPrntDecoder
{
}

internal static class test_domain_bool_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_bool_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnBoolPrnt>(_ => new testDmnBoolPrntDecoder())
      .AddDecoder<ItestPrntDmnBoolPrnt>(_ => new testPrntDmnBoolPrntDecoder());
}
