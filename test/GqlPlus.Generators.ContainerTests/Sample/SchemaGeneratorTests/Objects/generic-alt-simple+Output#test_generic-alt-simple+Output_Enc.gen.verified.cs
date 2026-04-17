//HintName: test_generic-alt-simple+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

internal class testGnrcAltSmplOutpEncoder : IEncoder<ItestGnrcAltSmplOutpObject>
{
  public Structured Encode(ItestGnrcAltSmplOutpObject input)
    => Structured.Empty();

  internal static testGnrcAltSmplOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltSmplOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltSmplOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltSmplOutpObject<TRef> input)
    => Structured.Empty();
}

internal static class test_generic_alt_simple_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_alt_simple_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcAltSmplOutpObject>(testGnrcAltSmplOutpEncoder.Factory);
}
