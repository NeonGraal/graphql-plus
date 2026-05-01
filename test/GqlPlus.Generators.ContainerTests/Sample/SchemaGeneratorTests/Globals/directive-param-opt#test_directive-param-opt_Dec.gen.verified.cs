//HintName: test_directive-param-opt_Dec.gen.cs
// Generated from {CurrentDirectory}directive-param-opt.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_directive_param_opt;

internal class testInDrctParamOptDecoder : IDecoder<ItestInDrctParamOptObject>
{

  public IMessages Decode(IValue input, out ItestInDrctParamOptObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInDrctParamOptDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_directive_param_optDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_directive_param_optDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInDrctParamOptObject>(testInDrctParamOptDecoder.Factory);
}
