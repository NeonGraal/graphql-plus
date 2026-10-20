//HintName: test_object-alt-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-alt-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_enum_Input;

internal class testObjAltEnumInpEncoder : IEncoder<ItestObjAltEnumInpObject>
{
  public Structured Encode(ItestObjAltEnumInpObject input)
    => Structured.Empty();

  internal static testObjAltEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_alt_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_alt_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjAltEnumInpObject>(testObjAltEnumInpEncoder.Factory);
}
