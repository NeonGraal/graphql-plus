//HintName: test_directive-param-in_Dec.gen.cs
// Generated from {CurrentDirectory}directive-param-in.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_directive_param_in;

internal class testInDrctParamInDecoder : IDecoder<ItestInDrctParamInObject>
{

  public IMessages Decode(IValue input, out ItestInDrctParamInObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInDrctParamInDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_directive_param_inDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_directive_param_inDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInDrctParamInObject>(testInDrctParamInDecoder.Factory);
}
