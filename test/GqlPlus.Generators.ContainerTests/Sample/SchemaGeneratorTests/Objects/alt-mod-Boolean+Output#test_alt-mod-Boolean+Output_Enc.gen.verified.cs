//HintName: test_alt-mod-Boolean+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Output;

internal class testAltModBoolOutpEncoder : IEncoder<ItestAltModBoolOutpObject>
{
  public Structured Encode(ItestAltModBoolOutpObject input)
    => Structured.Empty();
}

internal class testAltAltModBoolOutpEncoder : IEncoder<ItestAltAltModBoolOutpObject>
{
  public Structured Encode(ItestAltAltModBoolOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal static class test_alt_mod_Boolean_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_mod_Boolean_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltModBoolOutpObject>(_ => new testAltModBoolOutpEncoder())
      .AddEncoder<ItestAltAltModBoolOutpObject>(_ => new testAltAltModBoolOutpEncoder());
}
