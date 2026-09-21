//HintName: test_directive-param-dict_Enc.gen.cs
// Generated from {CurrentDirectory}directive-param-dict.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_directive_param_dict;

internal class testInDrctParamDictEncoder : IEncoder<ItestInDrctParamDictObject>
{
  public Structured Encode(ItestInDrctParamDictObject input)
    => Structured.Empty();

  internal static testInDrctParamDictEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_directive_param_dictEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_directive_param_dictEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestInDrctParamDictObject>(testInDrctParamDictEncoder.Factory);
}
