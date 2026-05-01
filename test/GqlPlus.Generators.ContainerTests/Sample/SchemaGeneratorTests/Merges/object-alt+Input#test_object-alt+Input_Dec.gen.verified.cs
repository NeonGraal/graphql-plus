//HintName: test_object-alt+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Input;

internal class testObjAltInpDecoder : IDecoder<ItestObjAltInpObject>
{

  public IMessages Decode(IValue input, out ItestObjAltInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltInpTypeDecoder : IDecoder<ItestObjAltInpTypeObject>
{

  public IMessages Decode(IValue input, out ItestObjAltInpTypeObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltInpTypeDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_alt_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_alt_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjAltInpObject>(testObjAltInpDecoder.Factory)
      .AddDecoder<ItestObjAltInpTypeObject>(testObjAltInpTypeDecoder.Factory);
}
