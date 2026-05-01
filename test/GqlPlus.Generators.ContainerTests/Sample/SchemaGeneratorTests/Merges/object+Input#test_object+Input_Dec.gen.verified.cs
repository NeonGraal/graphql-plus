//HintName: test_object+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_Input;

internal class testObjInpDecoder : IDecoder<ItestObjInpObject>
{

  public IMessages Decode(IValue input, out ItestObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjInpObject>(testObjInpDecoder.Factory);
}
