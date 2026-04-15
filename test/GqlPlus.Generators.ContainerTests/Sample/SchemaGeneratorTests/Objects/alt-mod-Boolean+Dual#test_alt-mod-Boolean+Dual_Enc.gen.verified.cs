//HintName: test_alt-mod-Boolean+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

internal class testAltModBoolDualEncoder : IEncoder<ItestAltModBoolDualObject>
{
  public Structured Encode(ItestAltModBoolDualObject input)
    => Structured.Empty();
}

internal class testAltAltModBoolDualEncoder : IEncoder<ItestAltAltModBoolDualObject>
{
  public Structured Encode(ItestAltAltModBoolDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal static class test_alt_mod_Boolean_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_mod_Boolean_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltModBoolDualObject>(_ => new testAltModBoolDualEncoder())
      .AddEncoder<ItestAltAltModBoolDualObject>(_ => new testAltAltModBoolDualEncoder());
}
