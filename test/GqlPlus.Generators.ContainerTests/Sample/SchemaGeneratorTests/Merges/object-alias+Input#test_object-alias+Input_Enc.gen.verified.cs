//HintName: test_object-alias+Input_Enc.gen.cs
// Generated from {CurrentDirectory}object-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alias_Input;

internal class testObjAliasInpEncoder : IEncoder<ItestObjAliasInpObject>
{
  public Structured Encode(ItestObjAliasInpObject input)
    => Structured.Empty();

  internal static testObjAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_alias_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_alias_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjAliasInpObject>(testObjAliasInpEncoder.Factory);
}
