//HintName: test_alt-mod-Boolean+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Input;

internal class testAltModBoolInpEncoder : IEncoder<ItestAltModBoolInpObject>
{
  public IGqlpValue Encode(ItestAltModBoolInpObject input)
    => new GqlpUnit();

  internal static testAltModBoolInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltModBoolInpEncoder : IEncoder<ItestAltAltModBoolInpObject>
{
  public IGqlpValue Encode(ItestAltAltModBoolInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModBoolInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_mod_Boolean_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_mod_Boolean_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltModBoolInpObject>(testAltModBoolInpEncoder.Factory)
      .AddEncoder<ItestAltAltModBoolInpObject>(testAltAltModBoolInpEncoder.Factory);
}
