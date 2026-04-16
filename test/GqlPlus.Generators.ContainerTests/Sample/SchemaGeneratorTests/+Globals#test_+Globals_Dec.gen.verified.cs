//HintName: test_+Globals_Dec.gen.cs
// Generated from {CurrentDirectory}+Globals.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Globals;

internal class testInDrctParamDictDecoder
{

  internal static testInDrctParamDictDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamInDecoder
{

  internal static testInDrctParamInDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamListDecoder
{

  internal static testInDrctParamListDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamOptDecoder
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
