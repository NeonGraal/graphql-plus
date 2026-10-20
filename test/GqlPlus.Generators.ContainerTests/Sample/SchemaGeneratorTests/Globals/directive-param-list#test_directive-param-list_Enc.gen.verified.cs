//HintName: test_directive-param-list_Enc.gen.cs
// Generated from {CurrentDirectory}directive-param-list.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_directive_param_list;

internal class testInDrctParamListEncoder : IEncoder<ItestInDrctParamListObject>
{
  public Structured Encode(ItestInDrctParamListObject input)
    => Structured.Empty();

  internal static testInDrctParamListEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_directive_param_listEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_directive_param_listEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestInDrctParamListObject>(testInDrctParamListEncoder.Factory);
}
