//HintName: test_directive-param-opt_Enc.gen.cs
// Generated from {CurrentDirectory}directive-param-opt.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_directive_param_opt;

internal class testInDrctParamOptEncoder : IEncoder<ItestInDrctParamOptObject>
{
  public Structured Encode(ItestInDrctParamOptObject input)
    => Structured.Empty();

  internal static testInDrctParamOptEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_directive_param_optEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_directive_param_optEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestInDrctParamOptObject>(testInDrctParamOptEncoder.Factory);
}
