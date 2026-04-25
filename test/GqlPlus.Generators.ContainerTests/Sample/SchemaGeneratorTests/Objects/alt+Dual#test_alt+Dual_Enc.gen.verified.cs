//HintName: test_alt+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Dual;

internal class testAltDualEncoder : IEncoder<ItestAltDualObject>
{
  public Structured Encode(ItestAltDualObject input)
    => Structured.Empty();

  internal static testAltDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltDualEncoder : IEncoder<ItestAltAltDualObject>
{
  public Structured Encode(ItestAltAltDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltDualObject>(testAltDualEncoder.Factory)
      .AddEncoder<ItestAltAltDualObject>(testAltAltDualEncoder.Factory);
}
