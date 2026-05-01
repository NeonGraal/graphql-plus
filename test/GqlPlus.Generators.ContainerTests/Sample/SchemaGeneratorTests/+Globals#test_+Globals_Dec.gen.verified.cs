//HintName: test_+Globals_Dec.gen.cs
// Generated from {CurrentDirectory}+Globals.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Globals;

internal class testInDrctParamDictDecoder : IDecoder<ItestInDrctParamDictObject>
{

  public IMessages Decode(IValue input, out ItestInDrctParamDictObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInDrctParamDictDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamInDecoder : IDecoder<ItestInDrctParamInObject>
{

  public IMessages Decode(IValue input, out ItestInDrctParamInObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInDrctParamInDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamListDecoder : IDecoder<ItestInDrctParamListObject>
{

  public IMessages Decode(IValue input, out ItestInDrctParamListObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInDrctParamListDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamOptDecoder : IDecoder<ItestInDrctParamOptObject>
{

  public IMessages Decode(IValue input, out ItestInDrctParamOptObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInDrctParamOptDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__GlobalsDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__GlobalsDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInDrctParamDictObject>(testInDrctParamDictDecoder.Factory)
      .AddDecoder<ItestInDrctParamInObject>(testInDrctParamInDecoder.Factory)
      .AddDecoder<ItestInDrctParamListObject>(testInDrctParamListDecoder.Factory)
      .AddDecoder<ItestInDrctParamOptObject>(testInDrctParamOptDecoder.Factory);
}
