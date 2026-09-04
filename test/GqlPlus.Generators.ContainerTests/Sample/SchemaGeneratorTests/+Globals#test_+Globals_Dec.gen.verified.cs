//HintName: test_+Globals_Dec.gen.cs
// Generated from {CurrentDirectory}+Globals.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Globals;

internal class testInDrctParamDictDecoder : NullDecoder<ItestInDrctParamDictObject>
{

  internal static testInDrctParamDictDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamInDecoder : NullDecoder<ItestInDrctParamInObject>
{

  internal static testInDrctParamInDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamListDecoder : NullDecoder<ItestInDrctParamListObject>
{

  internal static testInDrctParamListDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamOptDecoder : NullDecoder<ItestInDrctParamOptObject>
{

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
