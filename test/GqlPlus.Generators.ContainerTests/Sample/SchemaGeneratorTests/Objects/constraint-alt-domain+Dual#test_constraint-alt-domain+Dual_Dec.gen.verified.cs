//HintName: test_constraint-alt-domain+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

internal class testCnstAltDmnDualDecoder
{
}

internal class testRefCnstAltDmnDualDecoder<TRef>
{
}

internal class testDomCnstAltDmnDualDecoder
{
}

internal static class test_constraint_alt_domain_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_domain_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstAltDmnDualObject>(_ => new testCnstAltDmnDualDecoder())
      .AddDecoder<ItestDomCnstAltDmnDual>(_ => new testDomCnstAltDmnDualDecoder());
}
