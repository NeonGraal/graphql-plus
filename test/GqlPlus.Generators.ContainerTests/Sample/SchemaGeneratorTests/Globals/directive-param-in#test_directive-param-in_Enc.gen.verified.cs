//HintName: test_directive-param-in_Enc.gen.cs
// Generated from {CurrentDirectory}directive-param-in.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_directive_param_in;

internal class testInDrctParamInEncoder : IEncoder<ItestInDrctParamInObject>
{
  public Structured Encode(ItestInDrctParamInObject input)
    => Structured.Empty();

  internal static testInDrctParamInEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_directive_param_inEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_directive_param_inEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestInDrctParamInObject>(testInDrctParamInEncoder.Factory);
}
