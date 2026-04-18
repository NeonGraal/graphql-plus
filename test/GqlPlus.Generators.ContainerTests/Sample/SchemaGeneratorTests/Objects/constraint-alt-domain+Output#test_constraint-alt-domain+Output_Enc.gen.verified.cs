//HintName: test_constraint-alt-domain+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Output;

internal class testCnstAltDmnOutpEncoder : IEncoder<ItestCnstAltDmnOutpObject>
{
  public Structured Encode(ItestCnstAltDmnOutpObject input)
    => Structured.Empty();

  internal static testCnstAltDmnOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDmnOutpEncoder<TRef> : IEncoder<ItestRefCnstAltDmnOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDmnOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testDomCnstAltDmnOutpEncoder : IEncoder<ItestDomCnstAltDmnOutp>
{
  public Structured Encode(ItestDomCnstAltDmnOutp input)
    => new(input.Value);

  internal static testDomCnstAltDmnOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_alt_domain_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_alt_domain_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstAltDmnOutpObject>(testCnstAltDmnOutpEncoder.Factory)
      .AddEncoder<ItestDomCnstAltDmnOutp>(testDomCnstAltDmnOutpEncoder.Factory);
}
