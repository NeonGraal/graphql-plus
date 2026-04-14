//HintName: test_object-alt-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}object-alt-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_enum_Output;

internal class testObjAltEnumOutpDecoder
{
}

internal static class test_object_alt_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_alt_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjAltEnumOutpObject>(_ => new testObjAltEnumOutpDecoder());
}
