//HintName: test_alt-mod-Boolean+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Output;

internal class testAltModBoolOutpEncoder : IEncoder<ItestAltModBoolOutpObject>
{
  public IGqlpValue Encode(ItestAltModBoolOutpObject input)
    => new GqlpUnit();

  internal static testAltModBoolOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltModBoolOutpEncoder : IEncoder<ItestAltAltModBoolOutpObject>
{
  public IGqlpValue Encode(ItestAltAltModBoolOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModBoolOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_mod_Boolean_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_mod_Boolean_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltModBoolOutpObject>(testAltModBoolOutpEncoder.Factory)
      .AddEncoder<ItestAltAltModBoolOutpObject>(testAltAltModBoolOutpEncoder.Factory);
}
