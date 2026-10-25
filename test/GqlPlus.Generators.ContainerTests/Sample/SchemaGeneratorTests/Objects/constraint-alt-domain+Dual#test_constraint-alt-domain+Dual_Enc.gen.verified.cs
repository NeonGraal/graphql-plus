//HintName: test_constraint-alt-domain+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

internal class testCnstAltDmnDualEncoder : IEncoder<ItestCnstAltDmnDualObject>
{
  public IGqlpValue Encode(ItestCnstAltDmnDualObject input)
    => new GqlpUnit();

  internal static testCnstAltDmnDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDmnDualEncoder<TRef> : IEncoder<ItestRefCnstAltDmnDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstAltDmnDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testDomCnstAltDmnDualEncoder : IEncoder<ItestDomCnstAltDmnDual>
{
  public IGqlpValue Encode(ItestDomCnstAltDmnDual input)
    => input.Value!.Encode();

  internal static testDomCnstAltDmnDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_alt_domain_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_alt_domain_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstAltDmnDualObject>(testCnstAltDmnDualEncoder.Factory)
      .AddEncoder<ItestDomCnstAltDmnDual>(testDomCnstAltDmnDualEncoder.Factory);
}
