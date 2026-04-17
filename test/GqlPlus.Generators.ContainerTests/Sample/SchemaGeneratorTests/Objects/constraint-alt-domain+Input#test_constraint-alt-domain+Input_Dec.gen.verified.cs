//HintName: test_constraint-alt-domain+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

internal class testCnstAltDmnInpDecoder
{

  internal static testCnstAltDmnInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltDmnInpDecoder<TRef>
{
}

internal class testDomCnstAltDmnInpDecoder
{

  internal static testDomCnstAltDmnInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_alt_domain_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_domain_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstAltDmnInpObject>(testCnstAltDmnInpDecoder.Factory)
      .AddDecoder<ItestDomCnstAltDmnInp>(testDomCnstAltDmnInpDecoder.Factory);
}
