//HintName: test_constraint-alt-domain+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

internal class testCnstAltDmnInpDecoder
{
}

internal class testRefCnstAltDmnInpDecoder<TRef>
{
}

internal class testDomCnstAltDmnInpDecoder
{
}

internal static class test_constraint_alt_domain_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_domain_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstAltDmnInpObject>(_ => new testCnstAltDmnInpDecoder())
      .AddDecoder<ItestDomCnstAltDmnInp>(_ => new testDomCnstAltDmnInpDecoder());
}
