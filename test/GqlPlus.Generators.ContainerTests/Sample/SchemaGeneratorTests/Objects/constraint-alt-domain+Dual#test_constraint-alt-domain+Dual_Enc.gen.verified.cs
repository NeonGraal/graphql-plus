//HintName: test_constraint-alt-domain+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Dual;

internal class testCnstAltDmnDualEncoder : IEncoder<ItestCnstAltDmnDualObject>
{
  public Structured Encode(ItestCnstAltDmnDualObject input)
    => Structured.Empty();
}

internal class testRefCnstAltDmnDualEncoder<TRef> : IEncoder<ItestRefCnstAltDmnDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDmnDualObject<TRef> input)
    => Structured.Empty();
}

internal class testDomCnstAltDmnDualEncoder : IEncoder<ItestDomCnstAltDmnDual>
{
  public Structured Encode(ItestDomCnstAltDmnDual input)
    => new(input.Value);
}

internal static class test_constraint_alt_domain_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_alt_domain_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstAltDmnDualObject>(_ => new testCnstAltDmnDualEncoder())
      .AddEncoder<ItestDomCnstAltDmnDual>(_ => new testDomCnstAltDmnDualEncoder());
}
