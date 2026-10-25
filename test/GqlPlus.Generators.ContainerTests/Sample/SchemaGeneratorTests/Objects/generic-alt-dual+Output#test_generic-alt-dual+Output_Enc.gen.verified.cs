//HintName: test_generic-alt-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

internal class testGnrcAltDualOutpEncoder : IEncoder<ItestGnrcAltDualOutpObject>
{
  public IGqlpValue Encode(ItestGnrcAltDualOutpObject input)
    => new GqlpUnit();

  internal static testGnrcAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltDualOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltDualOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltDualOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcAltDualOutpEncoder : IEncoder<ItestAltGnrcAltDualOutpObject>
{
  public IGqlpValue Encode(ItestAltGnrcAltDualOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_alt_dual_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_alt_dual_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcAltDualOutpObject>(testGnrcAltDualOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltDualOutpObject>(testAltGnrcAltDualOutpEncoder.Factory);
}
