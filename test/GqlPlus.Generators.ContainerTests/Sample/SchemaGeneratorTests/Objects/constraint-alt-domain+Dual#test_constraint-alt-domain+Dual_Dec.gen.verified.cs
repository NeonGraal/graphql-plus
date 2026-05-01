//HintName: test_constraint-alt-domain+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

internal class testCnstAltDmnDualDecoder : IDecoder<ItestCnstAltDmnDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstAltDmnDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstAltDmnDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltDmnDualDecoder<TRef>
{
}

internal class testDomCnstAltDmnDualDecoder : IDecoder<ItestDomCnstAltDmnDual>
{

  public IMessages Decode(IValue input, out ItestDomCnstAltDmnDual? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomCnstAltDmnDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_alt_domain_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_domain_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstAltDmnDualObject>(testCnstAltDmnDualDecoder.Factory)
      .AddDecoder<ItestDomCnstAltDmnDual>(testDomCnstAltDmnDualDecoder.Factory);
}
