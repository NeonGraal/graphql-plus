//HintName: test_+Globals_Dec.gen.cs
// Generated from {CurrentDirectory}+Globals.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Globals;

internal class testInDrctParamDictDecoder
{
}

internal class testInDrctParamInDecoder
{
}

internal class testInDrctParamListDecoder
{
}

internal class testInDrctParamOptDecoder
{
}

internal static class test__GlobalsDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__GlobalsDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInDrctParamDictObject>(_ => new testInDrctParamDictDecoder())
      .AddDecoder<ItestInDrctParamInObject>(_ => new testInDrctParamInDecoder())
      .AddDecoder<ItestInDrctParamListObject>(_ => new testInDrctParamListDecoder())
      .AddDecoder<ItestInDrctParamOptObject>(_ => new testInDrctParamOptDecoder());
}
