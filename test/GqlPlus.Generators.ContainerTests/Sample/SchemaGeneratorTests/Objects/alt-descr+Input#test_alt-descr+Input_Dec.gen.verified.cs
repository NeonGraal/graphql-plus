//HintName: test_alt-descr+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_descr_Input;

internal class testAltDescrInpDecoder : IDecoder<ItestAltDescrInpObject>
{

  public IMessages Decode(IValue input, out ItestAltDescrInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_descr_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_descr_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltDescrInpObject>(testAltDescrInpDecoder.Factory);
}
