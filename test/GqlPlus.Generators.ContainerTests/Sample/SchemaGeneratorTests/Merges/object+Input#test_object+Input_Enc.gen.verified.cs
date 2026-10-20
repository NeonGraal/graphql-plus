//HintName: test_object+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_Input;

internal class testObjInpEncoder : IEncoder<ItestObjInpObject>
{
  public Structured Encode(ItestObjInpObject input)
    => Structured.Empty();

  internal static testObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjInpObject>(testObjInpEncoder.Factory);
}
