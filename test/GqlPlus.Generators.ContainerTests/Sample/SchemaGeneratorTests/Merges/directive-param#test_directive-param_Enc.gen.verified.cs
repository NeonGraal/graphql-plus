//HintName: test_directive-param_Enc.gen.cs
// Generated from {CurrentDirectory}directive-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_directive_param;

internal class testInDrctParamEncoder : IEncoder<ItestInDrctParamObject>
{
  public Structured Encode(ItestInDrctParamObject input)
    => Structured.Empty();

  internal static testInDrctParamEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_directive_paramEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_directive_paramEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestInDrctParamObject>(testInDrctParamEncoder.Factory);
}
