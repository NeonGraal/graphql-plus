//HintName: test_object-alt+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Input;

internal class testObjAltInpEncoder : IEncoder<ItestObjAltInpObject>
{
  public IGqlpValue Encode(ItestObjAltInpObject input)
    => new GqlpUnit();

  internal static testObjAltInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltInpTypeEncoder : IEncoder<ItestObjAltInpTypeObject>
{
  public IGqlpValue Encode(ItestObjAltInpTypeObject input)
    => new GqlpUnit();

  internal static testObjAltInpTypeEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_alt_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_alt_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjAltInpObject>(testObjAltInpEncoder.Factory)
      .AddEncoder<ItestObjAltInpTypeObject>(testObjAltInpTypeEncoder.Factory);
}
