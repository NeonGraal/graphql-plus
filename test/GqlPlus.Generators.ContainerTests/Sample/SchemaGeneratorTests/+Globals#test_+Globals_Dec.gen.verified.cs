//HintName: test_+Globals_Dec.gen.cs
// Generated from {CurrentDirectory}+Globals.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Globals;

internal class testCtgrDscrsDecoder
{
}

internal class testCtgrOutpDecoder
{
}

internal class testCtgrOutpDescrDecoder
{
}

internal class testCtgrOutpDictDecoder
{
}

internal class testCtgrOutpListDecoder
{
}

internal class testCtgrOutpOptlDecoder
{
}

internal class testDescrDecoder
{
}

internal class testDescrBcksDecoder
{
}

internal class testDescrBtwnDecoder
{
}

internal class testDescrCmplDecoder
{
}

internal class testDescrDblDecoder
{
}

internal class testDescrSnglDecoder
{
}

internal class testDscrsDecoder
{
}

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
      .AddDecoder<ItestCtgrDscrsObject>(_ => new testCtgrDscrsDecoder())
      .AddDecoder<ItestCtgrOutpObject>(_ => new testCtgrOutpDecoder())
      .AddDecoder<ItestCtgrOutpDescrObject>(_ => new testCtgrOutpDescrDecoder())
      .AddDecoder<ItestCtgrOutpDictObject>(_ => new testCtgrOutpDictDecoder())
      .AddDecoder<ItestCtgrOutpListObject>(_ => new testCtgrOutpListDecoder())
      .AddDecoder<ItestCtgrOutpOptlObject>(_ => new testCtgrOutpOptlDecoder())
      .AddDecoder<ItestDescrObject>(_ => new testDescrDecoder())
      .AddDecoder<ItestDescrBcksObject>(_ => new testDescrBcksDecoder())
      .AddDecoder<ItestDescrBtwnObject>(_ => new testDescrBtwnDecoder())
      .AddDecoder<ItestDescrCmplObject>(_ => new testDescrCmplDecoder())
      .AddDecoder<ItestDescrDblObject>(_ => new testDescrDblDecoder())
      .AddDecoder<ItestDescrSnglObject>(_ => new testDescrSnglDecoder())
      .AddDecoder<ItestDscrsObject>(_ => new testDscrsDecoder())
      .AddDecoder<ItestInDrctParamDictObject>(_ => new testInDrctParamDictDecoder())
      .AddDecoder<ItestInDrctParamInObject>(_ => new testInDrctParamInDecoder())
      .AddDecoder<ItestInDrctParamListObject>(_ => new testInDrctParamListDecoder())
      .AddDecoder<ItestInDrctParamOptObject>(_ => new testInDrctParamOptDecoder());
}
